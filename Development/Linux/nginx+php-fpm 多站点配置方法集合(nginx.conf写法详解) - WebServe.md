nginx+php-fpm 多站点配置方法集合(nginx.conf写法详解) - WebServer - 54rd我是程序员(php,phpunit,nginx,shell,ubuntu)
nginx+php-fpm 多站点配置方法集合(nginx.conf写法详解)
 2015-01-18 17:57:07    [0](http://54rd.net/html/2015/webserver_0118/26.html#comment_iframe)    120    [](# "点击登录收藏文章") 
===================================================================================================================================

在使用nginx搭建多站点时，其实就是在nginx conf中使用多个server来控制即可，需要几个站点就新增加几个server，下面来看实例讲解：1 编写server配置：假定需要增加站点1：www test1 com，站点根目录在 home wo

在使用nginx搭建多站点时，其实就是在nginx.conf中使用多个server来控制即可，需要几个站点就新增加几个server，下面来看实例讲解：
1. 编写server配置：
-------------------

假定需要增加站点1：www.test1.com，站点根目录在/home/work/webroot/test1下，php-fpm使用sock交互方式(也可选择127.0.0.1:9000)，sock在php-fpm.conf中的配置地址为/home/work/php/var/php-cgi.sock，那么具体配置如下：
[view plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

1.  server {  
2.        listen              80;  
3.        server\_name         test1.com www.test1.com  
4.    
5.        location ~\\.php$ {  
6.           root            /home/work/webroot/test1;  
7.           fastcgi\_pass    unix:/home/work/php/var/php-cgi.sock;  
8.           fastcgi\_index   index.php;  
9.           include         fastcgi.conf;  
10.       }  
11.       location / {  
12.          root /home/work/webroot/test1;  
13.          index index.php;  
14.       }  
15. }  

假定需要增加站点2：www.test2.com，站点根目录在/home/work/webroot/test2下，php-fpm和站点1一样，使用同一个，那么具体配置如下：
[view plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

1.  server {  
2.        listen              80;  
3.        server\_name         test2.com www.test2.com  
4.    
5.        location ~\\.php$ {  
6.           root            /home/work/webroot/test2;  
7.           fastcgi\_pass    unix:/home/work/php/var/php-cgi.sock;  
8.           fastcgi\_index   index.php;  
9.           include         fastcgi.conf;  
10.       }  
11.       location / {  
12.          root /home/work/webroot/test2;  
13.          index index.php;  
14.       }  
15. }  

2. 将server配置添加到ningx配置中去：
------------------------------------

方式一：直接将上面的server配置拷贝添加到nginx.conf文件中的http{}大括号中，具体看下面代码：
[view plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

1.  http {  
2.        include       mime.types;  
3.        include       upstream.conf;  
4.        default\_type  application/octet-stream;  
5.    
6.        access\_log  "/home/work/nginx/log/access\_log"  main;  
7.    
8.        // ... (省略其他配置，将server配置粘贴在下面，回答括号之上即可)  
9.    
10.       server {  
11.          listen              80;  
12.          server\_name         test1.com www.test1.com  
13.   
14.          location ~\\.php$ {  
15.             root            /home/work/webroot/test1;  
16.             fastcgi\_pass    unix:/home/work/php/var/php-cgi.sock;  
17.             fastcgi\_index   index.php;  
18.             include         fastcgi.conf;  
19.          }  
20.   
21.          location / {  
22.             root /home/work/webroot/test1;  
23.             index index.php;  
24.          }  
25.       }  
26.   
27.       server {  
28.          listen              80;  
29.          server\_name         test2.com www.test2.com  
30.   
31.          location ~\\.php$ {  
32.             root            /home/work/webroot/test2;  
33.             fastcgi\_pass    unix:/home/work/php/var/php-cgi.sock;  
34.             fastcgi\_index   index.php;  
35.             include         fastcgi.conf;  
36.          }  
37.   
38.          location / {  
39.             root /home/work/webroot/test2;  
40.             index index.php;  
41.          }  
42.       }  
43. }  

方式二：将上面的server配置拷贝添加到一个新的文件，例如命名文件为test.conf，然后保存到/home/work/nginx/conf/test.conf，最后到nginx.conf文件中的http{}大括号中添加以下代码：
[view plain](http://54rd.net/html/2015/webserver_0118/26.html#)[print](http://54rd.net/html/2015/webserver_0118/26.html#)[?](http://54rd.net/html/2015/webserver_0118/26.html#)

1.  http {  
2.        include       mime.types;  
3.        include       upstream.conf;  
4.        default\_type  application/octet-stream;  
5.    
6.        access\_log  "/home/work/nginx/log/access\_log"  main;  
7.    
8.        // ... (省略其他配置，添加下面一行代码即可)  
9.    
10.       include /home/work/nginx/conf/\*.conf;   
11.   
12. }  

小结：nginx搭建多站点，使用多个server配置。


