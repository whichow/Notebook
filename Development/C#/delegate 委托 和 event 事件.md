事件event是一种特使的委托，加了event关键字后只能在该类中调用delegate，其他类中只能订阅(Subscribe,即+=）<span
style="line-height: 1.6;">或取消订阅(Unsubscribe，即-=)</span><span
style="line-height: 1.6;">该事件</span>

net framework推荐使用了event关键字的delegate的原型最好类似delegate void
MyEventHandler(object sender, MyEventHandler e)
