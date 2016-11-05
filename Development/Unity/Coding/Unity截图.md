**1.读取屏幕像素**

``` {.prettyprint .linenums .prettyprinted style=""}
IEnumerator CaputreScreen(){      yield return new WaitForEndOfFrame();      texture.ReadPixels(new Rect(0, 0, width, height), 0, 0);      texture.Apply();}
```

<span
style="line-height: 1.6;">该方法可以截取一个矩形框内的图像，但是需要等待一帧结束才可以读取到图像数据</span>\

\

**2.Unity提供的截图功能**

``` {.prettyprint .linenums .prettyprinted style=""}
Application.CaptureScreenshot("Screenshot.png");
```

<span
style="line-height: 1.6;">这种方式只能截取整个屏幕的图像，是最简单的一种方式</span>\

\

**3.使用RenderTexture**

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
RenderTexture renderTexture = new RenderTexture(width, height, 24);renderCamera.targetTexture = renderTexture;renderCamera.Render();RenderTexture.active = renderTexture;Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);texture.Apply();RenderTexture.active = null;renderCamera.targetTexture = null;DestroyImmediate(renderTexture);
```

</div>

<span
style="line-height: 1.6;">该方法需要绑定一个Camera来作为渲染Camera，该方法只会得到该摄像机中的图像</span>\

