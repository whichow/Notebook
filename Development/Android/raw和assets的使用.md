raw和assets的使用
<div>

<div>

**res/raw和assets的相同点：**

</div>

<div>

\

</div>

<div>

两者目录下的文件在打包后会原封不动的保存在apk包中，不会被编译成二进制。

</div>

<div>

\

</div>

<div>

**res/raw和assets的不同点：**

</div>

<div>

1.res/raw中的文件会被映射到R.Java文件中，访问的时候直接使用资源ID即R.id.filename；assets文件夹下的文件不会被映射到R.java中，访问的时候需要AssetManager类。

</div>

<div>

2.res/raw不可以有目录结构，而assets则可以有目录结构，也就是assets目录下可以再建立文件夹

</div>

<div>

\

</div>

<div>

**读取文件资源：**

</div>

<div>

\

</div>

<div>

读取res/raw下的文件资源，通过以下方式获取输入流来进行写操作

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

InputStream is = getResources().openRawResource(R.id.filename);

</div>

</div>

<div>

\

</div>

<div>

读取assets下的文件资源，通过以下方式获取输入流来进行写操作

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

AssetManager am = null; am = getAssets();

</div>

<div>

InputStream is = am.open("filename");

</div>

</div>

<div>

\

</div>

<div>

**视频播放例子：**

</div>

<div>

\

</div>

<div>

assets文件夹下

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

AssetFileDescriptor afd = getAssets().openFd("guide\_video.mp4");

</div>

<div>

             mediaPlayer.setDataSource(afd.getFileDescriptor(),

</div>

<div>

                     afd.getStartOffset(), afd.getLength())；

</div>

</div>

<div>

\

</div>

<div>

raw文件夹下

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

Uri mUri = Uri.parse("android.resource://" + getPackageName() + "/"+
R.raw.guide\_video);

</div>

<div>

             mediaPlayer.setDataSource(this, mUri);

</div>

</div>

<div>

\

</div>

</div>
