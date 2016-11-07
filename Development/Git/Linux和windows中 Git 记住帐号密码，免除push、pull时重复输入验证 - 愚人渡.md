Linux和windows中 Git 记住帐号密码，免除push、pull时重复输入验证 - 愚人渡
[Linux和windows中 Git 记住帐号密码，免除push、pull时重复输入验证](#)
====================================================================

Hot:18130℃ -- Poster:Echo -- Date:2014-09-24
**Linux下：**

[TABLE]

到这一步，执行完后查看Git目录下的.gitconfig文件，会多了一项：

[TABLE]

**Windows下：**

方法一（本人未使用过）：

在windows中添加一个HOME环境变量，变量名:HOME,变量值：%USERPROFILE%

进入%HOME%目录，新建一个名为"\_netrc"的文件，文件中内容格式如下：

[TABLE]

方法二（测试可行）：

在home文件夹，一般是 C:\\Documents and Settings\\Administrator 下建立文件 .git-credentials

输入以下内容：

[TABLE]

运行以下git配置命令：

[TABLE]

重新打开git bash即可，无需再输入用户名和密码了。

#### 推荐阅读：

[PHP和jQuery实现QR Code二维码生成](http://old.yurendu.com/516/php%E5%92%8Cjquery%E5%AE%9E%E7%8E%B0qr%20code%E4%BA%8C%E7%BB%B4%E7%A0%81%E7%94%9F%E6%88%90.html)
[MySQL十大优化技巧](http://old.yurendu.com/253/mysql%E5%8D%81%E5%A4%A7%E4%BC%98%E5%8C%96%E6%8A%80%E5%B7%A7.html)
[jQuery插件galleria的配置和使用](http://old.yurendu.com/35/jquery%E6%8F%92%E4%BB%B6galleria%E7%9A%84%E9%85%8D%E7%BD%AE%E5%92%8C%E4%BD%BF%E7%94%A8.html)
[PHP判断是否是手机访问](http://old.yurendu.com/102/php%E5%88%A4%E6%96%AD%E6%98%AF%E5%90%A6%E6%98%AF%E6%89%8B%E6%9C%BA%E8%AE%BF%E9%97%AE.html)
[mysql replace 批量替换字段中的值](http://old.yurendu.com/519/mysql%20replace%20%E6%89%B9%E9%87%8F%E6%9B%BF%E6%8D%A2%E5%AD%97%E6%AE%B5%E4%B8%AD%E7%9A%84%E5%80%BC.html)
[php实现 rss订阅](http://old.yurendu.com/284/php%E5%AE%9E%E7%8E%B0%20rss%E8%AE%A2%E9%98%85.html)
[CentOS系统性能指标查看](http://old.yurendu.com/70/centos%E7%B3%BB%E7%BB%9F%E6%80%A7%E8%83%BD%E6%8C%87%E6%A0%87%E6%9F%A5%E7%9C%8B.html)
[PHP date函数日期格式明细](http://old.yurendu.com/334/php%20date%E5%87%BD%E6%95%B0%E6%97%A5%E6%9C%9F%E6%A0%BC%E5%BC%8F%E6%98%8E%E7%BB%86.html)
[SEO中HTML标签权重分配](http://old.yurendu.com/347/seo%E4%B8%ADhtml%E6%A0%87%E7%AD%BE%E6%9D%83%E9%87%8D%E5%88%86%E9%85%8D.html)
[CSS字体中英文名称对照表](http://old.yurendu.com/185/css%E5%AD%97%E4%BD%93%E4%B8%AD%E8%8B%B1%E6%96%87%E5%90%8D%E7%A7%B0%E5%AF%B9%E7%85%A7%E8%A1%A8.html)

[最新]()[最早]()[最热]()

-   [0条评论](#)

-   还没有评论，沙发等你来抢

[]()
社交帐号登录:

-   [微信](http://yurendu.duoshuo.com/login/weixin/)
-   [微博](http://yurendu.duoshuo.com/login/weibo/)
-   [QQ](http://yurendu.duoshuo.com/login/qq/)
-   [人人](http://yurendu.duoshuo.com/login/renren/)
-   [更多»](#)

.

[![](Linux和windows中%20Git%20记住帐号密码，免除push、pull时重复输入验证%20-%20愚人渡_files/86865.jpg)](#)
```
```

[]( "插入表情")[]( "插入图片")

.

[愚人渡正在使用多说](http://duoshuo.com/)


