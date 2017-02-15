# 将Maven库导入Android Studio中

如有这样一个Maven库：

|GroupId|ArtifactId|Version|
|-------|----------|-------|
|com.googlecode.mp4parser|isoparser|1.1.21|

不知道包名或版本号可以从<http://search.maven.org>这里搜索

我们要在Android Studio中引用它，只要在build.gradle中的dependencies中添加这样一行就可以了：
```
compile 'com.googlecode.mp4parser:isoparser:1.1.21'
```

**参考**

[How to import Maven dependency in Android Studio/IntelliJ?](http://stackoverflow.com/questions/16595287/how-to-import-maven-dependency-in-android-studio-intellij)

[add maven repository to build.gradle](http://stackoverflow.com/questions/20574111/add-maven-repository-to-build-gradle)