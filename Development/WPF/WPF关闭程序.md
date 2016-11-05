1.Application.Current.Shutdown();
<div>

2.<span
style="line-height: 1.6;">Application.Current.MainWindow.Close();或</span><span
style="line-height: 1.6;">在MainWindow中调用</span><span
style="line-height: 1.6;">this.Close();</span>

</div>

<div>

<span style="line-height: 1.6;">3.</span><span
style="line-height: 1.6;">Environment.Exit(0);立即退出程序没有任何警告</span>

</div>
