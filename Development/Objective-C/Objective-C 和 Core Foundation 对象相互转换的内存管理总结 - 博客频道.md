Objective-C 和 Core Foundation 对象相互转换的内存管理总结 - 博客频道 -
CSDN.NET
<div>

\

-                        

    [原](#)

                         

    ### [Objective-C 和 Core Foundation 对象相互转换的内存管理总结](http://blog.csdn.net/yiyaaixuexi/article/details/8553659) {#objective-c-和-core-foundation-对象相互转换的内存管理总结 style="padding:12px 0px 8px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:24px;color:inherit;font-weight:normal;line-height:20px;"}

                             

                             

                               <span
    style="color:rgb(51, 51, 51);box-sizing:border-box;width:189.453px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);margin-bottom:5px;display:inline-block;font-size:14px;margin-right:15px;font-weight:normal;height:20px;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">分类：</span>*【iOS
    应用程序开发】*</span>                        

                           

                               <span
    style="color:rgb(187, 187, 187);box-sizing:border-box;width:84.2812px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(187, 187, 187);margin-bottom:5px;display:inline-block;font-size:14px;margin-right:15px;font-weight:normal;height:20px;">*<span
    style="font-style:normal;font-variant:normal;font-weight:normal;line-height:1;font-family:FontAwesome;font-size:inherit;"></span>*<span
    style="color:rgb(102, 102, 102);box-sizing:border-box;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(102, 102, 102);cursor:default;margin:0px;font-weight:normal;font-family:&quot;Microsoft YaHei&quot;;padding:0px;box-shadow:none;">
    （17291）</span></span>                            <span
    style="color:rgb(187, 187, 187);box-sizing:border-box;width:61.0156px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(187, 187, 187);margin-bottom:5px;display:inline-block;font-size:14px;margin-right:15px;font-weight:normal;height:20px;">*<span
    style="font-style:normal;font-variant:normal;font-weight:normal;line-height:1;font-family:FontAwesome;font-size:inherit;"></span>*<span
    style="color:rgb(102, 102, 102);box-sizing:border-box;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(102, 102, 102);cursor:default;margin:0px;font-weight:normal;font-family:&quot;Microsoft YaHei&quot;;padding:0px;box-shadow:none;">
    （10）</span></span>                                                
                                                                 

                           

                         

                           

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:bold;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;font-size:18px;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"><span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:'Lucida Grande', 'Lucida Sans Unicode', Helvetica, Arial, Verdana, sans-serif;font-weight:normal;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">Objective-C</span>
    和 Core Foundation 对象相互转换的内存管理总结</span></span>\

    **<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;font-size:18px;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">\
    </span>**

    \

    iOS允许<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;text-align:center;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">Objective-C</span>
    和 Core Foundation 对象之间可以轻松的转换，拿 NSString 和
    CFStringRef 来说，直接转换豪无压力：

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CFStringRef aCFString = (CFStringRef)aNSString;  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">NSString \*aNSString = (NSString \*)aCFString;  </span>

    \
    \
    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span>

    \

    针对内存管理问题，ARC 可以帮忙管理 Objective-C 对象, 但是不支持 Core
    Foundation
    对象的管理，所以转换后要注意一个问题：谁来释放使用后的对象。 本文重点总结一下类型转换后的内存管理。

    \

    \

    一、非ARC的内存管理 {#一非arc的内存管理 style="padding:0px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:30px;color:inherit;line-height:1.1;font-weight:normal;"}
    -------------------

    \
    倘若不使用ARC，手动管理内存，思路比较清晰，使用完，release转换后的对象即可。

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//NSString 转 CFStringRef</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CFStringRef aCFString = (CFStringRef) \[\[NSString alloc\] initWithFormat:@<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">"%@"</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">, string\];  </span></span>
    3.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//...</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
    4.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CFRelease(aCFString);  </span>
    5.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span>
    6.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span>
    7.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//CFStringRef 转 NSString</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
    8.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CFStringRef aCFString = CFStringCreateWithCString(kCFAllocatorDefault,  </span>
    9.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">                                                  bytes,  </span>
    10. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">                                                  NSUTF8StringEncoding);  </span>
    11. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">NSString \*aNSString = (NSString \*)aCFString;  </span>
    12. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//...</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
    13. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\[aNSString release\];  </span>

    \
    \

    \

    \

    二、ARC下的内存管理 {#二arc下的内存管理 style="padding:0px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:30px;color:inherit;line-height:1.1;font-weight:normal;"}
    -------------------

    \

    ARC的诞生大大简化了我们针对内存管理的开发工作，但是只支持管理
    Objective-C 对象, 不支持 Core Foundation 对象。Core Foundation
    对象必须使用CFRetain和CFRelease来进行内存管理。那么当使用Objective-C
    和 Core Foundation
    对象相互转换的时候，必须让编译器知道，到底由谁来负责释放对象，是否交给ARC处理。只有正确的处理，才能避免内存泄漏和double
    free导致程序崩溃。

    \

    根据不同需求，有3种转换方式

    -   \_\_bridge <span
        style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span> 
                      <span
        style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;white-space:pre;border:0px none rgb(51, 51, 51);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span>（不改变对象所有权）
    -   \_\_bridge\_retained 或者 CFBridgingRetain()              <span
        style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;white-space:pre;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span>（解除 ARC
        所有权）

    -   \_\_bridge\_transfer 或者 CFBridgingRelease()            <span
        style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;white-space:pre;border:0px none rgb(102, 102, 102);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;"></span>（

        给予 ARC 所有权）

    \

    \

    \

    ### 1. \_\_bridge\_retained 或者 CFBridgingRetain()  {#bridge_retained或者cfbridgingretain style="padding:0px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:24px;color:inherit;line-height:1.1;font-weight:normal;"}

    \

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;background-color:rgb(255, 255, 255);border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;">\_\_bridge\_retained 或者 CFBridgingRetain()
     将Objective-C对象转换为Core Foundation对象，把对象所有权桥接给Core
    Foundation对象，同时剥夺ARC的管理权，后续需要开发者使用CFRelease或者相关方法手动来释放对象。</span>\

    \

    来看个例子：

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">- (</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)viewDidLoad  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">{  </span>
    3.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    \[super viewDidLoad\];  </span>
    4.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">      </span>
    5.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    NSString \*aNSString = \[\[NSString alloc\]initWithFormat:@<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"test"</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
    6.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    CFStringRef aCFString = (\_\_bridge\_retained CFStringRef) aNSString;  </span>
    7.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">      </span>
    8.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    (<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">)aCFString;  </span></span>
    9.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">      </span>
    10. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">//正确的做法应该执行CFRelease</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">  </span></span>
    11. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 130, 0);color:rgb(0, 130, 0);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">//CFRelease(aCFString); </span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">  </span></span>
    12. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">}  </span>

    \

    程序没有执行CFRelease，造成内存泄漏：

    \

    ![](Objective-C%20和%20Core%20Foundation%20对象相互转换的内存管理总结%20-%20博客频道_files/1359547398_2147.png){width="645"
    height="185"}\

    \

    \

    \

    CFBridgingRetain()  是 \_\_bridge\_retained
    的宏方法，下面两行代码等价：\

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">CFStringRef aCFString = (\_\_bridge\_retained CFStringRef) aNSString;  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">CFStringRef aCFString = (CFStringRef) CFBridgingRetain(aNSString);  </span>

    \
    \

    \

    \

    \

    ### 2. \_\_bridge\_transfer 或者 CFBridgingRelease() {#bridge_transfer或者cfbridgingrelease style="padding:0px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:24px;color:inherit;line-height:1.1;font-weight:normal;"}

    \

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;background-color:rgb(255, 255, 255);border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;">\_\_bridge\_transfer 或者 CFBridgingRelease()
     将非Objective-C对象转换为Objective-C对象，同时将对象的管理权交给ARC，开发者无需手动管理内存。</span>\

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;background-color:rgb(255, 255, 255);border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;">\
    </span>

    接着上面那个内存泄漏的例子，再转成OC对象交给ARC来管理内存，无需手动管理，也不会出现内存泄漏：

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">- (</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)viewDidLoad  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">{  </span>
    3.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    \[super viewDidLoad\];  </span>
    4.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">      </span>
    5.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    NSString \*aNSString = \[\[NSString alloc\]initWithFormat:@<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"test"</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
    6.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    CFStringRef aCFString = (\_\_bridge\_retained CFStringRef) aNSString;  </span>
    7.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    aNSString = (\_\_bridge\_transfer NSString \*)aCFString;  </span>
    8.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">}  </span>

    \
    CFBridgingRelease()
    是\_\_bridge\_transfer的宏方法，下面两行代码等价：\

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">aNSString = (\_\_bridge\_transfer NSString \*)aCFString;  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">aNSString = (NSString \*)CFBridgingRelease(aCFString);  </span>

    \

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;background-color:rgb(255, 255, 255);border:0px none rgb(51, 51, 51);background-image:none;box-shadow:none;"></span>

    ### 3. \_\_bridge  {#bridge style="padding:0px;box-sizing:border-box;width:793.031px;box-shadow:none;background-image:none;background-color:rgba(0, 0, 0, 0);border:0px none rgb(51, 51, 51);font-family:"Microsoft YaHei";margin:0px;font-size:24px;color:inherit;line-height:1.1;font-weight:normal;"}

    \

    \_\_bridge 只做类型转换，不改变对象所有权，是我们最常用的转换符。

    \

    从OC转CF，ARC管理内存：

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">- (</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)viewDidLoad  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">{  </span>
    3.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    \[super viewDidLoad\];  </span>
    4.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">      </span>
    5.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    NSString \*aNSString = \[\[NSString alloc\]initWithFormat:@<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"test"</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">\];  </span></span>
    6.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    CFStringRef aCFString = (\_\_bridge CFStringRef)aNSString;  </span>
    7.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">      </span>
    8.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    (<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">)aCFString;  </span></span>
    9.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">}  </span>

    \
    \

    从CF转OC，需要开发者手动释放，不归ARC管：

    \

    **\[cpp\]** [view
    plain](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "view plain")<span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    [copy](http://blog.csdn.net/yiyaaixuexi/article/details/8553659# "copy")</span>

    <span
    style="box-sizing:border-box;margin:0px;padding:0px;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;border:0px none rgb(192, 192, 192);background-color:rgba(0, 0, 0, 0);background-image:none;box-shadow:none;">
    </span>

    1.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;"><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">- (</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">)viewDidLoad  </span></span>
    2.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">{  </span>
    3.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    \[super viewDidLoad\];  </span>
    4.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">      </span>
    5.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">    CFStringRef aCFString = CFStringCreateWithCString(NULL, <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 255);color:blue;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">"test"</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">, kCFStringEncodingASCII);  </span></span>
    6.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    NSString \*aNSString = (\_\_bridge NSString \*)aCFString;  </span>
    7.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">      </span>
    8.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    (<span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;margin:0px;padding:0px;font-weight:bold;border:0px none rgb(0, 102, 153);color:rgb(0, 102, 153);background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">void</span><span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">)aNSString;  </span></span>
    9.  <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">      </span>
    10. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(248, 248, 248);background-image:none;box-shadow:none;">    CFRelease(aCFString);  </span>
    11. <span
        style="box-sizing:border-box;font-family:&quot;Microsoft YaHei&quot;;font-weight:normal;margin:0px;padding:0px;border:0px none rgb(0, 0, 0);color:black;background-color:rgb(255, 255, 255);background-image:none;box-shadow:none;">}  </span>

    \
    \

    \

                         

                       

\

</div>
