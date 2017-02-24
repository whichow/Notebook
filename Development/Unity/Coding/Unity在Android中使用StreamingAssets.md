在Android中使用StreamingAssets不得不说是一个坑，因为是直接打包到jar包中，不能直接读取，只能通过Unity的WWW类来获取内容，但是有时候需要通过流来获取里面的内容，可以这样做：
``` csharp
IEnumerator DeserializeXml(string path) {
    WWW www = new WWW (path);
    yield return www;

    var writer = new MemoryStream(www.bytes)
    //或者
    Stream s = new Stream();
    using (var writer = new BinaryWriter(s))
    {
        writer.Write(wwwbytes);
    }
}
```