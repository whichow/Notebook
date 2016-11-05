Unity API提供的方法一般只能在主线程中执行，在新开的线程中是不能执行的，

在<span
style="line-height: 1.6;">.NET中可以使用dispatcher来实现，但是Unity中并不支持。</span>

在Unity中除了通过共享全局变量的形式来进行同步，还可以通过Action或delegate来实现：

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
//在线程中action1 = new Action(()=>{ 要执行的Unity方法; });     action2 = new Action<float>(()=>{ 要执行的Unity方法; });//在主线程Update中void Update(){     if (action1 != null)    {        action1.Invoke();        action1 = null;    }    if (action2 != null)    {        action2.Invoke(Time.deltaTime);        action2 = null;    }}
```

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
 if (InvokeRequired) {    this.Invoke(new Action(() => MyFunction()));    return; }//or .NET 2.0this.Invoke((MethodInvoker) delegate {MyFunction();});
```

</div>

</div>

<span
style="line-height: 1.6;">另外可以使用Loom插件来实现Unity多线程</span>

``` {.prettyprint .linenums .prettyprinted}
 //Function called from other Threadpublic void NotifyFinished(int status){     Debug.Log("Notify");     try     {         if (status == (int)LevelStatusCode.OK)         {             Loom.QueueOnMainThread(() =>             {                 PresentNameInputController();             });         }     }     catch (Exception e)     {         Debug.LogError(e.ToString());     }}
```

\

