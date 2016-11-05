<div id="page">

<div id="content" class="clearfix">

<div id="main">

<div class="blog_main">

<div id="blog_content" class="blog_content">

<div
style="display: block; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 14px; font-family: Helvetica, Tahoma, Arial, sans-serif; height: 1879px; line-height: 25.2000007629395px; margin: 0px; padding: 0px; text-align: left; text-decoration: none; width: 700px;">

<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">首先看两个概念：  </span>\
**短连接： **<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">连接-&gt;传输数据-&gt;关闭连接  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">HTTP是无状态的，浏览器和服务器每进行一次HTTP操作，就建立一次连接，但任务结束就中断连接。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">也可以这样说：短连接是指SOCKET连接后发送后接收完数据后马上断开连接。  </span>\
\
**长连接： **<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">连接-&gt;传输数据-&gt;保持连接
-&gt; 传输数据-&gt; 。。。 -&gt;关闭连接。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">长连接指建立SOCKET连接后不管是否使用都保持连接，但安全性较差。  </span>\
\
<span
style="border: 0px none rgb(229, 51, 51); color: rgb(229, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(229, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">**之所以出现粘包和半包现象,是因为TCP当中,只有流的概念,没有包的概念. **</span><span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
\
<span
style="border: 0px none rgb(51, 127, 229); color: rgb(51, 127, 229); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(51, 127, 229) none 0px; padding: 0px; text-align: left; text-decoration: none;">**半包 **</span><span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">指接受方没有接受到一个完整的包，只接受了部分，这种情况主要是由于TCP为提高传输效率，将一个包分配的足够大，导致接受方并不能一次接受完。（ </span>**<span
style="border: 0px none rgb(229, 51, 51); color: rgb(229, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: bold; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(229, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">在长连接和短连接中都会出现</span>**<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">）。  </span>\
\
<span
style="border: 0px none rgb(51, 127, 229); color: rgb(51, 127, 229); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(51, 127, 229) none 0px; padding: 0px; text-align: left; text-decoration: none;">**粘包与分包 **</span><span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">指发送方发送的若干包数据到接收方接收时粘成一包，从接收缓冲区看，后一包数据的头紧接着前一包数据的尾。出现粘包现象的原因是多方面的，它既可能由发送方造成，也可能由接收方造成。发送方引起的粘包是由TCP协议本身造成的，TCP为提高传输效率，发送方往往要收集到足够多的数据后才发送一包数据。若连续几次发送的数据都很少，通常TCP会根据优化算法把这些数据合成一包后一次发送出去，这样接收方就收到了粘包数据。接收方引起的粘包是由于接收方用户进程不及时接收数据，从而导致粘包现象。这是因为接收方先把收到的数据放在系统接收缓冲区，用户进程从该缓冲区取数据，若下一包数据到达时前一包数据尚未被用户进程取走，则下一包数据放到系统接收缓冲区时就接到前一包数据之后，而用户进程根据预先设定的缓冲区大小从系统接收缓冲区取数据，这样就一次取到了多包数据。分包是指在出现粘包的时候我们的接收方要进行分包处理。（在长连接中都会出现）  </span>\
\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">什么时候需要考虑半包的情况?  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">从备注中我们了解到Socket内部默认的收发缓冲区大小大概是8K，但是我们在实际中往往需要考虑效率问题，重新配置了这个值，来达到系统的最佳状态。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">一个实际中的例子：用mina作为服务器端，使用的缓存大小为10k，这里使用的是短连接，所有不用考虑粘包的问题。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">问题描述：在并发量比较大的情况下，就会出现一次接受并不能完整的获取所有的数据。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">处理方式：  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">1.通过包头
包长
包体的协议形式，当服务器端获取到指定的包长时才说明获取完整。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">2.指定包的结束标识，这样当我们获取到指定的标识时，说明包获取完整。  </span>\
\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">什么时候需要考虑粘包的情况?  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">1.当时短连接的情况下，不用考虑粘包的情况  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">2.如果发送数据无结构，如文件传输，这样发送方只管发送，接收方只管接收存储就ok，也不用考虑粘包  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">3.如果双方建立连接，需要在连接后一段时间内发送不同结构数据  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">处理方式：  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">接收方创建一预处理线程，对接收到的数据包进行预处理，将粘连的包分开  </span>\
<span
style="border: 0px none rgb(229, 51, 51); color: rgb(229, 51, 51); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(229, 51, 51) none 0px; padding: 0px; text-align: left; text-decoration: none;">**注：粘包情况有两种，一种是粘在一起的包都是完整的数据包，另一种情况是粘在一起的包有不完整的包 **</span><span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;"> </span>\
\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">备注:  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">一个包没有固定长度，以太网限制在46－1500字节，1500就是以太网的MTU，超过这个量，TCP会为IP数据报设置偏移量进行分片传输，现在一般可允许应用层设置8k（NTFS系）的缓冲区，8k的数据由底层分片，而应用看来只是一次发送。windows的缓冲区经验值是4k,Socket本身分为两种，流(TCP)和数据报(UDP)，你的问题针对这两种不同使用而结论不一样。甚至还和你是用阻塞、还是非阻塞Socket来编程有关。  </span>\
<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">1、通信长度，这个是你自己决定的，没有系统强迫你要发多大的包，实际应该根据需求和网络状况来决定。对于TCP，这个长度可以大点，但要知道，Socket内部默认的收发缓冲区大小大概是8K，你可以用SetSockOpt来改变。但对于UDP，就不要太大，一般在1024至10K。注意一点，你无论发多大的包，IP层和链路层都会把你的包进行分片发送，一般局域网就是1500左右，广域网就只有几十字节。分片后的包将经过不同的路由到达接收方，对于UDP而言，要是其中一个分片丢失，那么接收方的IP层将把整个发送包丢弃，这就形成丢包。显然，要是一个UDP发包佷大，它被分片后，链路层丢失分片的几率就佷大，你这个UDP包，就佷容易丢失，但是太小又影响效率。最好可以配置这个值，以根据不同的环境来调整到最佳状态。  </span>

