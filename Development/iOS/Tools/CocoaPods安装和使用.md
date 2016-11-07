CocoaPods介绍
-------------

CocoaPods是一种为iOS程序开发提供依赖管理的工具。

-   Pods项目最终会编译成一个名为 libPods.a 的文件，主项目只需要依赖这个 .a 文件即可。

-   对于资源文件，CocoaPods 提供了一个名为 Pods-resources.sh的 bash脚本，该脚本在每次项目编译的时候都会执行，将第三方库的各种资源文件复制到目标目录中。

-   CocoaPods 通过一个名为 Pods.xcconfig 的文件来在编译时设置所有的依赖和参数。

安装CocoaPods
-------------

我们要使用到gem，这是一个基于Ruby的工具，OS X中已经自带了。

首先需要将gem的源更换为国内的源（翻墙了的可以省略这一步）

``` prettyprint
$ gem sources --remove https://rubygems.org/      //去掉ruby软件源$ gem sources -a https://ruby.taobao.org/    //添加淘宝的源$ gem sources -a http://rubygems-china.oss.aliyuncs.com    //添加阿里云的源$ gem sources -l     //查看ruby软件源
```

接下来就开始安装CocoaPods

``` prettyprint
$ sudo gem install cocoapods
```

如果你的gem太老，可能也会有问题，可以尝试用如下命令升级gem

``` prettyprint
$ sudo gem update --system
```

如果Ruby版本太老，可能会出现“Error installing cocoapods: activesupport requires Ruby version &gt;= 2.2.2”，可以使用下面的方法解决

``` prettyprint
$ sudo gem install activesupport -v 4.2.6$ sudo gem install cocoapods
```

使用CocoaPods
-------------

首先，配置CocoaPods

``` prettyprint
$ pod setup
```

这一步会下载CocoaPods specifications，相当于所有已经提交到CocoaPods中的库的一个索引。放在GitHub上，有几百M，网速慢的话需要等很长的时间。

也可以不执行setup，执行search或install的时候都会自动执行这一步。

如果下载太慢可以手动从GitHub上clone下来

``` prettyprint
$ cd ~/.cocoapods/repos$ git clone https://github.com/CocoaPods/Specs.git master --depth=1
```

或者从其他已经下载好的地方复制到~/.cocoapods/repos/master

搜索需要的第三方库是否支持 CocoaPods

``` prettyprint
$ pod search AFNetworking
```

每个项目都需要一个Podfile文件，在文件中添加需要下载的库，由库名和版本号组成，如

``` prettyprint
platform :ios, '7.0'pod "AFNetworking", "~> 2.0"//新版CocoaPods需要这样写platform :ios, '8.0'use_frameworks!target 'MyApp' do  pod 'AFNetworking', '~> 2.6'  pod 'ORStackView', '~> 3.0'  pod 'SwiftyJSON', '~> 2.3'end
```

也可以不指定版本号，直接下载最新的版本

进入项目根目录，执行install命令，就会自动开始下载需要的库

``` prettyprint
$ pod install
```

如果是在本地的pod库，加上--no-repo-update，则不会去git上检查更新，加快速度

``` prettyprint
$ pod install --no-repo-update
```

每次修改了Podfile文件，就需要执行一次update命令

``` prettyprint
$ pod update
```

需要注意的是，使用pod后需要关掉原来的工程文件xcodeproj，打开pod创建的xcworkspace

参考：

CocoaPods 安装和使用

<https://cnbin.github.io/blog/2015/05/25/cocoapods-an-zhuang-he-shi-yong/>

用CocoaPods做iOS程序的依赖管理

<http://blog.devtang.com/2014/05/25/use-cocoapod-to-manage-ios-lib-dependency/>

Error installing cocoapods: activesupport requires Ruby version &gt;= 2.2.2

<https://github.com/CocoaPods/CocoaPods/issues/4711>

Issues Cloning Spec repo - GitHub taking a very long time to download changes to the Specs Repo

<https://github.com/CocoaPods/CocoaPods/issues/4989>


