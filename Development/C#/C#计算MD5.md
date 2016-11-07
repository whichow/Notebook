``` prettyprint
using (var md5 = MD5.Create()){    using (var stream = File.OpenRead(filename))    {        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-",string.Empty);    }}
```


