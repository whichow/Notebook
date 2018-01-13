在Unity中使用WebRequest请求https时会报TlsException: Invalid certificate received from server错误，这是由于Unity使用的Mono版本导致的问题，Mono2.0默认是不信任任何https请求的。

只需要在使用之前加上下面的代码就没问题了
```cs
System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) =>
{
    return true;
};
```

[Mono https webrequest fails with “The authentication or decryption has failed”
](https://stackoverflow.com/questions/4926676/mono-https-webrequest-fails-with-the-authentication-or-decryption-has-failed)