send()函数返回了实际发送的长度，在网络不断的情况下，它绝不会返回(发送失败的)错误，最多就是返回0。对于TCP你可以字节写一个循环发送。当send函数返回SOCKET\_ERROR时，才标志着有错误。但对于UDP，你不要写循环发送，否则将给你的接收带来极大的麻烦。所以UDP需要用SetSockOpt来改变Socket内部Buffer的大小，以能容纳你的发包。明确一点，TCP作为流，发包是不会整包到达的，而是源源不断的到，那接收方就必须组包。而UDP作为消息或数据报，它一定是整包到达接收方。 

 

<span
style="border: 0px none rgb(68, 68, 68); color: rgb(68, 68, 68); display: inline; font-style: normal; font-variant: normal; font-weight: normal; font-stretch: normal; font-size: 16px; font-family: Arial, Helvetica, sans-serif; line-height: 24px; margin: 0px; outline: rgb(68, 68, 68) none 0px; padding: 0px; text-align: left; text-decoration: none;">2、关于接收，一般的发包都有包边界，首要的就是你这个包的长度要让接收方知道，于是就有个包头信息，对于TCP，接收方先收这个包头信息，然后再收包数据。一次收齐整个包也可以，可要对结果是否收齐进行验证。这也就完成了组包过程。UDP，那你只能整包接收了。要是你提供的接收Buffer过小，TCP将返回实际接收的长度，余下的还可以收，而UDP不同的是，余下的数据被丢弃并返回WSAEMSGSIZE错误。注意TCP，要是你提供的Buffer佷大，那么可能收到的就是多个发包，你必须分离它们，还有就是当Buffer太小，而一次收不完Socket内部的数据，那么Socket接收事件(OnReceive)，可能不会再触发，使用事件方式进行接收时，密切注意这点。这些特性就是体现了流和数据包的区别。
 </span>

</div>

</div>

</div>

</div>

</div>

</div>
