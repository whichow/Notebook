[**Ruby** China](https://ruby-china.org/)

-   [社区](https://ruby-china.org/topics)
-   [Wiki](https://ruby-china.org/wiki)
-   [招聘](https://ruby-china.org/jobs)
-   [酷站](https://ruby-china.org/sites)
-   [Gems](https://gems.ruby-china.org/)

-   [注册](https://ruby-china.org/account/sign_up)
-   [登录](https://ruby-china.org/account/sign_in)

&nbsp;
-   

    **

git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手动合并吗？
===========================================================================================================

[Git](https://ruby-china.org/topics/node11) · [somesky](https://ruby-china.org/somesky) · 于 3 年前发布 · 最后由 [iceskysl](https://ruby-china.org/iceskysl) 于 2 年前回复 · 17796 次阅读

[![96](https://ruby-china.org/system/letter_avatars/2/S/162_136_126/96.png)](https://ruby-china.org/somesky)

git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手动合并吗？

[** ](https://ruby-china.org/account/sign_in)

共收到 **7** 条回复

[![1342](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/1342.jpg)](https://ruby-china.org/ywjno)

 [ywjno](https://ruby-china.org/ywjno) · [\#1](#reply1) · 3 年前 [](https://ruby-china.org/topics/7365/replies/71009/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

强制上传的命令`git push --force [远程名] [本地分支名]:[远程分支名]`
请小心使用。。。

[![2](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/2.png)](https://ruby-china.org/huacnlee)

 [huacnlee](https://ruby-china.org/huacnlee) · [\#2](#reply2) · 3 年前 [](https://ruby-china.org/topics/7365/replies/71019/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

    $ git push origin master --force

[![780](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/780.jpg)](https://ruby-china.org/liuhui998)

 [liuhui998](https://ruby-china.org/liuhui998) · [\#3](#reply3) · 3 年前 [](https://ruby-china.org/topics/7365/replies/71022/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

    $ git push origin master -f

[![60](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/60.jpg)](https://ruby-china.org/googya)

 [googya](https://ruby-china.org/googya) · [\#4](#reply4) · 3 年前 [](https://ruby-china.org/topics/7365/replies/71087/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

在本地解决冲突，然后再push，不用 -f 什么的吧，-f 看起来太恐怖了

[![942](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/942.jpg)](https://ruby-china.org/reus)

 [reus](https://ruby-china.org/reus) · [\#5](#reply5) · 3 年前 [](https://ruby-china.org/topics/7365/replies/71113/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

在本地
git merge -s ours origin master
再
git push origin master

[![2329](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/2329.jpg)](https://ruby-china.org/mingyuan0715)

 [mingyuan0715](https://ruby-china.org/mingyuan0715) · [\#6](#reply6) · 3 年前 [](https://ruby-china.org/topics/7365/replies/103783/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

我也很烦恼这个问题，先用git stash暂存本地的改动，然后等合并之后，再git stash apply选择版本号重新应用本地的改动内容。但是这个办法也不是太好。。。最好能够让git提供个merge ignore文件功能，能够制定哪些本地文件不与服务器上的合并。

[![540](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/540.jpg)](https://ruby-china.org/iceskysl)

 [iceskysl](https://ruby-china.org/iceskysl) · [\#7](#reply7) · 2 年前 [](https://ruby-china.org/topics/7365/replies/204910/edit "修改回帖") [](# "回复此楼") [** ](# "赞")

``` highlight
 git fetch --all  $ git reset --hard origin/master 
```

$ git fetch downloads the latest from remote without trying to merge or rebase anything. Then the $git reset resets the master branch to what you just fetched.

``` highlight
[www@hostname current]$ git fetch --all
Fetching origin
From github.com:iceskysl/www
   ad05fc..2009e  v3         -> origin/v3
[www@hostname current]$ git reset --hard origin/v3
HEAD is now at 205809e Merge pull request #42 from IceskYsl/v3
```

需要 [登录](https://ruby-china.org/account/sign_in) 后方可回复, 如果你还没有账号请点击这里 [注册](https://ruby-china.org/account/sign_up)。

相关话题

-   [2 个人使用 Git 做版本控制，如何合并代码](https://ruby-china.org/topics/12631)
-   [使用 Monit＋Mina 监控服务器](https://ruby-china.org/topics/23176)
-   [我安装ruby-china的简要步骤](https://ruby-china.org/topics/1398)
-   [10w 并发的服务器方案](https://ruby-china.org/topics/16897)
-   [vpncloud-helper 帮助你选择合适的 vpncloud 服务器。](https://ruby-china.org/topics/12666)

[**](#)
[** ](https://ruby-china.org/account/sign_in)

------------------------------------------------------------------------

[](# "分享到Twitter") [](# "分享到Facebook") [](# "分享到Google+") [](# "分享到新浪微博") [](# "分享到豆瓣")

------------------------------------------------------------------------

共收到 **7** 条回复

[参与回复](#reply)

------------------------------------------------------------------------

[**](#)

[** **有新回复！**点击这里立即载入](#)

![](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/c309db0b49cab85a32f756541ea0e2b0.png)

[关于](https://ruby-china.org/wiki/about) / [RubyConf](http://rubyconfchina.org/ "RubyConf China 大会") / [Ruby 镜像](https://ruby-china.org/wiki/ruby-mirror "Ruby 镜像") / [RubyGems 镜像](https://&/#10;gems.ruby-china.org "RubyGems 镜像") / [Status](https://ruby-china.org/status) / [活跃会员](https://ruby-china.org/users) / [API](https://ruby-china.org/api) / [贡献者](https://ruby-china.org/wiki/contributors) / [iOS 客户端](https://itunes.apple.com/us/app/ruby-china/id1072028763)

中国 Ruby 社区，由众多爱好者共同维护，致力于构建完善的 Ruby 中文社区。

服务器由 [![](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/e1eb47a05578576bf134da65736cc5b4.png)](http://www.ucloud.cn/?utm_source=zanzhu&utm_campaign=rubychina&utm_medium=display&utm_content=yejiao&ytag=rubychina_logo) 赞助 CDN 由 [![](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/3ad734d65891632fb049ba97044ba5a4.png)](https://www.upyun.com/?utm_source=ruby-china&utm_medium=ad&utm_campaign=upyun&md=ruby-china) 赞助 Gem 服务器由 [![](git进行合并的时候，与服务器上代码发生了冲突，如果我用本地的覆盖服务器上的，我该操作？这种也需要手_files/1977b4bcf6589a03fb4d21139955aa6a.png)](http://www.qcloud.com/?ref=ruby-china) 赞助

 [**](http://github.com/ruby-china "本站在 GitHub 上面的开源内容") [**](http://twitter.com/ruby_china "本站的 Twitter 账号") [**](http://weibo.com/u/3168836987 "本站的 Weibo 账号") [**](https://www.youtube.com/channel/UCOLKFS_uA7nX26_u8z9V9og/feed "本站在 YouTube 上面的视频内容") [**](https://ruby-china.org/topics/feed) [简体中文](https://ruby-china.org/topics/7365?locale=zh-CN) / [正體中文](https://ruby-china.org/topics/7365?locale=zh-TW) / [English](https://ruby-china.org/topics/7365?locale=en)


