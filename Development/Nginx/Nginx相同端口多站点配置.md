Nginx相同端口多站点配置
<div>

<div>

在目录/etc/nginx/conf.d/下新建配置文件site1.conf，site2.conf

</div>

<div>

\

</div>

<div>

site1.conf

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

server {

</div>

<div>

    listen     80

</div>

<div>

    server\_name     www.site1.com

</div>

<div>

\

</div>

<div>

    index     index.html index.htm;

</div>

<div>

    root     /home/www/site1;

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

site2.conf

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

server {

</div>

<div>

    listen     80

</div>

<div>

    server\_name     www.site2.com\

</div>

<div>

\

</div>

<div>

    index     index.html index.htm;

</div>

<div>

    root     /home/www/site2;

</div>

<div>

}

</div>

</div>

<div>

\

</div>

<div>

现在就可以通过浏览器www.site1.com，www.site2.com分别访问不同网站了

</div>

</div>
