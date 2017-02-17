Unity中的协程是个好东西，正确的使用起来可以很方便的解决问题。

比如在协程中定义一个while循环代替一直在Update中使用条件判断，而且因为协程每次都是从上次return的地方开始执行，所以在while循环之前定义的变量改变后再次进入不会被重新赋值，可以代替全局变量来使用，极大的减少了全局变量的定义。

``` csharp
IEnumerator UpdateProgressBar (float totalTime) {
    //下面两个变量可以代替全局变量，下次进入时不会再重新复制
    float progress = 0f;
    float time = 0f;
    //使用while语句可以不用在Update里一直判断
    while (progress < 1) {
        progress += Time.deltaTime / totalTime;
        time += Time.deltaTime;
        progressBar.SetProgress (progress, time);
        //每次return后下一次将从return的地方开始执行
        yield return null;
    }
}
```

还可以用来等待某件不固定时间的事情完成
``` csharp
IEnumerator WaitToRecordOver() {
    while (recordPlayer.Control.GetCurrentTimeMs () < character.snippets [currentIndex].end) {
        yield return null;
    }
    StopRecord ();
}
```