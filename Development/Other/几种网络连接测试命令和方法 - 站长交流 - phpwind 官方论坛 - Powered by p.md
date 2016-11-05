<div class="wrap">

<div class="main_wrap">

<div id="J_posts_list" class="read_page">

<div id="read_0" class="floor cc J_read_floor">

+--------------------------------------------------------------------------+
| <div id="J_read_main">                                                   |
|                                                                          |
| <div                                                                     |
| style="border: 0px none rgb(51, 51, 51); color: rgb(51, 51, 51); display |
| : block; font-style: normal; font-variant: normal; font-weight: normal;  |
| font-stretch: normal; font-size: 14px; font-family: Tahoma; height: 8475 |
| px; line-height: 25.2px; margin: 0px; outline: rgb(51, 51, 51) none 0px; |
|  padding: 0px; text-decoration: none; width: 995px; word-break: break-al |
| l; word-wrap: break-word;">                                              |
|                                                                          |
| 一、Ping命令的使用技巧\                                                  |
| \                                                                        |
| 　　Ping是个使用频率极高的实用程序，用于确定本地主机是否能与另一台主机交换（发送与接收）数据报。根据返回的信息，我们就可以推断TCP/IP参 |
| 数是否设置得正确以及运行是否正常。需要注意的是：成功地与另一台主机进行一次或两次数 |
|                                                                          |
| 据报交换并不表示TCP/IP配置就是正确的，我们必须执行大量的本地主机与远程主机的数据报交换，才能确信TCP/IP的正确性。\ |
|                                                                          |
| \                                                                        |
| 　　简单的说，Ping就是一个测试程序，如果Ping运行正确，我们大体上就可以排除网络访问层、网卡、MODEM的输入输出线路、电缆和路由器等存在 |
| 的故障，从而减小了问题的范围。但由于可以自定义所发数据报的大小及无休止的高速发送，Ping也被某些别有用心的人作为DDOS（拒绝服务攻击）的工具 |
| ，例如许多大型的网站就是被黑客利用数百台可以高速接入互联网的电脑连续发送大量Ping数据报而瘫痪的。\ |
|                                                                          |
| \                                                                        |
| 　　按照缺省设置，Windows上运行的Ping命令发送4个ICMP（网间控制报文协议）回送请求，每个32字节数据，如果一切正常，我们应能得到4 |
| 个回送应答。                                                             |
| Ping能够以毫秒为单位显示发送回送请求到返回回送应答之间的时间量。如果应答时间短，表示数据报不必通过太多的路由器或网络连接速度比较快。Ping |
| 还能显示TTL（Time                                                        |
| To                                                                       |
| Live存在时间）值，我们可以通过TTL值推算一下数据包已经通过了多少个路由器：源地点TTL起始值（就是比返回TTL略大的一个2的乘方数）-返回 |
| 时TTL值。例如，返回TTL值为119，那么可以推算数据报离开源地址的TTL起始值为128，而源地点到目标地点要通过9个路由器网段（128-11 |
| 9）；如果返回TTL值为246，TTL起始值就是256，源地点到目标地点要通过9个路由器网段。\ |
|                                                                          |
| \                                                                        |
| 　　1、通过Ping检测网络故障的典型次序\                                   |
| \                                                                        |
| 正常情况下，当我们使用Ping命令来查找问题所在或检验网络运行情况时，我们需要使用许多Ping命令，如果所有都运行正确，我们就可以相信基本的连通 |
| 性和配置参数没有问题；如果某些Ping命令出现运行故障，它也可以指明到何处去查找问题。下面就给出一个典型的检测次序及对应的可能故障：\ |
|                                                                          |
| \                                                                        |
| 　　·ping 127.0.0.1\                                                     |
| \                                                                        |
| 这个Ping命令被送到本地计算机的IP软件，该命令永不退出该计算机。如果没有做到这一点，就表示TCP/IP的安装或运行存在某些最基本的问题。\ |
|                                                                          |
| \                                                                        |
| 　　·ping 本机IP\                                                        |
| \                                                                        |
| 　　这个命令被送到我们计算机所配置的IP地址，我们的计算机始终都应该对该Ping命令作出应答，如果没有，则表示本地配置或安装存在问题。出现此问题 |
| 时，局域网用户请断开网络电缆，然后重新发送该命令。如果网线断开后本命令正确，则表示另一台计算机可能配置了相同的IP地址。\ |
|                                                                          |
| \                                                                        |
| 　　·ping 局域网内其他IP\                                                |
| \                                                                        |
| 这个命令应该离开我们的计算机，经过网卡及网络电缆到达其他计算机，再返回。收到回送应答表明本地网络中的网卡和载体运行正确。但如果收到0个回送应答， |
| 那么表示子网掩码（进行子网分割时，将IP地址的网络部分与主机部分分开的代码）不正确或网卡配置错误或电缆系统有问题。\ |
|                                                                          |
| ·ping 网关IP\                                                            |
| \                                                                        |
| 　　这个命令如果应答正确，表示局域网中的网关路由器正在运行并能够作出应答。\ |
|                                                                          |
| \                                                                        |
| 　　·ping 远程IP\                                                        |
| \                                                                        |
| 如果收到4个应答，表示成功的使用了缺省网关。对于拨号上网用户则表示能够成功的访问Internet（但不排除ISP的DNS会有问题）。\ |
|                                                                          |
| \                                                                        |
| 　　·ping localhost\                                                     |
| localhost是个作系统的网络保留名，它是127.0.0.1的别名，每太计算机都应该能够将该名字转换成该地址。如果没有做到这一带内，则表示主 |
| 机文件（/Windows/host）中存在问题。\                                     |
| \                                                                        |
| 　　·ping [www.xxx.com](http://www.xxx.com/)\                            |
| 对这个域名执行Ping [www.xxx.com](http://www.xxx.com/)                    |
| 地址，通常是通过DNS 服务器                                               |
| 如果这里出现故障，则表示DNS服务器的IP地址配置不正确或DNS服务器有故障（对于拨号上网用户，某些ISP已经不需要设置DNS服务器了）。顺便说 |
| 一句：我们也可以利用该命令实现域名对IP地址的转换功能。如果上面所列出的所有Ping命令都能正常运行，那么我们对自己的计算机进行本地和远程通信的 |
| 功能基本上就可以放心了。但是，这些命令的成功并不表示我们所有的网络配置都没有问题，例如，某些子网掩码错误就可能无法用这些方法检测到。\ |
|                                                                          |
| \                                                                        |
| 　　2、Ping命令的常用参数选项\                                           |
| \                                                                        |
| 　　·ping IP Ct\                                                         |
| \                                                                        |
| 连续对IP地址执行Ping命令，直到被用户以Ctrl+C中断。\                      |
| \                                                                        |
| 　　·ping IP -l 3000\                                                    |
| \                                                                        |
| 指定Ping命令中的数据长度为3000字节，而不是缺省的32字节。\                |
| \                                                                        |
| 　　·ping IP Cn\                                                         |
| \                                                                        |
| 执行特定次数的Ping命令。\                                                |
| \                                                                        |
| 　　二、Netstat 命令的使用技巧\                                          |
| \                                                                        |
| 　　Netstat用于显示与IP、TCP、UDP和ICMP协议相关的统计数据，一般用于检验本机各端口的网络连接情况。如果我们的计算机有时候接受到 |
| 的数据报会导致出错数据删除或故障，我们不必感到奇怪，TCP/IP可以容许这些类型的错误，并能够自动重发数据报。但如果累计的出错情况数目占到所接收 |
| 的IP数据报相当大的百分比，或者它的数目正迅速增加，那么我们就应该使用Netstat查一查为什么会出现这些情况了。\ |
|                                                                          |
| \                                                                        |
| 　1、netstat 的一些常用选项\                                             |
| \                                                                        |
| 　　·netstat Cs\                                                         |
| \                                                                        |
| 　　本选项能够按照各个协议分别显示其统计数据。如果我们的应用程序（如Web浏览器）运行速度比较慢，或者不能显示Web页之类的数据，那么我们就可以 |
| 用本选项来查看一下所显示的信息。我们需要仔细查看统计数据的各行，找到出错的关键字，进而确定问题所在。\ |
|                                                                          |
| \                                                                        |
| 　　·netstat Ce\                                                         |
| \                                                                        |
| 　　本选项用于显示关于以太网的统计数据。它列出的项目包括传送的数据报的总字节数、错误数、删除数、数据报的数量和广播的数量。这些统计数据既有发送的 |
| 数据报数量，也有接收的数据报数量。这个选项可以用来统计一些基本的网络流量）。\ |
|                                                                          |
| \                                                                        |
| 　　·netstat Cr\                                                         |
| \                                                                        |
| 　　本选项可以显示关于路由表的信息，类似于后面所讲使用route              |
| print命令时看到的 信息。除了显示有效路由外，还显示当前有效的连接。\      |
| \                                                                        |
| 　　·netstat Ca\                                                         |
| \                                                                        |
| 　　本选项显示一个所有的有效连接信息列表，包括已建立的连接（ESTABLISHED），也包括监听连接请求（LISTENING）的那些连接。\ |
|                                                                          |
| \                                                                        |
| 　　·netstat Cn\                                                         |
| \                                                                        |
| 　　显示所有已建立的有效连接。\                                          |
| \                                                                        |
| 下面是 netstat 的输出示例：\                                             |
| \                                                                        |
| 　　C:\\&gt;netstat -e\                                                  |
| 　　Interface Statistics\                                                |
| 　　Received　　　Sent\                                                  |
| 　　Bytes　　　　　　　　　3995837940　　47224622\                       |
| 　　Unicast packets　　　　120099　　　　131015\                         |
| 　　Non-unicast packets　　7579544　　　 3823\                           |
| 　　Discards　　　　　　　 0　　　　　　 0\                              |
| 　　Errors　　　　　　　　 0　　　　　　 0\                              |
| 　　Unknown protocols　　　363054211\                                    |
| 　C:\\&gt;netstat -a\                                                    |
| 　　Active Connections\                                                  |
| 　　Proto Local Address　　　Foreign Address　　　 State\                |
| 　　TCP　CORP1:1572　　　 172.16.48.10:nbsession　 ESTABLISHED\          |
| 　　TCP　CORP1:1589　　　 172.16.48.10:nbsession　 ESTABLISHED\          |
| 　　TCP　CORP1:1606　　　 172.16.105.245:nbsession ESTABLISHED\          |
| 　　TCP　CORP1:1632　　　 172.16.48.213:nbsession　ESTABLISHED\          |
| 　　TCP　CORP1:1659　　　 172.16.48.169:nbsession　ESTABLISHED\          |
| 　　TCP　CORP1:1714　　　 172.16.48.203:nbsession　ESTABLISHED\          |
| 　　TCP　CORP1:1719　　　 172.16.48.36:nbsession　 ESTABLISHED\          |
| 　　TCP　CORP1:1241　　　 172.16.48.101:nbsession　ESTABLISHED\          |
| 　　UDP　CORP1:1025　　　 \*:\*\                                         |
| 　　UDP　CORP1:snmp　　　 \*:\*\                                         |
| 　　UDP　CORP1:nbname　　 \*:\*\                                         |
| 　　UDP　CORP1:nbdatagram \*:\*\                                         |
| 　　UDP　CORP1:nbname　　 \*:\*\                                         |
| 　　UDP　CORP1:nbdatagram \*:\*\                                         |
| \                                                                        |
| 　　C:\\&gt;netstat -s\                                                  |
| 　　IP Statistics\                                                       |
| 　　Packets Received　　　　　　 = 5378528\                              |
| 　　Received Header Errors　　　 = 738854\                               |
| 　　Received Address Errors　　　= 23150\                                |
| 　　Datagrams Forwarded　　　　　= 0\                                    |
| 　　Unknown Protocols Received　 = 0\                                    |
| 　　Received Packets Discarded　 = 0\                                    |
| 　　Received Packets Delivered　 = 4616524\                              |
| 　　Output Requests　　　　　　　= 132702\                               |
| 　　Routing Discards　　　　　　 = 157\                                  |
| 　　Discarded Output Packets　　 = 0\                                    |
| 　　Output Packet No Route　　　 = 0\                                    |
| 　　Reassembly Required　　　　　= 0\                                    |
| 　　Reassembly Successful　　　　　　 = 0\                               |
| 　　Reassembly Failures　　　　　　　 =\                                 |
| 　　Datagrams Successfully Fragmented = 0\                               |
| 　　Datagrams Failing Fragmentation　 = 0\                               |
| 　　Fragments Created　　　　　　　　 = 0\                               |
| ICMP Statistics\                                                         |
| 　　Received　Sent\                                                      |
| 　　Messages　　　　　　　　 693　　　 4\                                |
| 　　Errors　　　　　　　　　 0　　　　 0\                                |
| 　　Destination Unreachable　685　　　 0\                                |
| 　　Time Exceeded　　　　　　0　　　　 0\                                |
| 　　Parameter Problems　　　 0　　　　 0\                                |
| 　　Source Quenches　　　　　0　　　　 0\                                |
| 　　Redirects　　　　　　　　0　　　　 0\                                |
| 　　Echoes　　　　　　　　　 4　　　　 0\                                |
| 　　Echo Replies　　　　　　 0　　　　 4\                                |
| 　　Timestamps　　　　　　　 0　　　　 0\                                |
| 　　Timestamp Replies　　　　0　　　　 0\                                |
| 　　Address Masks　　　　　　0　　　　 0\                                |
| 　　Address Mask Replies　　 0　　　　 0\                                |
| \                                                                        |
| 　　TCP Statistics\                                                      |
| 　　Active Opens　　　　　　　　 = 597\                                  |
| 　　Passive Opens　　　　　　　　= 135\                                  |
| 　　Failed Connection Attempts　 = 107\                                  |
| 　　Reset Connections　　　　　　= 91\                                   |
| 　　Current Connections　　　　　= 8\                                    |
| 　　Segments Received　　　　　　= 106770\                               |
| 　　Segments Sent　　　　　　　　= 118431\                               |
| 　　Segments Retransmitted　　　 = 461\                                  |
| \                                                                        |
| 　　UDP Statistics\                                                      |
| 　　Datagrams Received　 = 4157136\                                      |
| 　　No Ports　　　　　　 = 351928\                                       |
| 　　Receive　Errors　　　 = 2\                                           |
| 　　Datagrams Sent　　　 = 13809\                                        |
| \                                                                        |
| 　　2、Netstat的妙用\                                                    |
| 　　经常上网的人一般都使用ICQ的，不知道我们有没有被一些讨厌的人骚扰，想投诉却又不知从和下手？其实，我们只要知道对方的IP，就可以向他所属的I |
| SP投诉了。但怎样才能通过ICQ知道对方的IP呢？如果对方在设置ICQ时选择了不显示IP地址，那我们是无法在信息栏中看到的。其实，我们只需要通过 |
| Netstat就可以很方便的做到这一点：当他通过ICQ或其他的工具与我们相连时（例如我们给他发一条ICQ信息或他给我们发一条信息），我们立刻在D |
| OS                                                                       |
| 命令提示符下输入netstat -n或netstat                                      |
| -a就可以看到对方上网时所用的IP或ISP域名了，甚至连所用Port都完全暴露了。\ |
| \                                                                        |
| 　　三、IPConfig命令的使用技巧\                                          |
| \                                                                        |
| 　　IPConfig实用程序和它的等价图形用户界面----Windows                    |
| 95/98中的WinIPCfg可用于显示当前的TCP/IP配置的设置值。这些信息一般用来检验人工配置的TCP/IP设置是否正确。但是，如果我们的 |
| 计算机和所在的局域网使用了动态主机配置协议（DHCP），这个程序所显示的信息也许更加实用。这时，IPConfig可以让我们了解自己的计算机是否成 |
| 功的租用到一个IP地址，如果租用到则可以了解它目前分配到的是什么地址。了解计算机当前的IP地址、子网掩码和缺省网关实际上是进行测试和故障分析的必 |
| 要项目。\                                                                |
| 　1、IPConfig最常用的选项\                                               |
| \                                                                        |
| 　　·ipconfig\                                                           |
| \                                                                        |
| 当使用IPConfig时不带任何参数选项，那么它为每个已经配置了的接口显示IP地址、子网掩码和缺省网关值。\ |
|                                                                          |
| \                                                                        |
| 　　·ipconfig /all\                                                      |
| \                                                                        |
| 当使用all选项时，IPConfig能为DNS和WINS服务器显示它已配置且所要使用的附加信息（如IP地址等），并且显示内置于本地网卡中的物理地 |
| 址（MAC）。如果IP地址是从DHCP服务器租用的，IPConfig将显示DHCP服务器的IP地址和租用地址预计失效的日期。\ |
|                                                                          |
| \                                                                        |
| 　　·ipconfig /release和ipconfig /renew\                                 |
| \                                                                        |
| 　　这是两个附加选项，只能在向DHCP服务器租用其IP地址的计算机上起作用。如果我们输入ipconfig |
|                                                                          |
| /release，那么所有接口的租用IP地址便重新交付给DHCP服务器（归还IP地址）。如果我们输入ipconfig |
|                                                                          |
| /renew，那么本地计算机便设法与DHCP服务器取得联系，并租用一个IP地址。请注意，大多数情况下网卡将被重新赋予和以前所赋予的相同的IP地址 |
| 。下面的范例是                                                           |
| ipconfig /all 命令输出，该计算机配置成使用 DHCP 服务器动态配置           |
| TCP/IP，并使用 WINS 和 DNS 服务器解析名称。\                             |
| \                                                                        |
| 　　Windows 2000 IP Configuration\                                       |
| 　　Node Type.. . . . . . . . : Hybrid\                                  |
| 　　IP Routing Enabled.. . . . : No\                                     |
| 　　WINS Proxy Enabled.. . . . : No\                                     |
| 　　Ethernet adapter Local Area Connection:\                             |
| 　　Host Name.. . . . . . . . : corp1.microsoft.com\                     |
| 　　DNS Servers . . . . . . . : 10.1.0.200\                              |
| 　　Deion. . . . . . . : 3Com 3C90x Ethernet Adapter\                    |
| 　　Physical Address. . . . . : 00-60-08-3E-46-07\                       |
| 　　DHCP Enabled.. . . . . . . : Yes\                                    |
| 　　Autoconfiguration Enabled.: Yes\                                     |
| 　　IP Address. . . . . . . . . : 192.168.0.112\                         |
| 　　Subnet Mask. . . . . . . . : 255.255.0.0\                            |
| 　　Default Gateway. . . . . . : 192.168.0.1\                            |
| 　　DHCP Server. . . . . . . . : 10.1.0.50\                              |
| 　　Primary WINS Server. . . . : 10.1.0.101\                             |
| 　　Secondary WINS Server. . . : 10.1.0.102\                             |
| 　　Lease Obtained.. . . . . . : Wednesday, September 02, 1998 10:32:13  |
| AM\                                                                      |
| 　　Lease Expires.. . . . . . : Friday, September 18, 1998 10:32:13 AM   |
| 　\                                                                      |
| \                                                                        |
| 　　如果我们使用的是Windows                                              |
| 95/98，那么我们应该更习惯使用winipcfg而不是ipconfig，因为它是一个图形用户界面，而且所显示的信息与ipconfig相同，并且 |
| 也提供发布和更新动态IP地址的选项。\                                      |
| 四、ARP（地址转换协议）的使用技巧\                                       |
| \                                                                        |
| 　　ARP是一个重要的TCP/IP协议，并且用于确定对应IP地址的网卡物理地址。实用arp命令，我们能够查看本地计算机或另一台计算机的ARP高速 |
| 缓存中的当前内容。此外，使用arp命令，也可以用人工方式输入静态的网卡物理/IP地址对，我们可能会使用这种方式为缺省网关和本地服务器等常用主机进 |
| 行这项作，有助于减少网络上的信息量。\                                    |
| \                                                                        |
| 　　按照缺省设置，ARP高速缓存中的项目是动态的，每当发送一个指定地点的数据报且高速缓存中不存在当前项目时，ARP便会自动添加该项目。一旦高速缓 |
| 存的项目被输入，它们就已经开始走向失效状态。例如，在Windows              |
| NT/2000网络中，如果输入项目后不进一步使用，物理/IP地址对就会在2至10分钟内失效。因此，如果ARP高速缓存中项目很少或根本没有时，请不 |
| 要奇怪，通过另一台计算机或路由器的ping命令即可添加。所以，需要通过arp命令查看高速缓存中的内容时，请最好先ping |
|                                                                          |
| 此台计算机（不能是本机发送ping命令）。\                                  |
| \                                                                        |
| 　　ARP常用命令选项：\                                                   |
| \                                                                        |
| 　　·arp -a或arp Cg\                                                     |
| \                                                                        |
| 　　用于查看高速缓存中的所有项目。-a和-g参数的结果是一样的，多年来-g一直是UNIX平台上用来显示ARP高速缓存中所有项目的选项，而Wind |
| ows用的是arp                                                             |
| -a（-a可被视为all，即全部的意思），但它也可以接受比较传统的-g选项。\     |
| \                                                                        |
| 　　·arp -a IP\                                                          |
| \                                                                        |
| 　　如果我们有多个网卡，那么使用arp                                      |
| -a加上接口的IP地址，就可以只显示与该接口相关的ARP缓存项目。\             |
| \                                                                        |
| 　　·arp -s IP 物理地址\                                                 |
| \                                                                        |
| 　　我们可以向ARP高速缓存中人工输入一个静态项目。该项目在计算机引导过程中将保持有效状态，或者在出现错误时，人工配置的物理地址将自动更新该项目 |
| 。\                                                                      |
| \                                                                        |
| 　　·arp -d IP\                                                          |
| \                                                                        |
| 　　使用本命令能够人工删除一个静态项目。\                                |
| \                                                                        |
| 　　例如我们在命令提示符下，键入 Arp Ca；如果我们使用过 Ping             |
| 命令测试并验证从这台计算机到 IP 地址为 10.0.0.99 的主机的连通性，则 ARP  |
| 缓存显示以下项：\                                                        |
| \                                                                        |
| 　　Interface:10.0.0.1 on interface 0x1\                                 |
| 　　Internet Address　　　Physical Address　　　Type\                    |
| 　　10.0.0.99　　　　　　 00-e0-98-00-7c-dc　　 dynamic\                 |
| 在此例中，缓存项指出位于 10.0.0.99 的远程主机解析成 00-e0-98-00-7c-dc    |
| 的媒体访问控制地址，它是在远程计算机的网卡硬件中分配的。媒体访问控制地址是计算机用于与网络上远程 |
|                                                                          |
| TCP/IP                                                                   |
| 主机物理通讯的地址。至此我们可以用ipconfig和ping命令来查看自己的网络配置并判断是否正确、可以用netstat查看别人与我们所建立的连 |
| 接并找出ICQ使用者所隐藏的IP信息、可以用arp查看网卡的MAC地址。\           |
| \                                                                        |
| 　　五、Tracert、Route 与BTStat的使用技巧\                               |
| \                                                                        |
| 　　1、Tracert的使用技巧　　\                                            |
| \                                                                        |
| 　　如果有网络连通性问题，可以使用 tracert 命令来检查到达的目标 IP       |
| 地址的路径并记录结果。tracert                                            |
| 命令显示用于将数据包从计算机传递到目标位置的一组 IP                      |
| 路由器，以及每个跃点所需的时间。如果数据包不能传递到目标，tracert        |
| 命令将显示成功转发数据包的最后一个路由器。当数据报从我们的计算机经过多个网关传送到目的地时，Tracert命令可以用来跟踪数据报使用的路由（路径 |
| ）。该实用程序跟踪的路径是源计算机到目的地的一条路径，不能保证或认为数据报总遵循这个路径。如果我们的配置使用DNS，那么我们常常会从所产生的应答 |
| 中得到城市、地址和常见通信公司的名字。Tracert是一个运行得比较慢的命令（如果我们指定的目标地址比较远），每个路由器我们大约需要给它15秒钟 |
| 。\                                                                      |
| \                                                                        |
| 　                                                                       |
| Tracert的使用很简单，只需要在tracert后面跟一个IP地址或URL，Tracert会进行相应的域名转换的。\ |
|                                                                          |
| \                                                                        |
| 　　tracert 最常见的用法：\                                              |
| \                                                                        |
| 　　tracert IP address \[-d\] 该命令返回到达 IP                          |
| 地址所经过的路由器列表。通过使用 -d 选项，将更快地显示路由器路径，因为   |
| tracert 不会尝试解析路径中路由器的名称。\                                |
| \                                                                        |
| 　　Tracert一般用来检测故障的位置，我们可以用tracert                     |
| IP在哪个环节上出了问题，虽然还是没有确定是什么问题，但它已经告诉了我们问题所在的地方，我们也就可以很有把握的告诉别人----某某地方出了问题。 |
| \                                                                        |
| \                                                                        |
| 　　2、Route 的使用技巧\                                                 |
| \                                                                        |
| 　　大多数主机一般都是驻留在只连接一台路由器的网段上。由于只有一台路由器，因此不存在使用哪一台路由器将数据报发表到远程计算机上去的问题，该路由器 |
| 的IP地址可作为该网段上所有计算机的缺省网关来输入。但是，当网络上拥有两个或多个路由器时，我们就不一定想只依赖缺省网关了。实际上我们可能想让我们 |
| 的某些远程IP地址通过某个特定的路由器来传递，而其他的远程IP则通过另一个路由器来传递。\ |
|                                                                          |
| \                                                                        |
| 　　在这种情况下，我们需要相应的路由信息，这些信息储存在路由表中，每个主机和每个路由器都配有自己独一无二的路由表。大多数路由器使用专门的路由协议 |
| 来交换和动态更新路由器之间的路由表。但在有些情况下，必须人工将项目添加到路由器和主机上的路由表中。Route就是用来显示、人工添加和修改路由表项 |
| 目的。\                                                                  |
| \                                                                        |
| 一般使用选项：\                                                          |
| \                                                                        |
| 　　·route print\                                                        |
| \                                                                        |
| 　　本命令用于显示路由表中的当前项目，在单路由器网段上的输出；由于用IP地址配置了网卡，因此所有的这些项目都是自动添加的。\ |
|                                                                          |
| \                                                                        |
| 　　·route add\                                                          |
| \                                                                        |
| 　　使用本命令，可以将信路由项目添加给路由表。例如，如果要设定一个到目的网络209.98.32.33的路由，其间要经过5个路由器网段，首先要经过 |
| 本地网络上的一个路由器，器IP为202.96.123.5，子网掩码为255.255.255.224，那么我们应该输入以下命令：\ |
|                                                                          |
| \                                                                        |
| 　　route add 209.98.32.33 mask 255.255.255.224 202.96.123.5 metric 5\   |
| 　　·route change\                                                       |
| \                                                                        |
| 　　我们可以使用本命令来修改数据的传输路由，不过，我们不能使用本命令来改变数据的目的地。下面这个例子可以将数据的路由改到另一个路由器，它采用一条 |
| 包含3个网段的更直的路径：\                                               |
| \                                                                        |
| 　　route add 209.98.32.33 mask 255.255.255.224 202.96.123.250 metric 3\ |
| 　　·route delete\                                                       |
| \                                                                        |
| 　　使用本命令可以从路由表中删除路由。例如：route delete 209.98.32.33\   |
| \                                                                        |
| 　　3、NBTStat的使用技巧\                                                |
| \                                                                        |
| 　　使用 nbtstat 命令释放和刷新 NetBIOS                                  |
| 名称。NBTStat（TCP/IP上的NetBIOS统计数据）实用程序用于提供关于关于NetBIOS的统计数据。运用NetBIOS，我们可以查看 |
| 本地计算机或远程计算机上的NetBIOS名字表格。\                             |
| \                                                                        |
| 　　常用选项：\                                                          |
| 　　·nbtstat Cn\                                                         |
| 　　显示寄存在本地的名字和服务程序。\                                    |
| 　　·nbtstat Cc\                                                         |
| 　　本命令用于显示NetBIOS名字高速缓存的内容。NetBIOS名字高速缓存用于寸放与本计算机最近进行通信的其他计算机的NetBIOS名字和I |
| P地址对。\                                                               |
| 　　·nbtstat Cr\                                                         |
| 　　本命令用于清除和重新加载NetBIOS名字高速缓存。\                       |
| 　　·nbtstat -a IP\                                                      |
| 　　通过IP显示另一台计算机的物理地址和名字列表，我们所显示的内容就像对方计算机自己运行nbtstat |
|                                                                          |
| -n一样。\                                                                |
| 　　·nbtstat -s IP\                                                      |
| \                                                                        |
| 　　显示实用其IP地址的另一台计算机的NetBIOS连接表。例如我们在命令提示符下，键入：nbtstat |
|                                                                          |
| CRR                                                                      |
| 释放和刷新过程的进度以命令行输出的形式显示。该信息表明当前注册在该计算机的 |
|                                                                          |
| WINS 中的所有本地 NetBIOS 名称是否已经使用 WINS 服务器释放和续订了注册。 |
|                                                                          |
| </div>                                                                   |
|                                                                          |
| </div>                                                                   |
+--------------------------------------------------------------------------+

</div>

</div>

</div>

</div>
