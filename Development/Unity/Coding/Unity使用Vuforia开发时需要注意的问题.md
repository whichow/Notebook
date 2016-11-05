<div>

<div>

在IOS平台使用mainTextureScale = new Vector(1,
-1);会有问题，需要自己写代码翻转Texture

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
private void TextureFlipY(Texture2D texture){    Color temp;    for (int i = 0; i < texture.height / 2; i++)    {        for (int j = 0; j < texture.width; j++)        {            temp = texture.GetPixel(j, i);            texture.SetPixel(j, i, texture.GetPixel(j, texture.height - i));            texture.SetPixel(j, texture.height - i, temp);        }    }}
```

</div>

<div>

\

</div>

</div>

<div>

\

</div>

<div>

在Android和IOS平台程序从后台恢复后会出新只能获取到图像缓存的情况，加上下面的代码后正常

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
private void OnTrackableUpdated(){    if (!formatRegistered)    {        CameraDevice.Instance.SetFrameFormat(pixelFormat, false);        if (CameraDevice.Instance.SetFrameFormat(pixelFormat, true))        {            formatRegistered = true;        }    }    image = CameraDevice.Instance.GetCameraImage(pixelFormat);}void OnApplicationPause(){    formatRegistered = false;}
```

</div>

<div>

\

</div>

</div>

<div>

\

</div>

<div>

\

</div>

</div>
