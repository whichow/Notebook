Unity实现定时器可以有很多种方式，如在Update里做累加，使用协程，使用InvokeRepeating。

在Update中：

```
void Update()
{
    time += Time.deltaTime;
    if(time > Time.deltaTime)
    {
        DoSomthing();
        time = 0f;
    }
}
```

在协程中：

```
IEnumerator StartTimer()
{
    while(true)
    {
        yield return new WaitForSeconds(time)
        DoSomthing();
    }
}
```

InvokeRepeating由于只能以字符串的形式调用自身方法，无法提供其它类使用，这里不做讨论

在Update中做累加，达到指定时间就出发一次定时器，可以看到，每次触发定时器的时间一定会大于设置的时间，如果以秒为单位的定时器，这个误差大部分情况可以忽略，但是如果是每秒要触发10次以上，误差的累加会导致最终的误差很大。

协程没有研究其内部机制，但是经过测试也是存在这个误差的，而且也会累加。

在Unity中较精确的一个方法是FixedUpdate，每次会以固定时长的间隔来运行这个方法，而且不受帧率波动影响

```
int i = 2f;
int count = 0f;

void FixedUpdate()
{
    if(count % i == 0)
    {
        DoSomthing();
    }
    count++;
}
```

但是这个方法也有一定限制，例如，设置Fixed Timestep为0.1，即每隔0.1秒执行1次FixedUpdate方法，在此基础上只能设置每隔0.1秒的整数倍执行一次该方法，如0.2秒、0.3秒。

下面的方法通过当前时间与定时器执行时间比较的方式来实现一个精确定时器  
原理：每次执行时间 = 启动时间 + 等待时间 + 时间间隔 * 执行次数  
每次当前时间大于定时器的执行时间，执行一次定时器，然后将执行次数加1
```csharp
public class ACTimerManager : MonoSingleton<ACTimerManager>
{
    public class ACTimer
    {
        public int timeId;
        public int runTimes;
        public float startTime;
        public float waitTime;
        public float timeInterval;
        public System.Action onTimeup;

        public void Start(System.Action onTimeup)
        {
            ACTimerManager.Instance.StartTimer(this, onTimeup);
        }

        public void Stop()
        {
            ACTimerManager.Instance.StopTimer(this);
        }
    }

    private int _timerIndex = 1;
    private List<ACTimer> _timer = new List<ACTimer>();
    private Queue<ACTimer> _unusedTimers = new Queue<ACTimer>();

    public ACTimer CreateTimer(float waitTime, float timeInterval)
    {
        ACTimer timer = _GetUnusedTimer();
        timer.timeId = _timerIndex;
        timer.runTimes = 0;
        timer.startTime = 0;
        timer.waitTime = waitTime;
        timer.timeInterval = timeInterval;

        _timerIndex++;
        return timer;
    }

    private ACTimer _GetUnusedTimer()
    {
        ACTimer timer;
        if (_unusedTimers.Count > 0)
        {
            timer = _unusedTimers.Dequeue();
        }
        else
        {
            timer = new ACTimer();
        }
        return timer;
    }

    public void StartTimer(ACTimer timer, System.Action onTimeup)
    {
        timer.startTime = Time.time;
        timer.onTimeup = onTimeup;
        _timer.Add(timer);
    }

    public void StopTimer(ACTimer timer)
    {
        _timer.Remove(timer);
        _unusedTimers.Enqueue(timer);
    }

    void Update()
    {
        for (int i = 0; i < _timer.Count; i++)
        {
            var timer = _timer[i];
            if (Time.time < timer.startTime + timer.waitTime + timer.timeInterval * timer.runTimes)
            {
                continue;
            }
            timer.runTimes++;
            if (timer != null)
            {
                timer.onTimeup();
            }
        }
    }
}
```