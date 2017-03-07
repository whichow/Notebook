uLua将Lua中的协程封装了一下，使得对熟悉Unity协程的人来说更加友好，下面我们来看一下怎样在uLua中使用类似于Unity的协程
```lua
function WaitToClosePanel()
    coroutine.wait(1)
    ClosePanel()
end

coroutine.start(WaitToClosePanel)
```
再看一个www的例子
```lua
function WaitToWWW()
    local www = UnityEngine.WWW("http://www.baidu.com")
    coroutine.www(www)
    log(www.text)
end

coroutine.start(WaitToWWW)
```
输出下载进度
```lua
function WaitToDownloadOver()
    local www = UnityEngine.WWW("http://www.unknownworlds.com/downloads/Decoda.exe")
    while www.isDone do
		log(www.progress)
		coroutine.wait(0.1)
	end
end

coroutine.start(WaitToDownloadOver)
```