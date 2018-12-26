在使用Gradle构建Android工程的时候，经常会遇到下载非常慢甚至超时问题，有下面几种方式可以解决：

1. 设置代理

   在`gradle.properties`文件中加上

   ```
   systemProp.http.proxyHost=127.0.0.1
   systemProp.http.proxyPort=1080
   systemProp.https.proxyHost=127.0.0.1
   systemProp.https.proxyPort=1080
   ```

2. 手动下载到指定文件夹

   在工程的`gradle/wrapper/gradle-wrapper.properties`文件中找到这一行

   ```
   distributionUrl=https\://services.gradle.org/distributions/gradle-2.4-all.zip
   ```

   手动下载下来，在`C:\users\用户名\.gradle\wrapper\dists\gradle-2.4-all`目录下找到一个一串随机字符的文件夹，放在里面就可以了

3. 配置本地Gradle

   先将gradle下载到本地，如`E:\\gradle\`，然后将`gradle/wrapper/gradle-wrapper.properties`文件的`distributionUrl`修改为本地路径

   ```
   distributionUrl=file:///E:/gradle/gradle-2.4-all.zip
   ```

4. 换国内镜像
   
   修改`build.gradle`
   ```
   allprojects {
        repositories {
            maven{ url 'http://maven.aliyun.com/nexus/content/groups/public/'}
        }
    }
   ```

   [Gradle 修改 Maven 仓库地址](http://www.yrom.net/blog/2015/02/07/change-gradle-maven-repo-url/)