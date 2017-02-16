在Unity的最新版本中使用的是SceneManager这个类来加载场景，弃用了Application.LoadLevel。
如：LoadScene("FirstScene", LoadSceneMode.Single);

其中LoadSceneMode是一个枚举类型，可以为Single和Additive。

Single表示加载完场景后会销毁当前场景。

Additive表示将要加载的场景的内容直接添加到当前场景中，适合用来做那些大型游戏场景的动态加载。

LoadSceneAsync表示在后台异步加载一个场景，参数和LoadScene类似。

这里的异步，是通过每一帧加载一部分资源来实现，还是在当前线程中执行，所以如果加载比较大型的场景或者涉及到IO等耗时操作的时候也会造成卡顿。

返回值为AsyncOperation，可以通过查询progress的值来获得当前进度。
``` csharp
IEnumerator LoadNewScene(string scene) {
    // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
    AsyncOperation async = Application.LoadLevelAsync(scene);

    // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
    while (!async.isDone) {
        Debug.Log (async.progress);
        yield return null;
    }
}
```
