Nginx相同端口多站点配置
在目录/etc/nginx/conf.d/下新建配置文件site1.conf，site2.conf

site1.conf

server {

    listen     80

    server\_name     www.site1.com

    index     index.html index.htm;

    root     /home/www/site1;

}

site2.conf

server {

    listen     80

    server\_name     www.site2.com

    index     index.html index.htm;

    root     /home/www/site2;

}

现在就可以通过浏览器www.site1.com，www.site2.com分别访问不同网站了


