nginx+php-fpm 多站点配置方法集合(nginx.conf写法详解) - WebServer -
54rd我是程序员(php,phpunit,nginx,shell,ubuntu)
<div>

\
<div style="font-size: 16px">

<div
style="box-sizing:border-box;font-family:sans-serif;font-size:10px;-webkit-tap-highlight-color:rgba(0, 0, 0, 0);">

<div
style="box-sizing:border-box;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;line-height:1.42857;color:rgb(102, 102, 102);-webkit-font-smoothing:antialiased;background:rgb(68, 68, 68);">

<div
style="box-sizing:border-box;overflow-x:hidden;overflow-y:scroll;border-top-left-radius:5px;box-shadow:rgba(0, 0, 0, 0.6) 0px 0px 15px;background:rgb(247, 247, 247);">

<div style="box-sizing:border-box;border-radius:3px;">

<div style="box-sizing:border-box;">

<div style="box-sizing:border-box;">

<div
style="box-sizing:border-box;border-radius:3px;background:rgb(255, 255, 255);">

<div
style="box-sizing:border-box;margin-left:20px;margin-right:20px;margin-bottom:20px;">

nginx+php-fpm 多站点配置方法集合(nginx.conf写法详解)\
<span style="box-sizing:border-box;font-family:inherit;font-weight:500;line-height:1.1;color:inherit;margin-top:10px;margin-bottom:10px;font-size:12px;"><span style="box-sizing:border-box;position:relative;top:1px;display:inline-block;font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;-webkit-font-smoothing:antialiased;"><span style="font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;"></span></span> 2015-01-18 17:57:07</span>   <span style="box-sizing:border-box;font-family:inherit;font-weight:500;line-height:1.1;color:inherit;margin-top:10px;margin-bottom:10px;font-size:12px;"><span style="box-sizing:border-box;position:relative;top:1px;display:inline-block;font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;-webkit-font-smoothing:antialiased;"><span style="font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;"></span></span> [0](http://54rd.net/html/2015/webserver_0118/26.html#comment_iframe)</span>   <span style="box-sizing:border-box;font-family:inherit;font-weight:500;line-height:1.1;color:inherit;margin-top:10px;margin-bottom:10px;font-size:12px;"><span style="box-sizing:border-box;position:relative;top:1px;display:inline-block;font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;-webkit-font-smoothing:antialiased;"><span style="font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;"></span></span> <span style="box-sizing:border-box;">120</span></span>   <span style="box-sizing:border-box;float:right;"> [<span style="box-sizing:border-box;position:relative;top:1px;display:inline-block;font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;-webkit-font-smoothing:antialiased;color:red;"><span style="font-family:'Glyphicons Halflings';font-style:normal;font-weight:400;line-height:1;"></span></span>](# "点击登录收藏文章") </span> {#nginxphp-fpm-多站点配置方法集合nginx.conf写法详解-2015-01-18-175707-0-120 style="line-height:1.1;box-sizing:border-box;margin:0px;padding:0px;border:0px;font-size:24px;font-family:inherit;font-weight:500;color:inherit;margin-top:20px;margin-bottom:10px;"}
==========================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================

<div
style="color:rgb(138, 109, 59);box-sizing:border-box;border-color:rgb(245, 231, 158);padding:15px;margin-bottom:20px;border-radius:4px;margin:0px;border:1px solid transparent;background-color:rgb(252, 248, 227);text-shadow:rgba(255, 255, 255, 0.2) 0px 1px 0px;box-shadow:rgba(255, 255, 255, 0.247059) 0px 1px 0px inset, rgba(0, 0, 0, 0.0470588) 0px 1px 2px;background-image:linear-gradient(rgb(252, 248, 227) 0px, rgb(248, 239, 192) 100%);background-repeat:repeat-x;">

在使用nginx搭建多站点时，其实就是在nginx
conf中使用多个server来控制即可，需要几个站点就新增加几个server，下面来看实例讲解：1
编写server配置：假定需要增加站点1：www test1 com，站点根目录在 home wo

</div>

<div
style="box-sizing:border-box;margin:0px;padding:0px;border:0px;margin-left:20px;">

在使用nginx搭建多站点时，其实就是在nginx.conf中使用多个server来控制即可，需要几个站点就新增加几个server，下面来看实例讲解：\
\
1. 编写server配置： {#编写server配置 style="box-sizing:border-box;font-family:inherit;font-weight:500;line-height:1.1;color:inherit;font-size:30px;margin:0px;padding:0px;border:0px;"}
-------------------

\
假定需要增加站点1：www.test1.com，站点根目录在/home/work/webroot/test1下，php-fpm使用sock交互方式(也可选择127.0.0.1:9000)，sock在php-fpm.conf中的配置地址为/home/work/php/var/php-cgi.sock，那么具体配置如下：\
\
<div
style="box-sizing:border-box;padding:0px;border:0px;font-family:Consolas, 'Courier New', Courier, mono, serif;font-size:12px;width:99%;overflow:auto;padding-top:1px;background-color:rgb(231, 229, 220);margin:18px 0px;">

<div
style="box-sizing:border-box;margin:0px;padding:0px;border:0px;padding-left:45px;">

<div
style="font-size:9px;box-sizing:border-box;line-height:normal;padding:3px 8px 10px 10px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;margin:0px;border:0px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;border-left-width:3px;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);">

[view
plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

</div>

</div>

1.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">server {  </span></span>
2.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      listen              80;  </span>
3.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      server\_name         test1.com www.test1.com  </span>
4.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
5.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      location \~\\.php\$ {  </span>
6.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         root            /home/work/webroot/test1;  </span>
7.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi\_pass    unix:/home/work/php/<span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">var</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">/php-cgi.sock;  </span></span>
8.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi\_index   index.php;  </span>
9.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi.conf;  </span></span>
10. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
11. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      location / {  </span>
12. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         root /home/work/webroot/test1;  </span>
13. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         index index.php;  </span>
14. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
15. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">}  </span>

</div>

\
假定需要增加站点2：www.test2.com，站点根目录在/home/work/webroot/test2下，php-fpm和站点1一样，使用同一个，那么具体配置如下：\
\
<div
style="box-sizing:border-box;padding:0px;border:0px;font-family:Consolas, 'Courier New', Courier, mono, serif;font-size:12px;width:99%;overflow:auto;padding-top:1px;background-color:rgb(231, 229, 220);margin:18px 0px;">

<div
style="box-sizing:border-box;margin:0px;padding:0px;border:0px;padding-left:45px;">

<div
style="font-size:9px;box-sizing:border-box;line-height:normal;padding:3px 8px 10px 10px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;margin:0px;border:0px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;border-left-width:3px;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);">

[view
plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

</div>

</div>

1.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">server {  </span></span>
2.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      listen              80;  </span>
3.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      server\_name         test2.com www.test2.com  </span>
4.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
5.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      location \~\\.php\$ {  </span>
6.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         root            /home/work/webroot/test2;  </span>
7.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi\_pass    unix:/home/work/php/<span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">var</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">/php-cgi.sock;  </span></span>
8.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi\_index   index.php;  </span>
9.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi.conf;  </span></span>
10. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
11. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      location / {  </span>
12. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         root /home/work/webroot/test2;  </span>
13. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         index index.php;  </span>
14. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
15. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">}  </span>

</div>

\
2. 将server配置添加到ningx配置中去： {#将server配置添加到ningx配置中去 style="box-sizing:border-box;font-family:inherit;font-weight:500;line-height:1.1;color:inherit;font-size:30px;margin:0px;padding:0px;border:0px;"}
------------------------------------

\
方式一：直接将上面的server配置拷贝添加到nginx.conf文件中的http{}大括号中，具体看下面代码：\
\
<div
style="box-sizing:border-box;padding:0px;border:0px;font-family:Consolas, 'Courier New', Courier, mono, serif;font-size:12px;width:99%;overflow:auto;padding-top:1px;background-color:rgb(231, 229, 220);margin:18px 0px;">

<div
style="box-sizing:border-box;margin:0px;padding:0px;border:0px;padding-left:45px;">

<div
style="font-size:9px;box-sizing:border-box;line-height:normal;padding:3px 8px 10px 10px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;margin:0px;border:0px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;border-left-width:3px;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);">

[view
plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

</div>

</div>

1.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">http {  </span></span>
2.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">       mime.types;  </span></span>
3.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">       upstream.conf;  </span></span>
4.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      default\_type  application/octet-stream;  </span>
5.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
6.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      access\_log  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:blue;background-color:inherit;">"/home/work/nginx/log/access\_log"</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  main;  </span></span>
7.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
8.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 130, 0);background-color:inherit;">// ... (省略其他配置，将server配置粘贴在下面，回答括号之上即可)</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span></span>
9.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
10. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      server {  </span>
11. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         listen              80;  </span>
12. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         server\_name         test1.com www.test1.com  </span>
13. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
14. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         location \~\\.php\$ {  </span>
15. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            root            /home/work/webroot/test1;  </span>
16. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            fastcgi\_pass    unix:/home/work/php/<span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">var</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">/php-cgi.sock;  </span></span>
17. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            fastcgi\_index   index.php;  </span>
18. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi.conf;  </span></span>
19. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         }  </span>
20. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
21. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         location / {  </span>
22. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            root /home/work/webroot/test1;  </span>
23. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            index index.php;  </span>
24. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         }  </span>
25. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
26. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
27. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      server {  </span>
28. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         listen              80;  </span>
29. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         server\_name         test2.com www.test2.com  </span>
30. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
31. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         location \~\\.php\$ {  </span>
32. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            root            /home/work/webroot/test2;  </span>
33. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            fastcgi\_pass    unix:/home/work/php/<span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">var</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">/php-cgi.sock;  </span></span>
34. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            fastcgi\_index   index.php;  </span>
35. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         fastcgi.conf;  </span></span>
36. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         }  </span>
37. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
38. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         location / {  </span>
39. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            root /home/work/webroot/test2;  </span>
40. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">            index index.php;  </span>
41. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">         }  </span>
42. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      }  </span>
43. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">}  </span>

</div>

\
方式二：将上面的server配置拷贝添加到一个新的文件，例如命名文件为test.conf，然后保存到/home/work/nginx/conf/test.conf，最后到nginx.conf文件中的http{}大括号中添加以下代码：\
\
<div
style="box-sizing:border-box;padding:0px;border:0px;font-family:Consolas, 'Courier New', Courier, mono, serif;font-size:12px;width:99%;overflow:auto;padding-top:1px;background-color:rgb(231, 229, 220);margin:18px 0px;">

<div
style="box-sizing:border-box;margin:0px;padding:0px;border:0px;padding-left:45px;">

<div
style="font-size:9px;box-sizing:border-box;line-height:normal;padding:3px 8px 10px 10px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;margin:0px;border:0px;font-family:Verdana, Geneva, Arial, Helvetica, sans-serif;color:silver;border-left-width:3px;border-left-style:solid;border-left-color:rgb(108, 226, 108);background-color:rgb(248, 248, 248);">

[view
plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

</div>

</div>

1.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">http {  </span></span>
2.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">       mime.types;  </span></span>
3.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">       upstream.conf;  </span></span>
4.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      default\_type  application/octet-stream;  </span>
5.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
6.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      access\_log  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:blue;background-color:inherit;">"/home/work/nginx/log/access\_log"</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  main;  </span></span>
7.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
8.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 130, 0);background-color:inherit;">// ... (省略其他配置，添加下面一行代码即可)</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span></span>
9.  <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
10. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">      <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:rgb(0, 102, 153);background-color:inherit;font-weight:bold;">include</span><span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;"> /home/work/nginx/conf/\*.conf;   </span></span>
11. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">  </span>
12. <span
    style="box-sizing:border-box;margin:0px;padding:0px;border:none;color:black;background-color:inherit;">}  </span>

</div>

\
\
<span
style="box-sizing:border-box;color:#ff0000;">小结：nginx搭建多站点，使用多个server配置。</span>\
\
\

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

</div>

\

</div>
