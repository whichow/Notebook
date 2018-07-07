# [自己搭建ss/ssr服务器教程（很详细，适合初学者）](https://github.com/getlantern/forum/issues/5620)

**2018.4.7对教程的细节方面进行补充和更新。**

【客户端下载】

第一次电脑系统使用SSR/SS客户端时，需要安装NET Framework 4.0，不然无法正常使用，[微软官网下载](https://www.microsoft.com/zh-cn/download/details.aspx?id=17718)。NET Framework 4.0是SSR/SS的运行库，没有这个SSR/SS客户端无法正常运行。有的电脑系统可能会自带NET Framework 4.0。

Windows SSR客户端 [下载地址](https://github.com/shadowsocksr-backup/shadowsocksr-csharp/releases) [备用下载地址](https://nofile.io/f/6Jm7WJCyOVv/ShadowsocksR-4.7.0-win.7z)

MAC SSR客户端 [下载地址](https://github.com/shadowsocksr-backup/ShadowsocksX-NG/releases) [备用下载地址](https://nofile.io/f/jgMWFwCBonU#ab0d3c3b6ac54482)

Linux客户端一键安装配置 [使用脚本](https://github.com/the0demiurge/CharlesScripts/blob/master/charles/bin/ssr) (使用方法见注释) 或者采用图形界面的[linux ssr客户端](https://github.com/erguotou520/electron-ssr/releases)

安卓 SSR客户端 [下载地址](https://github.com/shadowsocksr-backup/shadowsocksr-android/releases) [备用下载地址](https://nofile.io/f/rvTJoj0h5GC/shadowsocksr-release.apk)

苹果手机SSR客户端：Potatso Lite、Potatso、shadowrocket都可以作为SSR客户端，但这些软件目前已经在国内的app商店下架，可以用美区的appid账号来下载。但是，如果你配置的SSR账号兼容SS客户端，或者协议选择origin且混淆选择plain，那么你可以选择苹果SS客户端软件（即协议和混淆可以不填），APP商店里面有很多，比如：superwingy、firstwingy、shadowingy、wingy+、banananet、kite-ss proxy、goodshadow、icproyx、shadowrocket等。

**有了客户端后我们需要自己搭建服务器创建ss/ssr账号才能翻墙。**

### 搭建教程

### 不怕被封ip，因为vultr是折算成小时计费，且可以随时删除和开通服务器，新服务器就是新的ip。新开服务器只需要0.01美元，即使你运气非常不好，开了10台服务器才获得没有被墙的ip，总创建服务器成本也只有0.1美元，不到1块钱。

**教程很简单，整个教程分三步**：

第一步：购买VPS服务器

第二步：一键部署VPS服务器

第三步：一键加速VPS服务器 （谷歌BBR加速，推荐）

------

**第一步：购买VPS服务器**

VPS服务器需要选择国外的，首选国际知名的vultr，速度不错、稳定且性价比高，按小时计费，能够随时开通和删除服务器，新服务器即是新ip。

vultr注册地址： <http://www.vultr.com/?ref=7048874> （全球15个服务器位置可选，KVM框架，最低2.5美元/月。如果以后这个地址被墙了，得用翻墙软件打开，或者用[ss/ssr免费账号](https://github.com/Alvin9999/new-pac/wiki/ss%E5%85%8D%E8%B4%B9%E8%B4%A6%E5%8F%B7)）

虽然是英文界面，但是现在的浏览器都有网页翻译功能，鼠标点击右键，选择网页翻译即可翻译成中文。

注册并邮件激活账号，充值后即可购买服务器。充值方式是paypal（首选）或支付宝，使用paypal有银行卡（包括信用卡）即可。paypal注册地址：[https://www.paypal.com](https://www.paypal.com/) （paypal是国际知名的第三方支付服务商，注册一下账号，绑定银行卡即可购买国外商品）

2.5美元/月的服务器配置信息：单核 512M内存 20G SSD硬盘 带宽峰值100M 500G流量/月

5美元/月的服务器配置信息： 单核 1G内存 25G SSD硬盘 带宽峰值100M 1000G流量/月

10美元/月的服务器配置信息： 单核 2G内存 40G SSD硬盘 带宽峰值100M 2000G流量/月

20美元/月的服务器配置信息： 2cpu 4G内存 60G SSD硬盘 带宽峰值100M 3000G流量/月

40美元/月的服务器配置信息： 4cpu 8G内存 100G SSD硬盘 带宽峰值100M 4000G流量/月

**vultr实际上是折算成小时来计费的，比如服务器是5美元1个月，那么每小时收费为5/30/24=0.0069美元 会自动从账号中扣费，只要保证账号有钱即可。如果你部署的服务器实测后速度不理想，你可以把它删掉（destroy），重新换个地区的服务器来部署，方便且实用。因为新的服务器就是新的ip，所以当ip被墙时这个方法很有用。当ip被墙时，为了保证新开的服务器ip和原先的ip不一样，先开新服务器，开好后再删除旧服务器即可。**

计费从你开通服务器开始算的，不管你有没有使用，即使服务器处于关机状态仍然会计费，如果你没有开通服务器就不算。比如你今天早上开通了服务器，但你有事情，晚上才部署，那么这段时间是会计费的。同理，如果你早上删掉服务器，第二天才开通新的服务器，那么这段时间是不会计费的。在账号的Billing选项里可以看到账户余额。

温馨提醒：同样的服务器位置，不同的宽带类型和地区所搭建的账号的翻墙速度会不同，这与中国电信、中国联通、中国移动国际出口带宽和线路不同有关，所以以实测为准。可以先选定一个服务器位置来按照教程进行搭建，熟悉搭建方法，当账号搭建完成并进行了bbr加速后，测试下速度自己是否满意，如果满意那就用这个服务器位置的服务器。如果速度不太满意，就一次性开几台不同的服务器位置的服务器，然后按照同样的方法来进行搭建并测试，选择最优的，之后把其它的服务器删掉，按小时计费测试成本可以忽略。

**账号充值如图**：

[![img](SSR搭建.assets/pp100.png)](https://raw.githubusercontent.com/Alvin9999/pac2/master/pp100.png)

[![img](SSR搭建.assets/pp101.png)](https://raw.githubusercontent.com/Alvin9999/pac2/master/pp101.png)

**开通服务器步骤如图**：

[![img](SSR搭建.assets/pac教程01.png)](https://raw.githubusercontent.com/Alvin9999/crp_up/master/pac%E6%95%99%E7%A8%8B01.png)

[![img](SSR搭建.assets/pac教程02.png)](https://raw.githubusercontent.com/Alvin9999/crp_up/master/pac%E6%95%99%E7%A8%8B02.png)

[![img](SSR搭建.assets/pac教程04.png)](https://raw.githubusercontent.com/Alvin9999/crp_up/master/pac%E6%95%99%E7%A8%8B04.png)

### 选择vps操作系统时，不要选centos7系统！点击图中的CentOS几个字，会弹出centos6，然后选中centos6！entos7默认的防火墙可能会干扰ssr的正常连接！

> 接下来这一步是开启vps的ipv6 ip，选填项。如果你的电脑系统可以用ipv6，那么可以勾选此项。大多数用户没有这个需求，但有一些用户可能会用到，所以补充了这部分内容。

[![img](SSR搭建.assets/ssripv6-01.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/ssripv6-01.png)

**完成购买后，找到系统的密码记下来，部署服务器时需要用到。vps系统（推荐centos6）的密码获取方法如下图：**

[![img](SSR搭建.assets/pac教程05.png)](https://raw.githubusercontent.com/Alvin9999/crp_up/master/pac%E6%95%99%E7%A8%8B05.png)

[![img](SSR搭建.assets/pac教程06.png)](https://raw.githubusercontent.com/Alvin9999/crp_up/master/pac%E6%95%99%E7%A8%8B06.png)

> 如果你开启了vps的ipv6，那么在后台的settings选项可以找到服务器的ipv6 ip。在部署SSR账号时，你用ipv6 ip就行。整个部署及使用过程中，记得把电脑系统开启ipv6喔。

[![img](SSR搭建.assets/ssripv6-02.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/ssripv6-02.png)

**删掉服务器步骤如下图**：

[![img](SSR搭建.assets/de4.PNG)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/de4.PNG)

[![img](SSR搭建.assets/de2.PNG)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/de2.PNG)

[![img](SSR搭建.assets/de5.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/de5.png)

一个被墙ip的vps被删掉后，其ip并不会消失，会随机分配给下一个在这个服务器位置新建服务器的人，这就是为什么开新服务器会有一定几率开到被墙的ip。被墙是指在国内地区无法ping通服务器，但在国外是可以ping通的，vultr是面向全球服务，如果这个被墙ip被国外的人开到了，它是可以被正常使用的，半年或1年后这个被墙的ip可能会被国内防火墙解封，那么这就是一个良性循环。

------

**第二步：部署VPS服务器**

购买服务器后，需要部署一下。因为你买的是虚拟东西，而且又远在国外，我们需要一个叫Xshell的软件来远程部署。Xshell windows版下载地址：

[国外云盘1下载](http://45.32.141.248:8000/f/d91974d046/)

[国外云盘2下载](https://nofile.io/f/eb5dUzYMQK4/Xshell_setup_wm.exe) 提取密码：666

[国外云盘3下载](https://www.adrive.com/public/NdK3Ez/Xshell_setup_wm.exe) 密码：123

如果你是苹果电脑操作系统，更简单，无需下载xshell，系统可以直接连接VPS。打开**终端**（Terminal），输入ssh root@ip 其中“ip”替换成你VPS的ip, 按回车键，然后复制粘贴密码，按回车键即可登录。粘贴密码时有可能不显示密码，但不影响， [参考设置方法](http://www.cnblogs.com/ghj1976/archive/2013/04/19/3030159.html) 如果不能用MAC自带的终端连接的话，直接网上搜“MAC连接SSH的软件”，有很多，然后通过软件来连接vps服务器就行，具体操作方式参考windows xshell。

------

部署教程：

下载xshell软件并安装后，打开软件

[![img](SSR搭建.assets/xshell11.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/xshell11.png)

选择文件，新建

[![img](SSR搭建.assets/xshell12.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/xshell12.png)

随便取个名字，然后把你的服务器ip填上

[![img](SSR搭建.assets/xshell13.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/xshell13.png)

连接国外ip即服务器时，软件会先后提醒你输入用户名和密码，用户名默认都是root，密码是你购买的服务器系统的密码。

### 如果xshell连不上服务器，没有弹出让你输入用户名和密码的输入框，表明你开到的ip是一个被墙的ip，遇到这种情况，重新开新的服务器，直到能用xshell连上为止，耐心点哦！如果同一个地区开了多台服务器还是不行的话，可以换其它地区。

[![img](SSR搭建.assets/xshell14.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/xshell14.png)

[![img](SSR搭建.assets/xshell2.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/xshell2.png)

连接成功后，会出现如上图所示，之后就可以复制粘贴代码部署了。

CentOS6/Debian6/Ubuntu14 ShadowsocksR一键部署管理脚本：

------

yum -y install wget

wget -N --no-check-certificate <https://raw.githubusercontent.com/ToyoDAdoubi/doubi/master/ssr.sh> && chmod +x ssr.sh && bash ssr.sh

备用脚本：

yum -y install wget

wget -N --no-check-certificate <https://softs.fun/Bash/ssr.sh> && chmod +x ssr.sh && bash ssr.sh

———————————————————代码分割线————————————————

复制上面的代码到VPS服务器里，复制代码用鼠标右键的复制，然后在vps里面右键粘贴进去，因为ctrl+c和ctrl+v无效。接着按回车键，脚本会自动安装，以后只需要运行这个快捷命令就可以出现下图的界面进行设置，快捷管理命令为：bash ssr.sh

[![img](SSR搭建.assets/8.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/8.png)

如上图出现管理界面后，**输入数字1来安装SSR服务端**。如果输入1后不能进入下一步，那么请退出xshell，重新连接vps服务器，然后输入快捷管理命令bash ssr.sh 再尝试。

[![img](SSR搭建.assets/31.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/31.png)

根据上图提示，依次输入自己想设置的**端口和密码** (**密码建议用复杂点的字母组合，端口号为40-65535之间的数字**)，回车键用于确认

注：关于端口的设置，总的网络总端口有6万多个，理论上可以任意设置。但是有的地区需要设置特殊的端口才有效，一些特殊的端口比如80、143、443、1433、3306、3389、8080。

[![img](SSR搭建.assets/32.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/32.png)

如上图，选择想设置的**加密方式**，比如10，按回车键确认

接下来是选择**协议插件**，如下图：

[![img](SSR搭建.assets/11.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/11.png)

[![img](SSR搭建.assets/41.PNG)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/41.PNG)

选择并确认后，会出现上图的界面，提示你是否选择兼容原版，这里的原版指的是SS客户端（SS客户端没有协议和混淆的选项），可以根据需求进行选择，演示选择y

之后进行混淆插件的设置。

**注意：如果协议是origin，那么混淆也必须是plain；如果协议不是origin，那么混淆可以是任意的。有的地区需要把混淆设置成plain才好用。因为混淆不总是有效果，要看各地区的策略，有时候不混淆（plain）让其看起来像随机数据更好。（特别注意：tls 1.2_ticket_auth容易受到干扰！请选择除tls开头以外的其它混淆！！！）**

[![img](SSR搭建.assets/33.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/33.png)

进行混淆插件的设置后，会依次提示你对设备数、单线程限速和端口总限速进行设置，默认值是不进行限制，个人使用的话，选择默认即可，即直接敲回车键。

注意：关于限制设备数，这个协议必须是非原版且不兼容原版才有效，也就是必须使用SSR协议的情况下，才有效！

[![img](SSR搭建.assets/14.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/14.png)

之后代码就正式自动部署了，到下图所示的位置，提示你下载文件，输入：y

[![img](SSR搭建.assets/15.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/15.png)

耐心等待一会，出现下面的界面即部署完成：

[![img](SSR搭建.assets/16.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/16.png)

[![img](SSR搭建.assets/34.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/34.png)

根据上图就可以看到自己设置的SSR账号信息，包括IP、端口、密码、加密方式、协议插件、混淆插件，这些信息需要填入你的SSR客户端。如果之后想修改账号信息，直接输入快捷管理命令：bash ssr.sh 进入管理界面，选择相应的数字来进行一键修改。例如：

[![img](SSR搭建.assets/22.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/22.png)

[![img](SSR搭建.assets/23.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/23.png)

**脚本演示结束。**

此脚本是开机自动启动，部署一次即可。最后可以重启服务器确保部署生效（一般情况不重启也可以）。重启需要在命令栏里输入reboot ，输入命令后稍微等待一会服务器就会自动重启，一般重启过程需要2～5分钟，重启过程中Xshell会自动断开连接，等VPS重启好后才可以用Xshell软件进行连接。如果部署过程中卡在某个位置超过10分钟，可以用xshell软件断开，然后重新连接你的ip，再复制代码进行部署。

------

**第三步：一键加速VPS服务器**

此加速教程为谷歌BBR加速,Vultr的服务器框架可以装BBR加速，加速后对速度的提升很明显，所以推荐部署加速脚本。该加速方法是开机自动启动，部署一次就可以了。

按照第二步的步骤，连接服务器ip，登录成功后，在命令栏里粘贴以下代码：

【谷歌BBR加速教程】

yum -y install wget

wget --no-check-certificate <https://github.com/teddysun/across/raw/master/bbr.sh>

chmod +x bbr.sh

./bbr.sh

把上面整个代码复制后粘贴进去，不动的时候按回车，然后耐心等待，最后重启vps服务器即可。

演示开始，如图：

复制并粘贴代码后，按回车键确认

[![img](SSR搭建.assets/18.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/18.png)

如下图提示，按任意键继续部署

[![img](SSR搭建.assets/19.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/19.png)

[![img](SSR搭建.assets/20.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/20.png)

部署到上图这个位置的时候，等待3～6分钟

[![img](SSR搭建.assets/21.png)](https://raw.githubusercontent.com/Alvin9999/PAC/master/ss/21.png)

最后输入y重启服务器，如果输入y提示command not found ，接着输入reboot来重启服务器，确保加速生效，bbr加速脚本是开机自动启动，装一次就可以了。

服务器重启成功并重新连接服务器后，输入命令lsmod | grep bbr 如果出现tcp_bbr字样表示bbr已安装并启动成功。如图：

[![img](SSR搭建.assets/tcp_bbr.PNG)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/tcp_bbr.PNG)

------

购买vps服务器后，ip有了，通过部署，端口、密码、加密方式、协议和混淆也有了，最后将这些信息填入SSR客户端就可以翻墙啦。

**有了账号后，打开SSR客户端，填上信息，这里以windows版的SSR客户端为例子**：
[![img](SSR搭建.assets/42.PNG)](https://raw.githubusercontent.com/Alvin9999/PAC/master/demo/42.PNG)

在对应的位置，填上服务器ip、服务器端口、密码、加密方式、协议和混淆，最后将浏览器的代理设置为（http）127.0.0.1和1080即可。账号的端口号就是你自己设置的，而要上网的浏览器的端口号是1080，固定的，谷歌浏览器可以通过 SwitchyOmega 插件来设置。

启动SSR客户端后，右键SSR客户端图标，选择第一个“系统代理模式”，里面有3个子选项，选择"全局模式“，之后就可以用浏览器设置好了的代理模式（http）127.0.0.1和1080翻墙，此模式下所有的网站都会走SSR代理。（适合新手）

[![ssr9000](SSR搭建.assets/32225069-cfe6195a-be7e-11e7-99e0-e2fa98f93b1f.png)](https://user-images.githubusercontent.com/12132898/32225069-cfe6195a-be7e-11e7-99e0-e2fa98f93b1f.png)

------

**常见问题参考解决方法**：

1、用了一段时间发现ssr账号用不了了

首先ping一下自己的ip，看看能不能ping的通，ping不通那么就是ip被墙了，ip被墙时，xshell也会连接不上服务器，遇到这种情况重新部署一个新的服务器，新的服务器就是新的ip。关于怎么ping ip的方法，可以自行网上搜索，或者用xshell软件连接服务器来判断，连不上即是被墙了。vultr开通和删除服务器非常方便，新服务器即新ip，大多数vps服务商都没有这样的服务，一般的vps服务商可能会提供免费更换1次ip的服务。

2、刚搭建好的ssr账号，ip能ping通，但是还是用不了

首选排除杀毒软件的干扰，尤其是国产杀毒软件，比如360安全卫生、360杀毒软件、腾讯管家、金山卫生等。这些东西很容易干扰翻墙上网，如果你的电脑安装了这样的东西，建议至少翻墙时别用，最好卸载。其次，检查下SSR信息是否填写正确。浏览器的代理方式是否是ssr代理，即（HTTP）127.0.0.1 和1080。如果以上条件都排除，还是用不了，那么可以更换端口、加密方式、协议、混淆，或者更换服务器位置。另外，如果你的vps服务器配置的是SSR账号，即有协议和混淆且没有兼容原版(SS版），那么你必须使用SSSR客户端来使用账号，因为SS客户端没有填写协议和混淆的选项。

3、有的地区需要把混淆参数设置成plain才好用。因为混淆不总是有效果，要看各地区的策略，有时候不混淆（plain）让其看起来像随机数据更好。

4、电脑能用但手机用不了

如果你的手机用的是SS客户端，SS客户端没有填协议和混淆的地方，如果你部署的协议和混淆的时候没有选择兼容原版（SS版），因此手机是用不了的。这个时候你把协议弄成兼容原版、混淆也设置成兼容原版即可。或者直接将协议设置成origin且混淆设置成plain。

5、vps的服务器操作系统不要用的太高，太高可能会因为系统的防火墙问题导致搭建的SSR账号连不上，如果你用的centos系统，建议用centos6，不要用centos7。如果你前面不小心装了centos7系统，那么只能重装系统或者重新部署新的vps服务器。

6、vultr服务商提供的vps服务器是单向流量计算，有的vps服务商是双向流量计算，单向流量计算对于用户来说更实惠。因为我们是在vps服务器上部署SSR服务端后，再用SSR客户端翻墙，所以SSR服务端就相当于中转，比如我们看一个视频，必然会产生流量，假如消耗流量80M，那么VPS服务器会产生上传80M和下载80M流量，vultr服务商只计算单向的80M流量。如果是双向计算流量，那么会计算为160M流量。

7、如果你想把搭建的账号给多人使用，不用额外设置端口，因为一个账号就可以多人使用。一般5美元的服务器可以同时支持40人在线使用。

如果想实现支持每个用户(端口)不同的加密方式/协议/混淆等，并且管理流量使用，可以参考多用户配置脚本：wget -N --no-check-certificate <https://softs.fun/Bash/ssrmu.sh> && chmod +x ssrmu.sh && bash ssrmu.sh 备用脚本：wget -N --no-check-certificate <https://raw.githubusercontent.com/ToyoDAdoubi/doubi/master/ssrmu.sh> && chmod +x ssrmu.sh && bash ssrmu.sh 安装后管理命令为：bash ssrmu.sh
注意：这个多用户配置脚本和教程内容的脚本无法共存！要想用这个脚本，把之前的脚本卸载，输入管理命令bash ssr.sh ，选择3，卸载ShadowsocksR即可卸载原脚本。

8、vultr服务器每月有流量限制，超过限制后服务器不会被停止运行，但是超出的流量会被额外收费。北美和西欧地区的服务器超出流量后，多出的部分收费为0.01美元/G。新加坡和日本东京（日本）为0.025美元/G，悉尼（澳大利亚）为0.05美元/G。把vultr服务器删掉，开通新的服务器，流量会从0开始重新计算。

9、vultr怎样才能申请退款呢？

vultr和其他的国外商家一样，都是使用工单的形式与客服联系，如果需要退款，直接在后台点击support，选择open ticket新开一个工单，选择billing question财务问题，简单的在文本框输入你的退款理由。比如：Please refund all the balance in my account。工单提交以后一般很快就可以给你确认退款，若干个工作日后就会退回你的支付方式。（全额退款结束后，账号可能会被删除）

如果英语水平不好，但是想和客服进行交流，可以用百度在线翻译，自动中文转英文和英文转中文。

10、路由器也可以配置ss/ssr账号，详见openwrt-ssr项目地址：<https://github.com/ywb94/openwrt-ssr>

11、如果电脑想用搭建的ss/ssr账号玩游戏，即实现类似VPN全局代理，可以用SSTAP，教程：<https://www.jianshu.com/p/519e68b74646>

------

多实践会更好。第一次部署时会慢一点，熟练了之后，就很快了。

