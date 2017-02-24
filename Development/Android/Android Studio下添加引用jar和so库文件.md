
## 添加jar库文件
将jar文件复制到Android Studio工程app/libs文件夹中(选择Project而不是Android可以看到该文件夹)，如果没有该文件夹，新建一个。

添加jar文件，有下面几种方式

第一种方法，右键点击jar文件，选择"Add As Library"就可以了。

第二种方法，右键点击工程目录，选择Open Module Setting，在Dependencies中点击"+"，选择File dependency，在弹出框中选择jar文件。

手动添加方式，在app下的`build.gradle`文件中的dependencies中添加：
```json
dependencies {
    compile 'com.android.support:support-v4:18.0.0'
    //要添加的jar包
    compile files('libs/Msc.jar')
    //或者直接添加整个文件夹中的jar包
    compile fileTree(dir: 'libs', include: ['*.jar'])
}
```

## 添加工程中的其他模块依赖
如果想添加工程中的其他模块作为依赖，右键点击工程目录，选择Open Module Setting，在Dependencies中点击"+"，选择Modules dependency，在弹出框中选择要添加的模块。

手动添加方式，在app下的`build.gradle`文件中的dependencies中添加：

```json
dependencies {
    //要添加的模块
    compile project(":androidunitylib")
}
```
注意确保在`settings.gradle`中有包含该模块
```
include ':app', ':androidunitylib'
```

## 添加Maven库
第三方库如果上传到了Maven库中，可以这样添加，右键点击工程目录，选择Open Module Setting，在Dependencies中点击"+"，选择Library dependency，在弹出框中可以搜索相关Maven库。

手动添加方式，在app下的`build.gradle`文件中的dependencies中添加：

```json
dependencies {
    //要添加的Maven库
    compile 'com.googlecode.mp4parser:isoparser:1.1.21'
}
```

## 添加第三方源码库
如果要添加第三方的源码库，可以点击菜单File->New->Import Module，在Source directory中选择要添加的第三方库源码文件夹，接下来的操作就和添加模块依赖一样。

手动添加方式，先将源码的文件夹复制到工程目录中，在Android Studio的Project下就会出现该文件夹，接下来在`settings.gradle`中添加
```
//app后面是要添加的模块
include ':app', ':androidunitylib'
```
还要在源码目录中添加一个`build.gradle`文件，里面的内容参照其他模块，写起来比较麻烦，最好用Import Module方式添加，接下来的操作就和添加模块依赖一样。

## 添加so库文件

在Eclipse中so库默认是放在libs文件夹中，但是在Android Studio中默认so文件的路径是在app/src/main/jniLibs中(没有文件夹自己新建)，还需要根据平台不同添加子文件夹如：armeabi，armeabi-v7a，x86等，然后直接将so库文件直接丢进去就好了。

要更改默认路径，可以在`build.gradle`中配置：
```json
sourceSets {
    main {
        jniLibs.srcDirs=['libs']
    }
}
```

**参考**

[Android Studio下添加引用jar文件和so文件](http://www.cnblogs.com/jp1017/p/4878319.html)

[Android Studio导入第三方类库的方法](http://www.cnblogs.com/neozhu/p/3458759.html)

[Android Studio Jar、so、library项目依赖](https://rocko.xyz/2014/12/13/Android-Studio-jar%E3%80%81so%E3%80%81library%E9%A1%B9%E7%9B%AE%E4%BE%9D%E8%B5%96/)