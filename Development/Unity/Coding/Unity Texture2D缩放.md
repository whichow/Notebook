**1.直接按像素**

``` prettyprint
Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight){    Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);    for (int i = 0; i < result.height; ++i)    {        for (int j = 0; j < result.width; ++j)        {            Color newColor = source.GetPixel(j * source.width / targetWidth, i * source.height / targetHeight);            result.SetPixel(j, i, newColor);        }    }    result.Apply();    return result;}
```

**2.双线性插值**

``` prettyprint
Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight){    Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);    for (int i = 0; i < result.height; ++i)    {        for (int j = 0; j < result.width; ++j)        {            Color newColor = source.GetPixelBilinear((float)j / (float)result.width, (float)i / (float)result.height);            result.SetPixel(j, i, newColor);        }    }    result.Apply();    return result;}
```


