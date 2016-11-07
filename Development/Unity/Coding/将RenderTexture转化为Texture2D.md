RenderTexture和Texture2D同样继承于Texture，两者都可以和Texture之间相互转化，但是两者之间却不能简单的进行强制转换，我们可以通过以下方式将RenderTexture转化为Texture2D：

``` prettyprint
int width = renderTexture.width;int height = renderTexture.height;//格式为RGB24或ARGB32，不能是RGBA32Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);RenderTexture.active = renderTexture;texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);texture2D.Apply();
```


