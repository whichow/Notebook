## 获取info.plist文件

获取ipa的安装包，可以通过iTools导出手机中已安装App的ipa包。
导出ipa包后将后缀“.ipa”改成“.zip”并解压。
在解压的文件找到info.plist文件。
## 打开info.plist文件

windows下需要安装一个plist文件编辑器：
[plist edit](http://download.cnet.com/Plist-Editor/3000-2141_4-10909598.html)  
下载plist edit并安装然后之前找到的info.plist文件图标会变成一个黄色图标，双击打开。
## 获取包名、进程ID、协议名

在plist edit中可以通过ctrl+f查找一下信息。

- CFBundleDisplayName 显示的应用名称
- CFBundleIdentifier 包名
- CFBundleExecutable 进程id
- CFBundleName（一般和进程id是一样的，然后同info.plist文件中会有一个和进程id名的文件）
- CFBundleURLTypes 协议 （一般有多个）用来唤起APP
## 举例参考

|应用名称	|包名	|进程ID	|协议名|
|----------|-----|--------|------|
|QQ安全中心	|com.tencent.QQ-Mobile	|QQMobileToken	|wx68451b483ebd18ce|
|Todoist	|com.todoist.ios	|Todoist	|db-o8lsvx1nvnswy6q|
|阿里小号	|cn.aliqin.KB	|KB	|wxe39210a97e3a9c10|
|借贷宝	|com.renrenxing.JDB	|JDBClient	|wxbae9446f8aeb25d5|
|天天基金网	|com.eastmoney.jijin	|EMProjJijin	|wx4654ffed0376f250|
|惠惠购物助手	|cn.huihui.deals	|deals	|wx5ee450e46e396fd1|
|赚客帮	|com.qixiao.zkbios13	|ZhuangKeBang	|wx3fd85989fa215ecc|