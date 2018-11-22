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