# 在Flask中使用HTTPS

要使用HTTPS，我们需要在CA(Certificate Authority)申请一个证书，否则我们的HTTPS链接将在浏览器上显示为不可信。我们可以从[Let’s Encrypt](https://letsencrypt.org/)申请免费的证书。其中有两种方式可以获取证书，使用Shell和不使用Shell，这里只介绍使用Shell的方式。

这里给我们提供了一个非常好用的工具[Certbot](https://certbot.eff.org/)。首先需要选择你使用的Web服务器和操作系统，我们选择的是None of the above和CentOS 6，选择完后会有一个生成证书的教程。

## 下载脚本并安装
下载脚本并加上执行权限
```
wget https://dl.eff.org/certbot-auto
chmod a+x certbot-auto
```
运行
```
$ ./certbot-auto
```
## 开始制作证书
Certbot支持许多不同的插件给来获取和安装证书。因为我们的服务器不支持自动安装证书，需要使用`certonly`命令来获取证书。
```
./path/to/certbot-auto certonly
```
执行后可以交互式的选择插件和选项来获取证书，如果有web服务器正在运行，又不想使你的网站停止服务的话推荐选择`webroot`插件。
还可以使用命令行来生成
```
$ ./path/to/certbot-auto certonly --webroot -w /var/www/example -d example.com -d www.example.com -w /var/www/thing -d thing.is -d m.thing.is
```
上面这行的会给`example.com`，`www.example.com`，`thing.is`和`m.thing.is`生成一个单独的证书，会放在`/var/www/example`目录下提供给前两个域名，`/var/www/thing`目录下给后两个域名。

如果还没有搭建web服务器的话，选择`standalone`，这会使用一个内置临时的web服务器来获取证书(如果有web服务器正在运行，需要先停止我们的web服务器)。
使用命令行
```
$ ./path/to/certbot-auto certonly --standalone -d example.com -d www.example.com
```
这会给`example.com -d`和`www.example.com`生成一个证书。

我们使用`standalone`方式来生成我们的证书。生成的证书会放在`/etc/letsencrypt/live/your.domain.com`目录中，我们将`privakey.pem`和`fullchain.pem`拷贝到我们的Flask程序目录中。在代码中：
```python
if __name__ == '__main__':
    context = ('fullchain.pem', 'privkey.pem')
    app.run(host='0.0.0.0', port=8111, debug=True, ssl_context=context)
```
现在我们的Flask程序使用的就是HTTPS协议了。因为我们的证书是针对域名生成的，所以在浏览器中打开我们的网站时需要使用域名来访问。

证书是有有效期的，Let's Encrypt证书的有效期是90天，为了防止我们的证书过期，需要定期更新证书(更新时需要停止web服务，更新完后需要替换程序目录的证书)。
```
./path/to/certbot-auto renew --quiet 
```

参考：  
[How to serve HTTPS \*directly\* from Flask (no nginx, no apache, no gunicorn)](http://flask.pocoo.org/snippets/111/)  
[Automatically enable HTTPS on your website with EFF's Certbot, deploying Let's Encrypt certificates](https://certbot.eff.org/#centos6-other)