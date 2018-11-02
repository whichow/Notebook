有下面几种方式可以解决：

1. 设置代理

   在`gradle.properties`文件中加上

   ```
   systemProp.http.proxyHost=127.0.0.1
   systemProp.http.proxyPort=1080
   systemProp.https.proxyHost=127.0.0.1
   systemProp.https.proxyPort=1080
   ```

2. 手动下载

   在工程的`gradle/wrapper/gradle-wrapper.properties`文件中找到这一行

   ```
   distributionUrl=https\://services.gradle.org/distributions/gradle-2.4-all.zip
   ```

   手动下载下来，在`C:\users\用户名\.gradle\wrapper\dists\gradle-2.4-all`目录下找到一个一串随机字符的文件夹，放在里面就可以了

3. 配置本地Gradle

   将`gradle/wrapper/gradle-wrapper.properties`文件的`distributionUrl`修改为本地路径

   ```
   distributionUrl=file:///E:/gradle/gradle-2.4-all.zip
   ```
