使用plist安装，一般是企业级开发者账号不需要登录到APP STORE的IOS设备应用发布时所用到的技巧。

准备: *一台运行着OSX的苹果电脑，最新版的XCODE，用于导出ipa和plist

一个HTML网页文件(告知iphone如何找到itms-services，已附上)

一个HTTP服务器(存放APP的服务器，就是提供ipa流量的服务器)

一款云存储(以七牛云存储为例，用于推送plist)，建议升级到标准版用户，操作非常简单

备选: 一张二维码，一份自动分辨IOS设备的JS脚本

PS:

从2014年6月开始，网上的教程都变得不太好用了，原因有两个：

从IOS7.1开始，http推送plist已经不好使，只能使用https推送

Dropbox已死，需要使用其他支持HTTPS外链的云存储来代替，操作难度升级
开始

第一步：
在使用MACBOOK导出ipa的时候，我们得到ipa的同时，还得到一份plist文件

看到我们导出的plist，需要注意的地方有两个已经用中文标注。

一个是URL，一个是bundle-identifier

```xml
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE plist PUBLIC "-//Apple//DTD PLIST 1.0//EN" "http://www.apple.com/DTDs/PropertyList-1.0.dtd">
<plist version="1.0">
<dict>
    <key>items</key>
    <array>
        <dict>
            <key>assets</key>
            <array>
                <dict>
                    <key>kind</key>
                    <string>software-package</string>
                    <key>url</key>
                    <string>请填上你的ipa下载地址(比如:http://127.0.0.1/app.ipa)</string>
                </dict>
            </array>
            <key>metadata</key>
            <dict>
                <key>bundle-identifier</key>
    <string>请填上你的开发者证书用户名</string>
                <key>bundle-version</key>
                <string>1.0</string>
                <key>kind</key>
                <string>software</string>
                <key>title</key>
                <string>请填上标题</string>
            </dict>
        </dict>
    </array>
</dict>
</plist>
```
1，URL就是我们的ipa存放位置，比如你拥有一台外网服务器，ip地址是12.34.56.78，ipa存放在APP这个文件夹，那么这个地方就填上

http://12.34.56.78/app/应用名字.ipa
2，bundle-identifier就是你申请证书时的名字，格式一般是somebody.app名字

3，这两个point都应该是在你使用XCODE导出ipa的时候要注意填写的

============================

第二步:
使用七牛存储的目的，在于它为我们提供了https连接

具体操作步骤可以参考
http://blog.csdn.net/longxibendi/article/details/37601747

操作完毕后，只要把生成的超链接复制下来
http://dn-定义的空间名字.qbox.me/应用名字.plist
改成
https://dn-定义的存储空间名字.qbox.me/应用名字.plist

填入到以下的HTML文件，并且添加到网页服务器中发布
```xml
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>应用名字</title>
</head>
<body>
<h1 style="font-size:80pt">如果点击无法下载安装，请复制超链接到浏览器中打开<h1/>
<h1 style="font-size:100pt">
<a title="iPhone" href="itms-services://?action=download-manifest&url=https://dn-你的空间名字.qbox.me/你的Plist存放位置/你的plist名字.plist">
Iphone Download</a><h1/>
</body>
</html>
```
第三步： 比如你发布这份HTML网页的地址是

http://12.34.56.78/iphoneAPP.html
把这个生成好的超链接，放到http://cli.im/url，生成二维码，再用手机扫一扫。即可完成整个企业级APP使用Plist发布的流程。