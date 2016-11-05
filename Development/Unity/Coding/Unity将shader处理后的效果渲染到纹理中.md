<div>

``` {.prettyprint .linenums .prettyprinted}
  RenderTexture renderTexture = new RenderTexture (texture.width, texture.height, 0, RenderTextureFormat.ARGB32);//        renderTexture.Create ();//        Graphics.SetRenderTarget(null);//        GL.Clear(true, true, new Color(0, 0, 0, 0));  Graphics.Blit(texture, renderTexture, maskMaterial);  Texture2D finalTexture = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false);  RenderTexture.active = renderTexture;  finalTexture.ReadPixels (new Rect (0, 0, renderTexture.width, renderTexture.height), 0, 0);  finalTexture.Apply ();  RenderTexture.active = null;
```

</div>

<div>

\

</div>

<span style="font-family:Menlo">\
</span>
