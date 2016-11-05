Texture2D和RenderTexture等new出来的Texture在使用完后记得释放，要不然会造成内存泄漏

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
Texutre2D texture = new Texture2D(width, height);Destroy(texture);    //或DestroyImmediate(texture);
```

</div>

<div>

\

</div>

\

