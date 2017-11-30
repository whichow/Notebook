## UGUI的美术字的制作和使用

这里制作的是在UGUI上显示的字体

### 1. 准备好我们需要制作美术字的图片

### 2. 下载字体制作工具[BMFont](http://www.angelcode.com/products/bmfont/)。

![](http://images.cnitblog.com/blog/487701/201312/26154919-08c9c73b827d4a3e99c365403ad3154b.png)

### 3. 接下来我们需要设置字体

![](http://images.cnitblog.com/blog/487701/201312/26155116-3ea55c52a8c8478da40e65e901126096.png)

如果要制作的字体包含中文的话，我们需要选择中文字体，Size里我们需要根据图片的实际大小来设置

![](http://images.cnitblog.com/blog/487701/201312/26155153-974cc78b211e4634b408f43a36ef1268.png)

由于中文字体文件字符集里的字符太多了，要从BMFont字符集里找到一个字符非常困难，所以可以将我们需要使用到的文字放在一个文本文件中，编码格式切记保存为UTF-8。

![](http://images.cnitblog.com/blog/487701/201312/26155025-f9ded95048eb4e5382b08c87c75a3695.png)

### 4. 通过菜单从文件中导入选择需要的字符

![](http://images.cnitblog.com/blog/487701/201312/26155341-2ab77386538644199c1413952a213b76.png)

导入成功后可以在左下角看到已经选择的字符数量

![](http://images.cnitblog.com/blog/487701/201312/26155419-1b26883de4f346809c98c9da619c0046.png)

### 5. 导入图片文件，通过菜单Edit -> Open Image Manager打开Image Manager，然后点击Image->Import Manager来导入图片，注意图片路径不能有中文。

![](http://gameweb-img.qq.com/gad/20170306/image002.1488784284.png)

选择图片后需要设置图片的Id

![](http://upload-images.jianshu.io/upload_images/1928510-cdabbd46c242e645.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

图片Id我们可以通过将鼠标移到相应的字符上来查看

![](http://upload-images.jianshu.io/upload_images/1928510-c4ac599af8017d17.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

图片导入成功后会在相应的字符右下角有一个标记

![](http://gameweb-img.qq.com/gad/20170306/image006.1488784284.png)

### 6. 导出选项，通过菜单Options -> Export Options打开

如果是彩色的字体或者想让字体显示更加清晰，需要将Bit depth改为32，Texture的Width和Height设置输出纹理的大小，可以根据需要修改，最好为2的n次方，File format选择XML。

![](http://upload-images.jianshu.io/upload_images/1928510-ef8f562df3f5e6f2.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

### 7. 导出字体文件，通过菜单Options -> Save bitmap font as...，导出成功后会有两个文件fnt和图集，将这两个文件放到Unity工程中

### 8. 下载制作字体的Unity脚本[BitmapFontGenerator](https://github.com/barasixi/bitmapfont-for-ugui)，导入到Unity中

选中导入的fnt和图集，点击右键Create -> BitmapFont，会生成Material文件和字体文件。

### 9. 在UGUI的Text组件中选择生成的Font和Material，输入文字就可以看到用该字体显示的内容了，如果需要调整字体大小，需要在Text组件下加上Bitmap Font Scaling组件，设置FontSize就可以改变大小了

[UGUI中使用位图艺术字（使用BMfont的两种方式）](http://blog.csdn.net/u010019717/article/details/52196364)
[uGUIでビットマップフォントを使ってみよう](https://qiita.com/barasixi/items/2729e52ae3d420fe76ab)
[程序和美术都能学会的Unity美术字体制作教程](http://gad.qq.com/article/detail/26188)
[Unity 使用BMFont制作字体](http://www.cnblogs.com/vitah/p/3912190.html)
[unity 3d中使用BMFont制作清晰字体](http://www.cnblogs.com/hejianchun/articles/3022732.html)
[Unity 自定义美术字](http://www.jianshu.com/p/ca877f1e14bc)
[UGUI运用美术字体](http://blog.csdn.net/akak2010110/article/details/50755270)