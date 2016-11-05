<div class="multicntwrap"
style="font-family: 'Hiragino Sans GB W3', 'Hiragino Sans GB', Arial, Helvetica, simsun, u5b8bu4f53; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(204, 206, 208);">

<div class="multicnt">

### <span class="tcnt" style="font-size: 26px; font-family: 'Hiragino Sans GB W3', 'Hiragino Sans GB', 'Microsoft YaHei', 微软雅黑, Arial, Helvetica, simsun, 宋体; line-height: 38px;">Python返回数组（List）长度的方法</span>  <span class="bgc0 fc07 fw0 fs0" style="font-size: 12px; font-weight: normal; color: rgb(164, 164, 164); background-color: rgb(235, 235, 235);"></span> {#python返回数组list长度的方法 .title .pre .fs1 style="overflow: hidden; word-wrap: break-word; word-break: break-all; font-size: 16px; margin-top: 34px; margin-bottom: 10px; line-height: normal;"}

<span class="pleft" style="float: left;"><span class="blogsep"
style="margin: 0px 2px;">2011-01-15 21:18:21</span><span class="blogsep"
style="margin: 0px 2px;">|  分类：</span> [Python](http://s9899.blog.163.com/blog/#m=0&t=1&c=fks_084066092085088068085095084095087086087065086084094075 "Python"){.fc03
.m2a}</span><span class="pright fc07 ztag" style="float: right;"><span
class="blogsep" style="margin: 0px 2px;">|</span><span id="$_spanReport"
class="fc03 m2a"
style="cursor: pointer; color: rgb(170, 40, 40);">举报</span></span><span
class="pright fc07 ztag" style="float: right;"><span class="blogsep"
style="margin: 0px 2px;">|</span><span id="$_fontswitch"
class="zihao fc03"
style="color: rgb(170, 40, 40); position: relative; cursor: default;">字号</span></span><span
id="$_blog_subscribe" class="pright pnt fc03"
style="cursor: pointer; float: right; color: rgb(170, 40, 40);"><span
class="iblock icn0 icn0-919"
style="display: inline-block; zoom: 1; width: 20px; height: 20px; background-image: url(&quot;&quot;); background-position: -360px -380px; background-repeat: no-repeat;"> </span>[订阅](){.m2a}</span>

</div>

<div class="m-shareAndDownLoad"
style="height: 24px; line-height: 24px; margin-top: -8px;">

<div class="share-wrap pleft" style="float: left;">

<span id="$_shareBtn_lofter2" class="shareitm lofter f-bkicons"
title="分享到LOFTER"
style="background: url(&quot;&quot;) 0px -144px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer;"> </span><span
id="$_shareBtn_sinaweibo2" class="shareitm sinawb f-bkicons"
title="分享到新浪微博"
style="background: url(&quot;&quot;) 0px -192px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer;"> </span><span
id="$_shareBtn_qq2" class="shareitm qqzone f-bkicons"
title="分享到QQ空间"
style="background: url(&quot;&quot;) 0px -240px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer;"> </span><span
id="$_shareBtn_qqweibo2" class="shareitm qqweibo f-bkicons"
title="分享到腾讯微博"
style="background: url(&quot;&quot;) 0px -288px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer;"> </span>
<div id="$_shareBtn_weixin2" class="shareitm weixin f-bkicons"
title="分享到微信"
style="background: url(&quot;&quot;) 0px -336px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer; position: relative; zoom: 1;">

<div class="code2dimlayer fc06"
style="color: rgb(164, 164, 164); visibility: hidden; position: absolute; left: -22px; bottom: 28px; width: 242px; height: 113px; cursor: default; background: url(&quot;&quot;) 0px 0px no-repeat;">

![](Python返回数组（List）长度的方法_files/0.21600577048957348.png)
<div class="tips"
style="margin-top: 30px; margin-left: 108px; color: rgb(119, 119, 119);">

</div>

[](){.close}

</div>

</div>

<div id="$_shareBtn_yixin2" class="shareitm yixin f-bkicons"
title="分享到易信"
style="background: url(&quot;&quot;) 0px -384px no-repeat; float: left; width: 24px; height: 24px; padding: 0px 0px 0px 6px; cursor: pointer; position: relative; zoom: 1;">

<div class="code2dimlayer fc06"
style="color: rgb(164, 164, 164); visibility: hidden; position: absolute; left: -22px; bottom: 28px; width: 242px; height: 113px; cursor: default; background: url(&quot;&quot;) 0px 0px no-repeat;">

![](Python返回数组（List）长度的方法_files/0.5976118496619165.png)
<div class="tips"
style="margin-top: 30px; margin-left: 108px; color: rgb(119, 119, 119);">

</div>

[](){.close}

</div>

</div>

</div>

[  下载LOFTER](http://www.lofter.com/app?act=qbbkrzydb_20150408_01){.pright
.fc03 .noul}[我的照片书  |](http://yxp.163.com/){.pright .fc03 .noul}

</div>

</div>

<div
style="font-family: 'Hiragino Sans GB W3', 'Hiragino Sans GB', Arial, Helvetica, simsun, u5b8bu4f53; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(204, 206, 208);">

</div>

<div class="nbw-blog-start"
style="font-family: 'Hiragino Sans GB W3', 'Hiragino Sans GB', Arial, Helvetica, simsun, u5b8bu4f53; font-size: 12px; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(204, 206, 208);">

</div>

<div class="bct fc05 fc11 nbw-blog ztag"
style="line-height: 28px; font-size: 16px; word-wrap: break-word; margin-top: 15px; margin-bottom: 15px; padding: 5px 0px; overflow: hidden; font-family: 'Hiragino Sans GB W3', 'Hiragino Sans GB', Arial, Helvetica, simsun, u5b8bu4f53; font-variant-ligatures: normal; orphans: 2; widows: 2; background-color: rgb(204, 206, 208);">

　　其实很简单，用len函数：

&gt;&gt;&gt; array = \[0,1,2,3,4,5\]\
&gt;&gt;&gt; print len(array)\
6

　　同样，要获取一字符串的长度，也是用这个len函数，包括其他跟长度有关的，都是用这个函数。

　　Python这样处理，如同在print的结果中自动添加一个空格来解脱程序员一样，也是一个人性化的考虑，所以在比如字符串的属性和方法中，就不再用len了，这点要注意一下。

\
<div style="color:gray">

来源： <http://s9899.blog.163.com/blog/static/3062228820110159182166/>

</div>

</div>
