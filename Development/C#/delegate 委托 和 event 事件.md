事件event是一种特使的委托，加了event关键字后只能在该类中调用delegate，其他类中只能订阅(Subscribe,即+=）或取消订阅(Unsubscribe，即-=)该事件

net framework推荐使用了event关键字的delegate的原型最好类似delegate void MyEventHandler(object sender, MyEventHandler e)
