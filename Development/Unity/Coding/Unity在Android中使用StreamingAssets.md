在Android中使用StreamingAssets不得不说是一个坑，因为是直接打包到jar包中，不能直接读取，只能通过Unity的WWW类来获取内容，但是有时候需要通过流来获取里面的内容，可以这样做：
``` csharp
IEnumerator DeserializeXml(string path) {
    WWW www = new WWW (path);
    yield return www;
    XmlSerializer serializer = new XmlSerializer (typeof(Userdata));
    userdata = (Userdata)serializer.Deserialize (new MemoryStream(www.bytes));	
}
```