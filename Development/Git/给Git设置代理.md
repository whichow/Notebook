因为国内上GitHub实在是太慢了，所以我们需要通过代理来访问GitHub，但是使用git命令还是很慢，所以我们要给git也加上代理

代理服务器

$ git config --global http.proxy http://proxyuser:proxypwd@proxy.server.com:8080

$ git config --global https.proxy <https://proxyuser:proxypwd@proxy.server.com:8080>

使用本地代理

git config --global http.proxy 'socks5://127.0.0.1:1080'
git config --global https.proxy 'socks5://127.0.0.1:1080'

执行完后会在~/.gitconfig文件中多出

\[http\]

    proxy = [http://proxyuser:proxypwd@proxy.server.com:8080](http://proxyuser:proxypwd@proxy.server.com:8080/)

\[https\]

    proxy = [https://proxyuser:proxypwd@proxy.server.com:8080](https://proxyuser:proxypwd@proxy.server.com:8080/)

使用下面的命令检查是否生效

$ git config --global --get http.proxy

$ git config --global --get https.proxy

取消代理设置

$ git config --global --unset http.proxy

$ git config --global --unset https.proxy

参考：

git clone 太慢怎么办？

<http://www.aneasystone.com/archives/2015/08/git-clone-faster.html>

git 设置和取消代理

<https://gist.github.com/laispace/666dd7b27e9116faece6>


