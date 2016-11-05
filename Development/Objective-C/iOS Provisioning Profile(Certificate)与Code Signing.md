iOS Provisioning Profile(Certificate)与Code Signing详解 -
曾梦想仗剑走天涯 - 博客频道 - CSDN.NET
<div>

\
<div style="font-size: 16px">

<div>

<div
style="font-size:12px;font-family:Arial, Console, Verdana, 'Courier New';background:url(&quot;&quot;) 50% 0% repeat;">

<div>

<div style="text-align:left;">

<div style="overflow:hidden;">

<div style="background:rgb(255, 255, 255);">

<div>

<div
style="display:block;margin:5px 0px;color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:20px;line-height:30px;font-family:'Microsoft YaHei';">

<span
style="display:inline-block;width:19px;height:19px;margin:0px 2px 0px 0px;vertical-align:middle;background:url(&quot;&quot;) 0px 0px no-repeat;"></span>
<span>[iOS Provisioning Profile(Certificate)与Code Signing详解](http://blog.csdn.net/phunxm/article/details/42685597)</span> {#ios-provisioning-profilecertificate与code-signing详解 style="font-weight:normal;margin:0px;padding:0px;font-style:normal;font-variant:normal;display:inline;font-stretch:normal;font-size:20px;line-height:30px;font-family:'Microsoft YaHei';vertical-align:middle;"}
============================================================================================================================

<span
style="color:rgb(0, 0, 0);font-style:normal;font-variant:normal;font-weight:normal;font-size:20px;line-height:30px;font-family:'Microsoft YaHei';display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="font-family:Arial;padding:0px 20px 5px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:12px;line-height:22px;color:rgb(153, 153, 153);text-align:right;display:block;border-bottom-style:solid;border-bottom-width:1px;border-bottom-color:rgb(237, 237, 237);margin:0px -20px;overflow:hidden;">

<div style="width:100%;float:left;">

<span style="margin:0px 5px;float:left;"> 标签：
[Certificate](http://www.csdn.net/tag/Certificate)[App\_ID](http://www.csdn.net/tag/App_ID)[Provisioning\_Profile](http://www.csdn.net/tag/Provisioning_Profile)[App\_Group](http://www.csdn.net/tag/App_Group)[CodeSigning](http://www.csdn.net/tag/CodeSigning)
</span>

</div>

<div>

<span style="margin:0px 5px 0px 0px;">2015-01-13 22:01</span> <span
title="阅读次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) 0% 50% no-repeat;">96814人阅读</span>
<span title="评论次数"
style="margin:0px 5px;padding:0px 0px 0px 14px;background:url(&quot;&quot;) 0% 50% no-repeat;">
[评论](http://blog.csdn.net/phunxm/article/details/42685597#comments)(16)</span>
<span style="margin:0px 5px;">
[举报](http://blog.csdn.net/phunxm/article/details/42685597#report "举报")</span>

</div>

<span
style="color:rgb(153, 153, 153);font-style:normal;font-variant:normal;font-weight:normal;font-size:12px;line-height:22px;font-family:Arial;text-align:right;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div
style="display:block;margin:0px -20px;border-bottom-style:solid;border-bottom-width:1px;border-bottom-color:rgb(237, 237, 237);padding:0px 20px;height:46px;">

<div style="display:inline-block;font-size:14px;color:rgb(51, 51, 51);">

![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/category_icon.jpg){width="15"
height="13"} <span
style="display:inline-block;vertical-align:middle;">分类：</span>

</div>

<div
style="display:inline-block;font-size:14px;color:rgb(223, 52, 52);">

<span
style="display:inline-block;margin-left:15px;cursor:pointer;line-height:46px;position:relative;">
<span>iOS*（8）*</span>
![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/1db119b0089be63f5674c35ec53f1d8f.jpg){width="10"
height="5"} </span>

</div>

<span
style="display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

<div style="padding:20px 0px;">

版权声明：本文为博主原创文章，未经博主允许不得转载。

</div>

<div style="clear:both;">

</div>

<div
style="border:solid 1px #ccc;background:#eee;float:left;min-width:200px;padding:4px 10px;">

<span
style="float:left;">目录[(?)](http://blog.csdn.net/phunxm/article/details/42685597# "系统根据文章中H1到H6标签自动生成文章目录")</span>[\[+\]](http://blog.csdn.net/phunxm/article/details/42685597# "展开")

</div>

<div style="clear:both;">

</div>

<div
style="margin:20px 0px 0px;font-style:normal;font-variant:normal;font-weight:normal;font-stretch:normal;font-size:14px;line-height:26px;font-family:Arial;">

[]()<span style="font-size:14px;"><span style="font-size:18px;color:rgb(153,51,102);">**<span style="font-family:Microsoft YaHei;">引言</span>**</span></span> {#引言 style="margin:0px;padding:0px;"}
==============================================================================================================================================================

<span style="font-family:Microsoft YaHei;"><span
style="font-size:14px;">        关于开发证书配置（Certificates &
Identifiers & Provisioning
Profiles），相信做iOS开发的同学没少被折腾。</span><span
style="font-size:14px;color:rgb(51,51,51);">对于一个iOS开发小白、半吊子（比如像我自己）抑或老兵，或多或少会有或曾有过以下不详、疑问、疑惑甚至困惑：</span></span>

> 1.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">什么是App
>     ID？Explicit/Wildcard App ID有何区别？<span
>     style="color:rgb(153,0,0);font-size:14px;">什么是App Group
>     ID？</span></span></span>
> 2.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">什么是证书（Certificate）？如何申请？有啥用？</span></span>
> 3.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">什么是Key
>     Pair（公钥/私钥）？有啥用？与证书有何关联？</span></span>
> 4.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">什么是签名（Signature）？如何签名（CodeSign）？怎样校验（Verify）？</span></span>
> 5.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">什么是（Team）Provisioning
>     Profiles？有啥用？</span></span>
> 6.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Xcode如何配置才能使用iOS真机进行开发调试？</span></span>
> 7.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">多台机器如何共享开发者账号或证书？</span></span>
> 8.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">遇到证书配置问题怎么办？</span></span>
> 9.  <span style="color:rgb(153,0,0);font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Xcode
>     7免证书调试真机调试</span></span>

> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">本文将围绕相关概念做个系统的梳理串烧。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">从 Xcode 7 开始支持普通 Apple
> 账号进行<span
> style="background-color:rgb(255,255,0);">免证书真机调试</span>，详情参考最新官方文档《Launching
> Your App on Devices》，或参考本文最后一节简介。</span></span>

[]()<span style="font-size:14px;"><span style="font-size:18px;color:rgb(153,51,102);">**<span style="font-family:Microsoft YaHei;">写在前面</span>**</span></span> {#写在前面 style="margin:0px;padding:0px;"}
==================================================================================================================================================================

> <span style="font-size:14px;"><span style="color:#333333;"><span
> style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(51,51,51);font-size:14px;">1.</span>假设你使用过</span><span
> style="font-size:14px;">Apple设备（iMac/iPad/iPhone）且**注册**过Apple
> ID（Apple Account）。</span>\
> </span></span></span></span>
>
> <span style="font-size:14px;"><span style="color:#333333;"><span
> style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">2.假设你或你所在的开发组已<span
> style="color:rgb(51,51,51);font-size:14px;">加入苹果开发者计划（Enroll
> in iOS Developer Program to become a
> [member](https://developer.apple.com/membercenter/index.action)），即已</span>**注册**开发者账号（Apple
> Developer Account）。</span></span></span></span>

> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(51,51,51);">只有拥有开发者账号，才可以</span><span
>     style="font-size:14px;color:rgb(51,51,51);">申请开发/发布</span><span
>     style="font-size:14px;color:rgb(51,51,51);">证书及相关配置授权文件，进而在iOS真机上开发调试Apps或发布到App
>     Store。</span></span>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;">开发者账号分为Individual和Company/Organization两种类型。如无特别交代，</span><span
>     style="font-size:14px;">下文基于\$99/Year的普通个人开发者（<span
>     style="color:rgb(51,51,51);">Individual）</span>账号<span
>     style="color:#333333;">展开</span></span><span
>     style="font-size:14px;">。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);font-size:14px;">3.若要真机调试实践，你必须至少拥有一台装有Mac
> OS X/<span
> style="color:rgb(51,51,51);font-size:14px;">Xcode</span>的Mac开发机（iMac
> or MacBook），其上自带原生的Keychain Access。</span>\
> </span></span>

[]()<span style="font-size:14px;"><span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**<span style="color:rgb(153,51,102);font-size:18px;">**一**</span>.App ID（**</span><span style="font-size:18px;">**bundle identifier）**</span></span></span> {#一.app-idbundle-identifier style="margin:0px;padding:0px;"}
================================================================================================================================================================================================================================================================================================

> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">App ID即Product
> ID，用于标识一个或者一组App。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">App ID应该和Xcode中的Bundle
> Identifier是一致（Explicit）的或匹配（Wildcard）的。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">App ID字符串通常以**<span
> style="color:#000099;">反域名</span>**（reverse-domain-name）格式的Company
> Identifier（Company
> ID）作为前缀（Prefix/Seed），一般不超过255个ASCII字符。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">App ID全名会被追加Application
> Identifier Prefix（一般为TeamID.），分为两类：</span></span>
>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(51,102,255);">Explicit App
>     ID</span><span style="font-size:14px;">：唯一的App
>     ID，用于唯一标识一个应用程序。例如“</span><span
>     style="font-size:14px;color:rgb(75,172,198);">com.apple.garageband</span><span
>     style="font-size:14px;">”这个App ID，用于标识Bundle
>     Identifier为“</span><span
>     style="font-size:14px;color:rgb(75,172,198);">com.apple.garageband</span><span
>     style="font-size:14px;">”的App。</span></span>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(51,102,255);">Wildcard App
>     ID</span><span style="font-size:14px;">：含有通配符的App
>     ID，用于标识一组应用程序。例如“\*”（实际上是Application Identifier
>     Prefix）表示所有应用程序；而“</span><span
>     style="font-size:14px;color:rgb(75,172,198);">com.apple.\*</span><span
>     style="font-size:14px;">”可以表示Bundle Identifier以“</span><span
>     style="font-size:14px;color:rgb(75,172,198);">com.apple.</span><span
>     style="font-size:14px;">”开头（苹果公司）的所有应用程序。</span></span>
>
> <div>
>
> <span style="font-size:14px;"><span style="color:rgb(51,51,51);"><span
> style="font-family:Microsoft YaHei;">用户可在Developer
> MemberCenter网站上注册（Register）或删除（Delete）已注册的App IDs。\
> </span></span></span>
>
> </div>
>
> <div>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);">App ID</span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(0,0,153);">**被配置到**</span></span><span
> style="color:rgb(51,51,51);">【</span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(153,0,0);">XcodeTarget|Info|Bundle
> Identifier</span></span><span
> style="color:rgb(51,51,51);">】下；对于Wildcard App ID，只要bundle
> identifier包含其作为Prefix/Seed即可。</span></span></span>
>
> </div>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**<span style="color:rgb(153,51,102);font-size:18px;">**二**</span>**</span><span style="font-size:18px;color:rgb(153,51,102);">**.设备（**</span><span style="font-size:18px;">**Device）**</span></span> {#二.设备device style="margin:0px;padding:0px;"}
=============================================================================================================================================================================================================================================================================================================

> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Device就是运行iOS系统用于开发调试App的设备。每台Apple设备使用**<span
> style="color:rgb(51,102,255);">UDID</span>**来唯一标识。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">iOS设备连接Mac后，可通过iTunes-&gt;Summary或者Xcode-&gt;Window-&gt;Devices获取iPhone的UDID（identifier）。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Apple Member
> Center网站个人账号下的**Devices**中包含了注册过的所有可用于开发和测试的设备，<span
> style="color:rgb(51,51,51);font-size:14px;">普通个人开发账号每年</span><span
> style="color:rgb(51,51,51);font-size:14px;">累计最多只能注册</span><span
> style="font-size:14px;"><span
> style="color:#ff6600;">**100**</span></span><span
> style="color:rgb(51,51,51);font-size:14px;">个设备。</span></span></span>
>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Apps signed by you or your
>     team run only on designated development devices.</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Apps run only on the test
>     devices you specify.</span></span>
>
> <div>
>
> <span style="font-size:14px;"><span style="color:rgb(51,51,51);"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="color:rgb(51,51,51);">用户可在网站上注册或</span>启用/禁用（Enable/Disable）已注册的Device。</span>\
> </span></span></span>
>
> </div>
>
> <div>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);">本文的Devices是指</span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(0,0,153);">**连接到**</span></span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(153,0,0);">Xcode</span></span><span
> style="color:rgb(51,51,51);">被授权用于开发测试的iOS设备（iPhone/iPad）。</span></span></span>
>
> </div>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**<span style="color:rgb(153,51,102);font-size:18px;">**三**</span>**</span><span style="font-size:18px;color:rgb(153,51,102);">**.开发证书（**</span><span style="font-size:18px;">**Certificates）**</span></span> {#三.开发证书certificates style="margin:0px;padding:0px;"}
=======================================================================================================================================================================================================================================================================================================================

> []()**<span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;font-size:14px;">1.证书的概念</span></span>** {#证书的概念 style="margin:0px;padding:0px;"}
> ------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:#000099;">**证书**</span>是由公证处或认证机关开具的证明资格或权力的<span
> style="color:#3333ff;">*证件*</span>，它是表明（或帮助断定）事理的一个<span
> style="color:#3333ff;">*凭证*</span>。证件或凭证的尾部通常会烙印<span
> style="color:#3366ff;">*公章*</span>。</span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">每个中国人一生可能需要70多个证件，含15种身份证明。证件中“必需的”有30到40个。将这些证件按时间顺序铺开，那就是一个天朝子民的一生——持<span>**准生证**</span>许可落地，以<span
> style="font-weight:bolder;">户籍证明</span>入籍，以<span
> style="font-weight:bolder;">身份证</span>认证身份，持<span
> style="font-weight:bolder;">结婚证</span>以合法同居，最终以<span>**死亡证**</span>明注销。</span>
>
> []()<span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;font-size:14px;">2.数字证书的概念</span></span> {#数字证书的概念 style="margin:0px;padding:0px;"}
> ------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:#3333ff;">***数字证书***</span>就是互联网通讯中**标志**通讯各方***身份信息***的一串数字，提供了一种在Internet上验证通信**实体身份**的方式，其作用类似于司机的驾驶执照或日常生活中的身份证。它是由一个由权威机构——**<span
> style="color:#663300;">CA机构</span>**，又称为证书授权中心<span
> style="font-family:'Microsoft YaHei';font-size:14px;">（Certificate
> Authority）</span>发行的，人们可以在网上用它来识别对方的身份。</span>
>
> -   <span
>     style="font-family:Microsoft YaHei;font-size:14px;">数字证书是一个经证书授权中心数字签名的包含<span
>     style="color:#ffcc33;">公开密钥拥有者</span>信息以及<span
>     style="color:#ffcc33;">公开密钥</span>的文件。最简单的证书包含一个公开密钥、名称以及证书授权中心的数字签名。</span>
> -   <span
>     style="font-family:Microsoft YaHei;font-size:14px;">数字证书还有一个重要的特征就是时效性：只在特定的时间段内有效。</span>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"></span>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">数字证书中的<span
> style="color:rgb(255,204,51);font-family:'Microsoft YaHei';font-size:14px;">公开密钥</span>（公钥）相当于<span
> style="color:#3366ff;">公章</span>。</span></span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">某一认证领域内的<span
> style="font-weight:bolder;"><span
> style="color:rgb(255,0,0);">根证书</span></span>是CA认证中心给自己颁发的证书，是信任链的<span
> style="color:#990000;">**起始点**</span>。安装根证书意味着对这个CA认证中心的信任。</span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">为了防止[GFW](http://bbs.3dmgame.com/thread-2356754-1-1.html)进行中间人攻击(MitM)，例如<span
> style="font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">篡改</span>[github](http://program-think.blogspot.com/2015/03/weekly-share-82.html)<span
> style="font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">证书</span>，导致无法访问github网站等问题，可选择不信任[CNNIC](http://bbs.kechuang.org/read/69655/1)：</span></span>
>
> -   <span
>     style="font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">在［钥匙串-系统］中</span><span
>     style="font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">双击[CNNIC
>     ROOT](http://www.williamlong.info/archives/4192.html)，在【信任】|【使用此证书时】下拉选择【永不信任】。</span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150815233732150.png){width="906"
> height="450"}\
> </span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">在天朝子民的一生中，户籍证明可理解为等效的根证书：有了户籍证明，才能办理身份证；有了上流的身份证，才能办理下游居住证、结婚证、计划生育证、驾驶执照等认证。</span>
>
> </div>
>
> []()<span style="font-family:Microsoft YaHei;font-size:14px;"><span style="color:rgb(204,0,0);">3.iOS</span><span style="color:rgb(204,0,0);">（开发）</span><span style="color:rgb(204,0,0);">证书</span></span> {#ios开发证书 style="margin:0px;padding:0px;"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">iOS证书是用来证明iOS
> App内容（executable
> code）的合法性和完整性的**数字证书**。对于想安装到真机或发布到AppStore的应用程序（App），只有经过**签名验证**（Signature
> Validated）才能确保来源可信，并且保证App内容是完整、未经篡改的。</span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:#333333;">iOS证书分为两类：</span><span
> style="color:#3366FF;">Development</span><span
> style="color:#333333;">和</span><span
> style="color:#3366FF;">Production（</span>Distribution）<span
> style="color:#333333;">。</span></span>
>
> -   <span style="font-family:Microsoft YaHei;font-size:14px;"><span
>     style="color:rgb(51,102,255);">Development</span>证书用来开发和调试应用程序：A <span><span
>     style="color:#ff0000;">***development
>     certificate***</span></span> identifies you, as a team member, in
>     a development provisioning profile that allows apps signed by you
>     to <span style="color:#3333ff;">***launch ***</span>on
>     devices. </span>
> -   <span style="font-family:Microsoft YaHei;font-size:14px;"><span
>     style="color:rgb(51,102,255);">Production</span>主要用来分发应用程序（根据证书种类有不同作用）：A <span><span
>     style="color:#ff0000;">***distribution
>     certificate***</span></span> identifies your team or organization
>     in a distribution provisioning profile and allows you to <span
>     style="color:#3333ff;">***submit  ***</span>your app to the store.
>     Only a team agent or an admin can create a
>     distribution certificate.</span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:rgb(51,51,51);">普通个人开发账号最多可注册iOS
> Development/Distribution证书各<span
> style="color:rgb(255,102,0);">2</span>个，用户可在网站上删除（Revoke）已注册的Certificate。</span></span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">下文主要针对iOS
> App开发调试过程中的开发证书（Certificate for Development）。</span>
>
> []()**<span style="color:#cc0000;"><span style="font-family:Microsoft YaHei;font-size:14px;">4.iOS（开发）证书的根证书</span></span>** {#ios开发证书的根证书 style="margin:0px;padding:0px;"}
> --------------------------------------------------------------------------------------------------------------------------------------
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">那么，iOS开发证书是谁颁发的呢？或者说我们是从哪个CA申请到用于Xcode开发调试App的证书呢？</span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;">iOS以及Mac
> OS X系统（在安装Xcode时）将自动安装[<span
> style="color:#e36c0a;">***AppleWWDRCA.cer***</span>](https://developer.apple.com/certificationauthority/AppleWWDRCA.cer)这个中间证书（**<span
> style="color:rgb(51,102,255);">Intermediate
> Certificates），</span>**它实际上就是iOS（开发）证书的证书，即<span
> style="color:#ff6666;">**根证书**</span>（Apple Root
> Certificate）。</span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">AppleWWDRCA（Apple
> Root
> CA）类似注册管理户籍的公安机关户政管理机构，AppleWWDRCA.cer之于iOS（开发）证书则好比户籍证之于身份证。\
> </span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;">如果Mac
> Keychain
> Access证书助理在申请证书时尚未安装过该证书，请先下载安装（Signing
> requires that you have both the signing identity and the intermediate
> certificate installed in your keychain）。</span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150114090911421.png){width="852"
> height="386"}\
> </span></span>
>
> []()<span style="font-family:Microsoft YaHei;font-size:14px;">**<span style="color:rgb(204,0,0);">5.</span>**<span style="color:rgb(204,0,0);">申请</span><span style="color:rgb(204,0,0);">证书</span><span style="color:rgb(204,0,0);">（CSR：Certificate Signing Request）</span></span> {#申请证书csrcertificate-signing-request style="margin:0px;padding:0px;"}
> -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;">可以在缺少证书时通过Xcode
> Fix
> Issue自动请求证书，这里</span>通过Keychain**证书助理**从证书颁发机构请求证书：填写开发账号邮件和常用名称，勾选【存储到磁盘】。</span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150412073437711.png){width="906"
> height="682"}\
> </span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">keychain将生成一个包含开发者<span
> style="color:#3366ff;">身份信息</span>的**<span
> style="color:rgb(227,108,10);">CSR</span>**（Certificate Signing
> Request）文件；同时，Keychain
> Access|Keys中将新增一对Public/Private <span
> style="color:rgb(227,108,10);">**Key Pair**</span>（This <span>signing
> identity</span> consists of a public-private key pair that Apple
> issues）。</span>
>
> <span style="font-size:14px;"><span style="font-size:13px;"><span
> style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150114091003101.png){width="854"
> height="422"}\
> </span></span></span></span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:rgb(204,102,0);">***private key***</span>始终保存在Mac
> OS的Keychain Access中，<span
> style="font-family:'Microsoft YaHei';font-size:14px;">用于签名（CodeSign）对外发布的App</span>；***<span
> style="color:#cc6600;">public key</span>***一般随证书（随Provisioning
> Profile，随App）散布出去，对App签名进行校验认证。用户必须保护好本地Keychain中的private
> key，以防伪冒。</span>
>
> -   <span style="font-family:Microsoft YaHei;font-size:14px;">Keep a
>     secure backup of your public-private key pair. If the private key
>     is lost, you’ll have to create an <span
>     style="color:#993300;">***entirely new***</span> identity to sign
>     code. </span>
> -   <span style="font-family:Microsoft YaHei;font-size:14px;">Worse,
>     if someone else has your private key, that person may be able
>     to <span
>     style="color:#660000;">***impersonate ***</span>you.</span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:14px;">在Apple开发网站上传该CSR文件来添加证书（Upload
> CSR file to generate your certificate）：</span>
>
> ![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150412073807017.png){width="906"
> height="626"}
>
> <span style="font-family:'Microsoft YaHei';font-size:14px;"></span>
>
> <span
> style="font-family:'Microsoft YaHei';font-size:14px;">Apple证书颁发机构WWDRCA[<span
> style="color:rgb(0,0,0);">*(Apple Worldwide Developer Relations
> Certification
> Authority)*</span>](https://developer.apple.com/certificationauthority/AppleWWDRCA.cer)将使用private
> key对CSR中的public key和一些身份信息进行加密签名生成**<span
> style="color:rgb(227,108,10);">数字证书</span>**（ios\_development.cer）并记录在案（Apple
> Member Center）。</span>
>
> <span
> style="font-family:'Microsoft YaHei';font-size:14px;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150412074512682.png){width="906"
> height="875"}\
> </span>
>
> <span
> style="font-family:'Microsoft YaHei';font-size:14px;">从Apple Member
> Center网站下载证书到Mac上双击即可安装（当然也可在Xcode中添加开发账号自动同步证书和\[生成\]配置文件）。证书安装成功后，在KeychainAccess|Keys中展开创建CSR时生成的Key
> Pair中的私钥前面的箭头，可以查看到包含其对应公钥的证书（Your requested
> certificate will be the public half of the key pair.）；在Keychain
> Access|Certificates中展开安装的证书（ios\_development.cer）前面的箭头，可以看到其对应的私钥。</span>
>
> <span style="font-size:14px;"><span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150114091138343.png){width="855"
> height="438"}\
> </span></span></span>
>
> <span style="font-size:14px;"><span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150114091440719.png){width="854"
> height="348"}\
> </span></span></span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:rgb(51,51,51);">Certificate</span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(0,0,153);">**被配置到**</span></span><span
> style="color:rgb(51,51,51);">【</span><span
> style="color:rgb(51,51,51);"><span
> style="color:rgb(153,0,0);">Xcode Target|Build Settings|Code
> Signing|Code Signing Identity</span></span><span
> style="color:rgb(51,51,51);">】下，下拉选择Identities from Profile
> "..."（一般先配置<span style="color:rgb(153,0,0);">Provisioning
> Profile</span>）。以下是Xcode配置示例：</span></span>
>
> <span style="font-family:Microsoft YaHei;font-size:14px;"><span
> style="color:rgb(51,51,51);">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150422073707077.png){width="906"
> height="545"}\
> </span></span>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**四**</span><span style="font-size:18px;color:rgb(153,51,102);">**.供应配置文件（**</span>[<span style="color:#336699;">Provisioning Profiles</span>](https://developer.apple.com/library/ios/documentation/IDEs/Conceptual/AppDistributionGuide/MaintainingCertificates/MaintainingCertificates.html)<span style="font-size:18px;">**）**</span></span> {#四.供应配置文件provisioning-profiles style="margin:0px;padding:0px;"}
============================================================================================================================================================================================================================================================================================================================================================================================================================================================

> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">1.Provisioning Profile的概念</span></span></span> {#provisioning-profile的概念 style="margin:0px;padding:0px;"}
> ----------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Provisioning
> Profile文件包含了上述的所有内容：**<span
> style="color:#006600;">证书、App ID</span>和<span
> style="color:#006600;">设备</span>**。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150126225313444.png){width="618"
> height="377"}\
> </span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">一个Provisioning Profile对应一个Explicit App
> ID或Wildcard App ID（<span
> style="font-size:14px;">一组相同Prefix/Seed的</span></span><span
> style="font-size:14px;">App IDs</span><span
> style="font-size:14px;">）。在网站上手动创建一个Provisioning
> Profile时，需要依次指定App
> ID（单选）、证书（Certificates，可多选）和设备（Devices，可多选）。用户可在网站上删除（Delete）已注册的Provisioning
> Profiles。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">Provisioning
> Profile</span>决定Xcode用哪个证书（公钥）/私钥组合（Key Pair/Signing
> Identity）来签署应用程序（Signing
> Product）,将在应用程序打包时嵌入到.ipa包里。安装应用程序时，Provisioning
> Profile文件被拷贝到iOS设备中，运行该iOS
> App的设备也通过它来认证安装的程序。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">如果要打包或者在真机上运行一个APP，一般要经历以下三步：</span></span>
>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;"><span
>     style="color:#993366;">首先</span><span
>     style="font-size:14px;">，<span
>     style="font-family:'Microsoft YaHei';font-size:14px;">需要指明它的App
>     ID，并且验证Bundle ID是否与其一致；</span></span></span></span>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(153,51,102);">其次</span><span
>     style="font-size:14px;">，<span
>     style="font-family:'Microsoft YaHei';font-size:14px;">需要证书对应的私钥来进行签名，用于标识这个APP是合法、安全、完整的；</span></span></span>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(153,51,102);">然后</span><span
>     style="font-size:14px;">，如果是真机调试，需要确认这台设备是否授权运行该APP。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Provisioning
> Profile把这些信息全部打包在一起，方便我们在调试和发布程序打包时使用。这样，只要在不同的情况下选择不同的Provisioning
> Profile文件就可以了。</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">Provisioning
> Profile也分为Development和Distribution两类，有效期同Certificate一样。</span><span
> style="font-size:14px;">Distribution版本的ProvisioningProfile主要用于提交App
> Store审核，其中不指定开发测试的Devices（0，unlimited）。App
> ID为Wildcard App ID（\*）。App
> Store审核通过上架后，允许所有iOS设备（Deployment
> Target）上安装运行该App。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);">Xcode将全部供应配置文件（包括用户手动下载安装的和</span>Xcode自动创建的Team
> Provisioning Profile）放在目录[<span
> style="color:#336699;">\~/Library/MobileDevice/Provisioning
> Profiles</span>](http://blog.csdn.net/iamfreedom2011/article/details/22160853)下。</span></span>
>
> []()<span style="font-family:Microsoft YaHei;"><span style="font-size:14px;"><span style="color:rgb(204,0,0);">2.</span></span><span style="color:rgb(204,0,0);font-size:14px;">Provisioning Profile</span><span style="font-size:14px;"><span style="color:rgb(204,0,0);">的构成</span></span></span> {#provisioning-profile的构成 style="margin:0px;padding:0px;"}
> ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="color:#ff6666;"><span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">以下为典型供应配置文件\*.mobileprovision的**构成简析**：</span></span></span>

> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">1）</span>***<span
> > style="color:#E36C0A;">Name</span>***<span
> > style="color:#333333;">：该</span><span
> > style="color:#333333;">mobileprovision的文件名。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">2）</span>***<span
> > style="color:#E36C0A;">UUID</span>***<span
> > style="color:#333333;">：该</span><span
> > style="color:#333333;">mobileprovision文件的真实文件名。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">3）</span>***<span
> > style="color:#E36C0A;">TeamName</span>***<span
> > style="color:#333333;">：</span><span style="color:#333333;">Apple
> > ID账号名。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">4）</span>***<span
> > style="color:#E36C0A;">TeamIdentifier</span>***<span
> > style="color:#333333;">：</span><span style="color:#333333;">Team
> > Identity。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">5）</span>***<span
> > style="color:#E36C0A;">AppIDName</span>***<span
> > style="color:#333333;">：</span><span
> > style="color:#333333;">explicit/wildcard App ID
> > name（</span>ApplicationIdentifierPrefix）。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">6）</span>***<span
> > style="color:#E36C0A;">ApplicationIdentifierPrefix</span>***<span
> > style="color:#333333;">：完整</span><span style="color:#333333;">App
> > ID的前缀（</span>TeamIdentifier.\*）。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">7）</span>***<span
> > style="color:#E36C0A;">DeveloperCertificates</span>***<span
> > style="color:#333333;">：包含了可以为使用该配置文件应用签名的所有证书</span><span
> > style="color:#333333;">&lt;data&gt;&lt;array&gt;。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">证书是基于</span><span
> > style="color:#333333;">Base64编码，符合</span>PEM(PrivacyEnhanced
> > Mail, RFC 1848)格式的，可使用OpenSSL来处理（opensslx509 -text -in
> > file.pem）。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">从</span><span
> > style="color:#333333;">DeveloperCertificates提取</span>&lt;data&gt;&lt;/data&gt;之间的内容到文件cert.cer（cert.perm）：</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="color:green;"><span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">-----BEGIN
> > CERTIFICATE-----</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:green;">将</span><span
> > style="color:green;">&lt;data&gt;&lt;/data&gt;之间的内容拷贝至此</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="color:green;"><span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">-----END
> > CERTIFICATE-----\`</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">Mac下右键</span>QuickLook查看cert.cer（cert.perm），在Keychain
> > Access中右键Get
> > Info查看对应证书ios\_development.cer，正常情况（公私钥KeyPair配对）应吻合；Windows下没有足够信息（WWDRCA.cer），无法验证该证书。</span></span>
>
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">如果你用了一个不在这个列表中的证书进行签名，无论这个证书是否有效，这个应用都将</span><span
> > style="color:#333333;">CodeSign Fail。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">8）</span>***<span
> > style="color:#E36C0A;">Entitlements</span>***<span
> > style="color:#333333;">键</span><span
> > style="color:#333333;">&lt;key&gt;对应的</span>&lt;dict&gt;：</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">**<span
> > style="color:#31849B;">keychain-access-groups</span>**<span
> > style="color:#333333;">：</span><span
> > style="color:#333333;">\$(AppIdentifierPrefix)，参见</span>***Code
> > Signing Entitlements***(\*.entitlements)。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">每个应用程序都有一个可以用于安全保存一些如密码、认证等信息的</span>**<span
> > style="color:blue;">[keychain](http://blog.k-res.net/archives/1081.html "View all posts in keychain")</span>**<span
> > style="color:#333333;">，一般而言自己的程序只能访问自己的</span><span
> > style="color:#333333;">keychain。通过对应用签名时的一些设置，还可以利用</span>keychain的方式实现同一开发者签证（就是相同bundle
> > seed）下的不同应用之间共享信息的操作。比如你有一个开发者帐户，并开发了两个不同的应用A和B，然后通过对A和B的keychain
> > access
> > group这个东西指定共用的访问分组，就可以实现共享此keychain中的内容。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">**<span
> > style="color:#31849B;">application-identifier</span>**<span
> > style="color:#333333;">：带前缀的全名，例如</span><span
> > style="color:#333333;">\$(AppIdentifierPrefix)com.apple.garageband。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">**<span
> > style="color:#31849B;">com.apple.security.application-groups</span>**<span
> > style="color:#333333;">：</span><span style="color:#333333;">App
> > Group ID（</span>group. com.apple），参见***Code Signing
> > Entitlements***(\*.entitlements)。</span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;">**<span
> > style="color:#31849B;">com.apple.developer.team-identifier</span>**<span
> > style="color:#333333;">：同</span><span style="color:#333333;">Team
> > Identifier。</span></span></span>
>
> > <span style="font-family:Microsoft YaHei;"><span
> > style="font-size:12px;"></span></span>
> >
> > <span style="font-size:12px;"><span
> > style="font-family:Microsoft YaHei;"><span
> > style="color:#333333;">（</span><span
> > style="color:#333333;">9）</span>***<span
> > style="color:#E36C0A;">ProvisionedDevices</span>***<span
> > style="color:#333333;">：该</span><span
> > style="color:#333333;">mobileprovision授权的开发设备的</span>UDID
> > &lt;array&gt;。</span></span>

> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);">Provisioning
> Profile</span><span style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(0,0,153);">**被配置到**</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">【</span><span
> style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(153,0,0);">Xcode<span
> style="color:rgb(153,0,0);font-size:14px;">Target</span>|Build
> Settings|Code Signing|Provisioning Profile</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">】下，然后在<span
> style="color:rgb(153,0,0);font-size:14px;">Code Signing
> Identity</span>下拉可选择<span
> style="color:rgb(51,51,51);font-size:14px;">Identities from Profile
> "..."（即Provisioning Profile中包含的Certificates）</span>。</span>\
> </span></span>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**五**</span><span style="font-size:18px;color:rgb(153,51,102);">**.开发组供应配置文件（**</span>[<span style="color:#336699;">Team Provisioning Profiles</span>](https://developer.apple.com/library/ios/documentation/IDEs/Conceptual/AppStoreDistributionTutorial/CreatingYourTeamProvisioningProfile/CreatingYourTeamProvisioningProfile.html)<span style="font-size:18px;">**）**</span></span> {#五.开发组供应配置文件team-provisioning-profiles style="margin:0px;padding:0px;"}
=======================================================================================================================================================================================================================================================================================================================================================================================================================================================================================================

> []()<span style="font-family:Microsoft YaHei;"><span style="font-size:14px;"><span style="color:rgb(204,0,0);">1.Team </span></span><span style="color:rgb(204,0,0);font-size:14px;">Provisioning Profile</span><span style="font-size:14px;"><span style="color:rgb(204,0,0);">的概念</span></span></span> {#teamprovisioning-profile的概念 style="margin:0px;padding:0px;"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">每个Apple开发者账号都对应一个唯一的<span
> style="color:rgb(51,51,51);font-size:14px;line-height:21px;text-align:right;background-color:rgb(249,249,249);">**Team
> ID，**</span>Xcode3.2.3预发布版本中加入了Team Provisioning
> Profile这项新功能。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">在Xcode中添加Apple Developer
> Account时，它将与Apple Member Center后台勾兑<span
> style="color:#ff0000;">**自动生成**</span>iOS Team Provisioning
> Profile（<span style="color:#000099;">Managed by
> Xcode</span>）。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150113233612875.png){width="897"
> height="447"}\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Team Provisioning
> Profile包含一个为<span style="color:fuchsia;">Xcode iOS Wildcard App
> ID(\*)</span>生成的<span style="color:#FF9900;">iOS Team Provisioning
> Profile:\*</span>（匹配所有应用程序），账户里所有的Development
> Certificates和Devices都可以使用它在这个team注册的所有设备上调试所有的应用程序（不管bundle
> identifier是什么）。同时，它还会为开发者自己创建的Wildcard/Explicit
> App IDs创建对应的iOS Team Provisioning Profile。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150126225425594.png){width="712"
> height="406"}\
> </span></span>
>
> []()<span style="font-family:Microsoft YaHei;"><span style="font-size:14px;"><span style="color:rgb(204,0,0);">2.Team </span></span><span style="color:rgb(204,0,0);font-size:14px;">Provisioning Profile生成/更新时机</span></span> {#teamprovisioning-profile生成更新时机 style="margin:0px;padding:0px;"}
> ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Add an Apple ID account to
>     Xcode</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Fix issue "No Provisioning
>     Profiles with a valid signing identity" in Xcode</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Assign Your App to a Team in
>     Xcode project settings of General|Identity</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Register new device on the
>     apple development website or Xcode detected new device
>     connected</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">利用Xcode生成和管理的iOS Team
> Provisioning
> Profile来进行开发非常方便，可以不需要上网站手动生成下载Provisioning
> Profile。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);">Team Provisioning
> Profile同Provisioning
> Profile，只不过是由Xcode自动生成的，也</span><span
> style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(0,0,153);">**被配置到**</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">【</span><span
> style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(153,0,0);">Xcode<span
> style="color:rgb(153,0,0);font-size:14px;">Target</span>|Build
> Settings|Code Signing|Provisioning Profile</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">】下。</span>\
> </span></span>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**六**</span><span style="font-size:18px;color:rgb(153,51,102);">**.App Group （ID）**</span></span> {#六.app-group-id style="margin:0px;padding:0px;"}
=======================================================================================================================================================================================================

> []()<span style="font-family:Microsoft YaHei;"><span style="font-size:14px;"><span style="color:rgb(204,0,0);">1.App Group</span></span><span style="font-size:14px;"><span style="color:rgb(204,0,0);">的概念</span></span></span> {#app-group的概念 style="margin:0px;padding:0px;"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);">WWDC14除了发布了</span>OS X
> v10.10和switf外，iOS
> 8.0也开始变得更加开放了。说到开放，当然要数应用扩展（[App
> Extension](http://blog.csdn.net/phunxm/article/details/42715145)）了。顾名思义，应用扩展允许开发者扩展应用的自定义功能和内容，能够让用户在使用其他应用程序时使用该项功能，从而实现各个应用程序间的功能和资源共享。可以将扩展理解为一个轻量级（nimble
> and lightweight）的分身。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">扩展和其Containing
> App各自拥有自己的沙盒，虽然扩展以插件形式内嵌在Containing
> App中，但是它们是独立的二进制包，不可以互访彼此的沙盒。<span
> style="color:#333333;">为了实现</span><span
> style="color:#333333;">Containing
> App与扩展的数据共享，苹果在</span>iOS 8中引入了一个新的概念——App
> Group，它主要用于同一Group下的APP实现数据共享，具体来说是通过以App
> Group ID标识的共享资源区——App Group Container。</span></span>
>
> <span style="font-size:14px;"><span style="font-size:14px;"><span
> style="color:rgb(51,51,51);font-size:14px;"><span
> style="color:rgb(51,51,51);font-size:14px;"><span
> style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span style="font-size:14px;">App
> Group ID同App
> ID一样，一般不超过255个ASCII字符。</span>用户可在网站上编辑Explicit
> App IDs的App Group Assignment；可以删除（Delete）已注册的AppGroup
> （ID）。</span></span></span></span></span></span>
>
> []()<span style="font-family:Microsoft YaHei;"><span style="font-size:14px;"><span style="color:rgb(204,0,0);">2.App Group</span></span><span style="font-size:14px;"><span style="color:rgb(204,0,0);">的配置</span></span></span> {#app-group的配置 style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span style="font-size:14px;"><span
> style="color:rgb(51,51,51);font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:rgb(51,51,51);font-size:14px;">Containing
> App与Extension的Explicit App ID必须Assign到</span><span
> style="font-size:14px;"><span style="color:#ff0000;">同一App
> Group</span><span style="color:#333333;">下才能实现数据共享，<span
> style="font-size:14px;"><span
> style="color:#333333;">并且</span></span><span
> style="font-size:14px;">Containing App与Extension的App
> ID命名必须符合规范：</span></span></span></span></span></span></span>
>
> 1.  <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;color:rgb(51,51,51);">置于同一</span><span
>     style="font-size:14px;color:rgb(51,51,51);">App
>     Group下的</span><span style="font-size:14px;"><span
>     style="color:#333333;">App IDs必须是</span><span
>     style="color:#ff0000;">唯一</span><span
>     style="color:#333333;">的（Explicit，not
>     Wildcard）</span></span></span>
> 2.  <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">Extension App ID以Containing
>     App ID为Prefix/Seed</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">假如Garageband这个App ID为“</span><span
> style="font-size:14px;color:rgb(75,172,198);">com.apple.garageband</span><span
> style="font-size:14px;">”，则</span><span
> style="font-size:14px;color:rgb(51,51,51);">支持从语音备忘录导入到</span><span
> style="font-size:14px;color:rgb(51,51,51);">Garageband应用的插件的</span><span
> style="font-size:14px;">App ID可能形如“</span><span
> style="font-size:14px;color:rgb(75,172,198);">com.apple.garageband.***extImportRecording***</span><span
> style="font-size:14px;">”</span><span
> style="font-size:14px;color:rgb(51,51,51);">。</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);"></span></span>
>
> **<span style="color:maroon;"><span
> style="font-family:Microsoft YaHei;"> </span></span>**
>
> **<span style="color:maroon;"><span
> style="font-family:Microsoft YaHei;">App(ex)</span></span>**
>
> **<span style="color:maroon;"><span
> style="font-family:Microsoft YaHei;"> </span></span>**
>
> **<span style="color:maroon;"><span
> style="font-family:Microsoft YaHei;">App Group ID</span></span>**
>
> **<span style="color:maroon;"><span
> style="font-family:Microsoft YaHei;">Provisioning
> Profile</span></span>**
>
> **<span style="color:#C0504D;"><span
> style="font-family:Microsoft YaHei;">Code Signing
> Identity</span></span>**
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">（</span><span
> style="color:#E36C0A;">Certificate Key Pair</span><span
> style="color:#333333;">）</span></span>
>
> **<span style="color:#C0504D;"><span
> style="font-family:Microsoft YaHei;">App ID</span></span>**
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">（</span><span style="color:#E36C0A;">bundle
> identifier</span><span style="color:#333333;">）</span></span>
>
> **<span style="color:#C0504D;"><span
> style="font-family:Microsoft YaHei;">Devices</span></span>**
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">（</span><span
> style="color:#E36C0A;">test</span><span
> style="color:#333333;">）</span></span>
>
> ***<span style="color:blue;"><span
> style="font-family:Microsoft YaHei;">GarageBand</span></span>***
>
> <span style="color:#333333;"><span
> style="font-family:Microsoft YaHei;">置于同一分组：</span></span>
>
> <span style="color:fuchsia;"><span
> style="font-family:Microsoft YaHei;">group.com.apple</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">（</span><span
> style="color:#333333;">1）共用同一证书：</span><span
> style="color:#31849B;">ios\_development.cer</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">（</span><span
> style="color:#333333;">2）共用证书</span>Key Pair中的<span
> style="color:#31849B;">Private Key</span><span
> style="color:#333333;">进行</span><span
> style="color:#333333;">CodeSign</span></span>
>
> <span style="color:fuchsia;"><span
> style="font-family:Microsoft YaHei;">com.apple.garageband</span></span>
>
> **<span style="font-family:Microsoft YaHei;"><span
> style="color:#C0504D;">授权开发测试设备的</span><span
> style="color:#C0504D;">UDIDs</span></span>**
>
> ***<span style="font-family:Microsoft YaHei;"><span
> style="color:blue;">GarageBand</span><span
> style="color:#3366FF;">扩展插件</span></span>***
>
> <span style="font-family:Microsoft YaHei;"><span
> style="color:fuchsia;">com.apple.garageband.</span>***<span
> style="color:#D99594;">extImportRecording</span>***</span>
>
> <span style="font-size:14px;color:rgb(51,51,51);"><span
> style="font-family:Microsoft YaHei;">关于Provisioning
> Profile，可以使用自己手动生成的，也可以使用Xcode自动生成的Team
> Provisioning Profile。\
> </span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);">App Group会</span><span
> style="font-size:14px;"><span
> style="color:#000099;">**被配置到**</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">【</span><span
> style="font-size:14px;"><span style="color:#990000;">Xcode Target<span
> style="color:rgb(153,0,0);font-size:14px;">|Build
> Settings</span>|<span style="font-size:14px;">Code Signing|</span>Code
> Signing Entitlements</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">】文件<span
> style="color:rgb(51,51,51);font-size:14px;">（\*.entitlements）</span>的键</span><span
> style="font-size:14px;"><span
> style="color:#ff6666;">com.apple.security.application-groups</span></span><span
> style="font-size:14px;color:rgb(51,51,51);">下，不影响Provisioning
> Profile生成流程。</span></span>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**七**</span><span style="font-size:18px;color:rgb(153,51,102);">**.[证书与签名](https://developer.apple.com/library/mac/documentation/Security/Conceptual/CodeSigningGuide/CodeSigningGuide.pdf)（**</span><span style="font-size:18px;">**Certificate& Signature）**</span></span> {#七.证书与签名certificate-signature style="margin:0px;padding:0px;"}
=======================================================================================================================================================================================================================================================================================================================================================================================

> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">1.Code Signing Identity</span></span></span> {#code-signing-identity style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150126225508120.png){width="696"
> height="471"}\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150113233322156.png){width="906"
> height="560"}</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';"></span></span>
>
> <span>Xcode中配置的Code Signing
> Identity（entitlements、certificate）必须与<span
> style="font-family:'Microsoft YaHei';font-size:14px;">Provisioning
> Profile匹配，<span
> style="font-family:'Microsoft YaHei';font-size:14px;">并且配置的Certificate必须在本机Keychain
> Access中存在对应Public／Private Key
> Pair，</span>否则编译会报错。</span></span>
>
> <span style="font-size:14px;"><span
> style="color:rgb(255,102,102);"><span
> style="font-family:'Microsoft YaHei';">Xcode所在的Mac设备（系统）使用CA证书（WWDRCA.cer）来判断Code
> Signing Identity中Certificate的合法性：</span></span></span>
>
> -   <span style="font-size:14px;"><span
>     style="font-family:'Microsoft YaHei';">若用WWDRCA公钥能成功解密出证书并得到公钥（Public
>     Key）和内容摘要（Signature），证明此证书确乃AppleWWDRCA发布，即证书来源可信；</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:'Microsoft YaHei';">再对证书本身使用哈希算法计算摘要，若与上一步得到的摘要一致，则证明此证书未被篡改过，即证书完整。</span></span>
>
> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">2.Code Signing</span></span></span> {#code-signing style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> --------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">每个证书（其实是公钥）对应Key
> Pair中的**<span
> style="color:#FF6600;">私钥</span>**会被用来对内容（<span
> style="font-size:13px;">executable code，resources such as images and
> nib files aren’t signed</span>）进行数字**<span
> style="color:#FF6600;">签名</span>**（CodeSign）——使用哈希算法生成内容**<span
> style="color:#FF6600;">摘要</span>**（digest）。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">Xcode使用指定证书配套的私钥进行签名时需要授权，选择【始终允许】后，以后使用该私钥进行签名便不会再弹出<span
> style="font-family:'Microsoft YaHei';font-size:14px;">授权</span>确认窗口。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150412080540635.png){width="906"
> height="514"}\
> </span></span>
>
> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">3.Verify Code Signature with Certificate</span></span></span> {#verify-code-signature-with-certificate style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;">上面已经提到，公钥被包含在数字证书里，数字证书又被包含在描述文件(Provisioning
> File)中，描述文件在应用被安装的时候会被拷贝到iOS设备中。</span></span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;">第一步，App在Mac／iOS真机上启动时，需要对配置的bundle
> ID、entitlements和certificate与Provisioning
> Profile进行匹配校验：</span>\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">![](iOS%20Provisioning%20Profile(Certificate)与Code%20Signing_files/20150126225634296.png){width="697"
> height="573"}\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">第二步，iOS/Mac真机上的ios\_development.cer被AppleWWDRCA.cer中的
> public key解密校验合法后，获取每个开发证书中可信任的<span
> style="color:olive;">公钥</span>对App的可靠性和完整性进行校验。</span></span>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"></span></span>
> <span style="font-size:14px;"><span
> style="color:rgb(255,102,102);"><span style="font-weight:bold;"><span
> style="font-family:Microsoft YaHei;">iOS/Mac设备（系统）使用App
> Provisioning Profile<span
> style="color:rgb(255,102,102);font-size:14px;">**（Code Signing
> Identity）<span
> style="color:rgb(255,102,102);font-size:14px;">**中的开发证书**</span>**</span>来判断App的合法性：</span></span></span></span>
>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">若用证书公钥能成功解密出App（executable
>     code）的内容摘要<span
>     style="font-size:14px;">（Signature）</span>，证明此App确乃认证开发者发布，即来源可信；</span></span>
> -   <span style="font-size:14px;"><span
>     style="font-family:Microsoft YaHei;">再对App<span
>     style="font-size:14px;">（executable
>     code）</span>本身使用哈希算法计算摘要，若与上一步得到的摘要一致，则证明此<span
>     style="font-size:14px;">App</span><span
>     style="font-size:14px;">（executable
>     code）</span>未被篡改过，即内容完整。</span></span>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;color:#3333ff;"><span
> style="font-size:14px;">**小结：**</span></span>
>
> </div>
>
> <div>
>
> -   <span
>     style="font-size:14px;font-family:'Microsoft YaHei';">基于Provisioning
>     Profile校验了CodeSign的一致性；</span>
> -   <span
>     style="font-size:14px;font-family:'Microsoft YaHei';">基于Certificate校验App的可靠性和完整性；</span>
> -   <span
>     style="font-size:14px;font-family:'Microsoft YaHei';">启动时，真机的device
>     ID（UUID）必须在Provisioning Profile的</span><span
>     style="font-size:14px;font-family:'Microsoft YaHei';color:rgb(227,108,10);">***ProvisionedDevices***</span><span
>     style="font-size:14px;font-family:'Microsoft YaHei';">授权之列。</span>
>
> </div>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';"></span></span></span>
>
> </div>
>
> </div>

[]()<span style="font-family:Microsoft YaHei;"><span style="font-size:18px;color:rgb(153,51,102);">**八**</span><span style="font-size:18px;color:rgb(153,51,102);">**.在多台机器上**</span><span style="color:rgb(153,51,102);font-size:18px;">共享</span><span style="font-size:18px;color:rgb(153,51,102);">**开发账户/证书**</span></span> {#八.在多台机器上共享开发账户证书 style="margin:0px;padding:0px;"}
==============================================================================================================================================================================================================================================================================================================================================

> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">1.Xcode导出开发者账号(\*.developerprofile)或[PKCS12文件(\*.p12)](http://certhelp.ksoftware.net/support/solutions/articles/17251-what-is-a-p12-file-or-a-pkcs12-file-)</span></span></span> {#xcode导出开发者账号.developerprofile或pkcs12文件.p12 style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">进入Xcode
> Preferences|Accounts：</span></span>
>
> -   <span style="font-family:'Microsoft YaHei';"><span
>     style="font-size:14px;">选中Apple
>     IDs列表中对应Account的的Email，点击+-之后的☸|Export
>     Accounts，可导出包含account/code signing identity/provisioning
>     profiles信息的\*.**<span
>     style="color:#FF6600;">developerprofile</span>**（Exporting a
>     Developer Profile）</span><span
>     style="font-size:14px;">文件供其他机器上的Xcode开发使用（Import该Account）。</span></span>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;">选中右下列表中某行Account
> Name条目|ViewDetails，可以查看Signing Identities和Provisioning
> Profiles。</span>\
> </span></span>
>
> </div>
>
> -   <span style="font-family:Microsoft YaHei;"><span
>     style="font-size:14px;">选中欲导出的Signing
>     Identity条目，点击栏底+之后的☸|Export，必须输入密码，并需授权export
>     key "privateKey" from keychain，将导出</span><span
>     style="font-size:14px;">**<span
>     style="color:#ff6600;"></span><span
>     style="font-size:14px;">**<span
>     style="color:rgb(255,102,0);">Certificates.[p12](http://appfurnace.com/2015/01/how-do-i-make-a-p12-file/)</span>**</span><span
>     style="font-size:14px;">**。**</span>**</span></span>
>
> <div>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">点击左下角的刷新按钮可从Member
> Center同步该账号下所有的Provisioning Profile到本地。\
> 选中右击列表中某个Provisioning Profile可以【Show in
> Finder】到\[\~/Library/MobileDevice/Provisioning\\
> Profiles\]目录，其中Provisioning
> Profile的真实名称为\$(UUID).mobileprovision，名如"2488109f-ff65-442e-9774-fd50bd6bc827.mobileprovision"，其中&lt;key&gt;Name&lt;/key&gt;中为Xcode中看到的描述性别名。</span>\
> </span>
>
> </div>
>
> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">2.Keychain Access导出</span></span></span><span style="font-family:'Microsoft YaHei';color:rgb(204,0,0);font-size:14px;">[PKCS12](http://blog.csdn.net/kmyhy/article/details/6431609)文件</span><span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">(\*.[p12](http://help.adobe.com/zh_CN/as3/iphone/WS144092a96ffef7cc-371badff126abc17b1f-7fff.html))</span></span></span> {#keychain-access导出pkcs12文件.p12 style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">**在Keychain
> Access|Certificates中选中欲导出的certificate或其下private
> key，右键Export或者通过菜单File|Export Items导出**</span><span
> style="font-size:14px;"><span
> style="color:#ff6600;">**Certificates.**</span><span
> style="color:#ff6600;">**[p12](https://www.youtube.com/watch?v=1X10zCzhukI)**</span>**——PKCS12
> file holds the** <span style="color:#006600;">**private key**</span>
> **and **<span
> style="color:#006600;">**certificate**</span></span><span
> style="font-size:14px;">**。**</span>\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">其他Mac机器上双击Certificates.p12（如有密码需输入密码）即可安装该共享证书。有了共享证书之后，在开发者网站上将欲调试的iOS设备注册到该开发者账号名下，并下载对应证书授权了iOS调试设备的Provisioning
> Profile文件，方可在iOS真机设备上开发调试。</span></span>

[]()<span style="font-size:18px;"><span style="font-weight:bold;"><span style="color:rgb(153,51,102);font-size:18px;">**<span style="font-family:Microsoft YaHei;">九.[证书配置常见错误](https://developer.apple.com/library/ios/technotes/tn2318/_index.html)</span>**</span></span></span> {#九.证书配置常见错误 style="margin:0px;padding:0px;"}
============================================================================================================================================================================================================================================================================================

> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">1.<span style="color:rgb(148,54,52);font-size:14px;">no such provisioning profile was found</span></span></span></span> {#no-such-provisioning-profile-was-found style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">Xcode Target|Genera|Identity
> Team下提示</span>"<span style="color:#943634;">Your build settings
> specify a provisioning profile with the UUID "xxx",howerver, no such
> provisioning profile was found.</span><span
> style="color:#333333;">"</span></span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">Xcode Target|BuildSettings|Code
> Signing|当前配置的指定</span>UDID的provisioning
> profile在本地不存在，此时需要更改Provisioning
> Profile。必要时手动去网站下载或重新生成Provisioning
> Profile或直接在Xcode中Fix issue予以解决（可能自动生成iOS Team
> ProvisioningProfile）！</span></span>
>
> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">2.N<span style="color:rgb(148,54,52);">o identities from profile</span></span></span></span> {#no-identities-from-profile style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">Build Settings|CodeSigning的</span>Provisioning
> Profile中选择了本地安装的provisioning profile之后，Code Signing
> Identity中下拉提示[<span style="color:#336699;">No identities from
> profile
> “…”</span>](http://stackoverflow.com/questions/21675371/no-identities-from-profile-happened-after-i-upgraded-to-xcode-5)or
> No identities from keychain.</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">Xcode配置指定</span>UDID的provisioning
> profile中的DeveloperCertificates在本地KeyChain中不存在（[<span
> style="color:#336699;">No identities are
> available</span>](http://stackoverflow.com/questions/18746703/no-identities-are-available-for-signing-xcode-5)）或不一致（KeyPair中的Private
> Key丢失），此时需去网站检查ProvisioningProfile中的App
> ID-Certificate-Device配置是否正确。如果是别人提供的共享账号（\*.developerprofile）或共享证书(\*.p12)，请确保导出了对应Key
> Pair中的Private Key。必要时也直接在Xcode中Fix
> issue予以解决（可能自动生成iOS Team
> ProvisioningProfile）。</span></span>
>
> []()<span style="font-size:14px;"><span style="color:rgb(204,0,0);"><span style="font-family:Microsoft YaHei;">3.<span style="color:rgb(148,54,52);"><span style="color:rgb(148,54,52);font-size:14px;">Code Signing Entitlements file do not match</span> profile</span></span></span></span> {#code-signing-entitlements-file-do-not-match-profile style="margin:0px;padding:0px;color:rgb(51,51,51);"}
> ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">"[<span style="color:#336699;">Invalid
> application-identifier
> Entitlement</span>](https://developer.apple.com/library/ios/qa/qa1710/_index.html)"
> or "</span><span style="color:#943634;">Code Signing Entitlements file
> do not match those specified in your provisioning
> profile.(0xE8008016).</span><span
> style="color:#333333;">"</span></span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">**<span
> style="color:#333333;">（</span><span
> style="color:#333333;">1）</span>**<span
> style="color:#333333;">检查对应版本（</span><span
> style="color:#333333;">Debug）指定的</span>\*.entitlements文件中的“Keychain
> Access
> Groups”键值是否与ProvisioningProfile中的Entitlements项相吻合（后者一般为前者的Prefix/Seed）。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">**<span
> style="color:#333333;">（</span><span
> style="color:#333333;">2）也可以将</span>**<span
> style="color:#333333;">Build Settings|Code
> Signing的</span>Provisioning
> Profile中对应版本（Debug）的Entitlements置空。</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;"><span
> style="color:#333333;">4.Xcode配置反应有时候不那么及时，可刷新、重置相关配置项开关（若有）或重启</span>Xcode试试。</span></span>

[]()<span style="font-family:'Microsoft YaHei';font-size:18px;color:rgb(153,51,102);">十. [Xcode7 免证书真机调试](http://altair21.org/156.html)</span> {#十.xcode7-免证书真机调试 style="margin:0px;padding:0px;"}
======================================================================================================================================================

> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">在 Xcode 7
> 中，苹果改变了自己在许可权限上的策略：</span></span>
>
> 1.  <span style="font-size:14px;font-family:'Microsoft YaHei';">此前
>     Xcode 只开放给注册开发者下载，现在 Xcode 7
>     改变了这种惯有的做法，无需注册开发者账号，仅使用普通的Apple
>     ID就能下载和上手体验。</span>
> 2.  <span
>     style="font-size:14px;font-family:'Microsoft YaHei';">此前开发者需每年支付99美元的费用成为注册开发者才能在
>     iPhone/iPad
>     真机上运行调试APP，苹果新的开发者计划则放宽要求，无需购买，只要你感兴趣同样可以在设备上测试app。——[<span
>     style="font-family:'Microsoft YaHei';font-size:14px;">Developers
>     would be able to test apps on devices </span><span
>     style="font-family:'Microsoft YaHei';font-size:14px;">without</span>](http://www.tuicool.com/articles/JvENzq3)<span
>     style="font-family:'Microsoft YaHei';font-size:14px;">[ a paid
>     Apple developer account in Xcode
>     7](http://www.tuicool.com/articles/JvENzq3).</span></span>
>
> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">所谓“免证书”真机调试，并不是真的不需要证书，Xcode真机调试原有的证书配置体系仍在——<span
> style="font-family:'Microsoft YaHei';font-size:14px;">All iOS, tvOS,
> and watchOS apps ***<span style="color:#ff9900;">must be</span>***
> code signed and provisioned to launch on a
> device. </span>所以，上文啰嗦几千字还是有点用的。</span></span>
>
> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">自 Xcode7 开始，原来基于付费开发者账号及<span
> style="color:#cc6600;">自助</span>生成证书及配置文件的繁琐过程被苹果简化，Xcode将针对任何普通账号<span
> style="color:#cc9933;">**自动**</span>为联调真机生成所需相关的证书及配置文件。</span></span><span
> style="font-size:14px;font-family:'Microsoft YaHei';">当你打算向 App
> Store 提交</span><span
> style="font-size:14px;font-family:'Microsoft YaHei';">发布</span><span
> style="font-size:14px;font-family:'Microsoft YaHei';">应用，才需要付费。</span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="color:#cc0000;">第一步</span>：</span></span><span
> style="font-family:'Microsoft YaHei';font-size:14px;">进入 Xcode
> Preferences|Accounts，添加自己的 Apple ID 账号。</span>
>
> <span style="font-size:14px;font-family:'Microsoft YaHei';"><span
> style="color:#cc0000;font-family:'Microsoft YaHei';font-size:14px;">第二步</span><span
> style="font-family:'Microsoft YaHei';font-size:14px;">：</span>Build
> Settings|Code Signing 下的 Provisioning Profile 选择 <span
> style="background-color:rgb(255,255,204);">**Automatic**</span>，Code
> Signing Identity 选择 Automatic 下的 <span
> style="background-color:rgb(255,255,204);">**iOS
> Developer**</span>。</span>
>
> <span style="font-size:14px;font-family:'Microsoft YaHei';"></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="color:#cc0000;">第三步</span>：General 配置 Bundle
> identifier，Team 下拉选择苹果Member Center自动为你的账号生成的 <span
> style="background-color:rgb(255,255,204);">Personal Team</span>
> ID。</span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">自己的账号在调试公司或其他第三方APP代码时，若填写 <span
> style="font-family:'Microsoft YaHei';font-size:14px;">Bundle
> identifier 为他人账号注册的 APP ID（例如苹果相机应用 <span
> style="color:rgb(191,144,0);font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">com.apple.camera</span>），会报错：</span></span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;">No provisioning
> profiles with a valid signing identity (i.e. certificate and private
> key pair) matching the bundle identifier “com.apple.camera” were
> found.</span></span></span>
>
> <span
> style="font-family:Microsoft YaHei;font-size:12px;">即使编译通过了，可能运行时APP自身与服务器校验也可能会报签名错误，肿么办？？？</span>
>
> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;"><span
> style="font-family:'Microsoft YaHei';font-size:14px;"><span
> style="font-family:'microsoft yahei',simhei,arial,sans-serif;font-size:16px;">Her
> skill：</span>此时，可以在他人原有App ID基础上添加后缀（例如 <span
> style="color:rgb(191,144,0);font-family:'Microsoft YaHei';font-size:14px;line-height:26px;">
> com.apple.camera.<span
> style="background-color:rgb(255,255,153);">***extension***</span></span>），配置成<span
> style="font-family:'Microsoft YaHei';font-size:14px;">应用的衍生插件（相当于置于同一 </span>[App
> Group](http://blog.csdn.net/phunxm/article/details/42715145)
> 下）就可以快乐的玩耍了。</span></span></span>
>
> <span
> style="font-size:14px;font-family:'Microsoft YaHei';">如果启动APP时，Xcode报错“[process
> launch failed:
> Security](http://www.jianshu.com/p/3b2be6454462)”或iPhone报错【[不受信任的开发者](http://bbs.itheima.com/thread-237009-1-1.html)】，此时需要到iPhone通用配置中的<span
> style="color:#ff9900;">描述文件</span>（最新系统中可能叫<span
> style="color:#996633;">设备管理</span>）中，在描述文件（开发商应用）中选择对应的<span
> style="color:#ff9900;">描述文件</span>（你的<span
> style="color:#996633;">Apple
> ID</span>）点击 **信任 **或 **验证 **即可。</span>
>
> <span style="font-size:14px;font-family:'Microsoft YaHei';">OK，All
> Done！</span>
>
> \

<span style="font-size:18px;color:rgb(153,51,102);">**<span
style="font-family:Microsoft YaHei;">参考：</span>**</span>

> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;"></span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">《[iPhone真机调试应用程序](http://blog.sina.com.cn/s/blog_68e753f70100r3w5.html)》《[iOS
> Developer：真机测试](http://my.oschina.net/joanfen/blog/167730)》《[Xcode5
> & iOS 7
> 及以下版本免证书真机调试记录](http://www.cnblogs.com/wengzilin/p/3441116.html)》</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">《[iOS Development--Certificates,
> Provisioning
> Profiles](http://damiansheldon.github.io/blog/ios-development-certificates.html/)》</span></span><span
> style="font-family:'Microsoft YaHei';font-size:14px;">《</span>[关于Certificate、Provisioning
> Profile、App
> ID的介绍及其关系](http://www.cnblogs.com/cywin888/p/3263027.html)<span
> style="font-family:'Microsoft YaHei';font-size:14px;">》</span>
>
> <span style="font-family:Microsoft YaHei;">\
> </span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);">《</span>[数字签名和数字证书](http://blog.csdn.net/phunxm/article/details/16344837)<span
> style="font-size:14px;color:rgb(51,51,51);">》<span
> style="font-family:'Microsoft YaHei';font-size:14px;color:rgb(51,51,51);">《</span><span
> style="font-family:'Microsoft YaHei';font-size:14px;color:rgb(51,51,51);">[iOS
> keyChain
> 研究](http://blog.csdn.net/jerryvon/article/details/16843065)</span><span
> style="font-family:'Microsoft YaHei';font-size:14px;">》</span></span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;color:rgb(51,51,51);"><span
> style="color:rgb(51,51,51);font-family:'Microsoft YaHei';font-size:14px;">《</span>[苹果开发者账号那些事儿](http://blog.csdn.net/ryantang03/article/details/17037895)<span
> style="color:rgb(51,51,51);font-family:'Microsoft YaHei';font-size:14px;">》</span>《[iOS關於Provisioning
> Profiles這些事](http://lamb-mei.com/7/ios-provisioning-profiles/)》\
> </span></span>
>
> <span style="font-family:Microsoft YaHei;"><span
> style="font-size:14px;">《</span>[iOS Code Signing
> 学习笔记](http://foggry.com/blog/2014/10/16/ios-code-signing-xue-xi-bi-ji/)<span
> style="font-size:14px;">》</span></span><span
> style="font-family:'Microsoft YaHei';font-size:14px;">《</span>[代码签名探析](http://www.objccn.io/issue-17-2/)<span
> style="font-family:'Microsoft YaHei';font-size:14px;">/</span>[Inside
> Code
> Signing](http://www.objc.io/issue-17/inside-code-signing.html)<span
> style="font-family:'Microsoft YaHei';font-size:14px;">》</span>
>
> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">《</span>[iOS Code Signing:
> 解惑](http://www.cnblogs.com/andyque/archive/2011/08/30/2159086.html)<span
> style="font-size:14px;">/</span>[iOS Code Signing: Under The
> Hood](http://www.raywenderlich.com/2915/ios-code-signing-under-the-hood)<span
> style="font-size:14px;">》</span></span>
>
> <span style="font-family:'Microsoft YaHei';"><span
> style="font-size:14px;">\
> </span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">《[iOS行货自动打包](http://www.cnblogs.com/yesun/archive/2013/08/16/3261839.html)》<span
> style="color:rgb(51,51,51);font-family:'Microsoft YaHei';font-size:14px;">《</span>[解决Xcode无法生成Archive的问题](http://blog.csdn.net/sing_sing/article/details/7576027)<span
> style="color:rgb(51,51,51);font-family:'Microsoft YaHei';font-size:14px;">》</span>《[iOS程序完成后如何生成ipa进行真机测试](http://blog.csdn.net/why_ios/article/details/7798030)》</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">《[发布iOS应用程序(Application
> Loader)](http://blog.csdn.net/xiaoxuan415315/article/details/8217134)》《[iOS发布遇到的一些问题](http://blogs.zmit.cn/1023.html)》</span></span>
>
> <span style="font-size:14px;"><span
> style="font-family:Microsoft YaHei;">《[Xcode打包ipa包](http://zengwu3915.blog.163.com/blog/static/27834897201362831449893/)》《[iOS程序生成ipa进行真机测试](http://blog.csdn.net/why_ios/article/details/7798030)》\
> </span></span>
>
> \

</div>

<div style="zoom:1;float:right;">

[](http://blog.csdn.net/phunxm/article/details/42685597#)
[](http://blog.csdn.net/phunxm/article/details/42685597# "分享到QQ空间")
[](http://blog.csdn.net/phunxm/article/details/42685597# "分享到新浪微博")
[](http://blog.csdn.net/phunxm/article/details/42685597# "分享到腾讯微博")
[](http://blog.csdn.net/phunxm/article/details/42685597# "分享到人人网")
[](http://blog.csdn.net/phunxm/article/details/42685597# "分享到微信")
<span
style="visibility:hidden;display:block;height:0px;clear:both;">.</span>

</div>

<div
style="display:block;clear:both;width:182px;margin:0px auto;padding:30px 0px 15px;text-align:center;">

顶
:   25

<!-- -->

踩
:   0

<span
style="text-align:center;display:block;height:0px;clear:both;visibility:hidden;">.</span>

</div>

-   <span
    style="font-size:14px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);float:left;margin-right:7px;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);background-position:9px 8px;background-repeat:no-repeat;">上一篇</span>[iPhone屏幕尺寸、分辨率及适配](http://blog.csdn.net/phunxm/article/details/42174937)
-   <span
    style="font-size:14px;display:block;width:52px;padding:0px 0px 0px 27px;height:26px;color:rgb(255, 255, 255);float:left;margin-right:7px;background-color:rgb(153, 153, 153);background-image:url(&quot;&quot;);background-position:9px -22px;background-repeat:no-repeat;">下一篇</span>[iOS8扩展插件开发配置](http://blog.csdn.net/phunxm/article/details/42715145)

<div style="clear:both;height:10px;">

</div>

<div style="overflow:hidden;">

#### 我的同类文章 {#我的同类文章 style="margin:0px;padding:0px;font-size:16px;color:rgb(51, 51, 51);"}

<div
style="border:1px solid rgb(187, 187, 187);margin:20px 0px 0px 0px;">

<div
style="height:45px;line-height:45px;border-bottom-style:solid;border-bottom-width:1px;border-bottom-color:rgb(220, 220, 220);">

<span
style="display:inline-block;margin-left:25px;font-size:16px;color:rgb(102, 102, 102);font-weight:bold;">
<span style="cursor:pointer;">iOS*（8）*</span> </span>

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

</div>

\

</div>
