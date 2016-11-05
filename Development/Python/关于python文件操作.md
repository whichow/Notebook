<span
style="line-height: 1.6;">python中对文件、文件夹（文件操作函数）的操作需要涉及到os模块和shutil模块。</span>\

<div>

<span><span>得到当前工作目录，即当前Python脚本工作的目录路径</span>: os.getcwd()</span>

<span><span>返回指定目录下的所有文件和目录名</span>:os.listdir()</span>

<span><span>函数用来删除一个文件</span>:os.remove()</span>

<span>删除多个目录</span>：<span>os.removedirs（r“c：\\python”）</span>

<span><span>检验给出的路径是否是一个文件</span>：os.path.isfile()</span>

<span>检验给出的路径是否是一个目录：os.path.isdir()</span>

判断是否是绝对路径：<span>os.path.isabs()</span>

<span>检验给出的路径是否真地存:</span><span>os.path.</span><span>exists()</span>

<span>返回一个路径的目录名和文件名:os.path.split()  <span>   eg
os.path.split('/home/swaroop/byte/code/poem.txt')
结果：('/home/swaroop/byte/code', 'poem.txt') </span>\
</span>

分离扩展名：<span>os.path.splitext()</span>

获取路径名：<span>os.path.dirname()</span>

获取文件名：<span>os.path.basename()</span>

<span>运行shell命令: os.system()</span>

<span>读取和设置环境变量:os.getenv() 与os.putenv()</span>

<span>给出当前平台使用的行终止符:os.linesep    <span>Windows使用'\\r\\n'，Linux使用'\\n'而Mac使用'\\r'</span></span>

<span>指示你正在使用的平台：os.name <span>     
对于Windows，它是'nt'，而对于Linux/Unix用户，它是'posix'</span></span>

重命名：<span>os.rename（old， new）</span>

创建多级目录：<span>os.makedirs（r“c：\\python\\test”）</span>

创建单个目录：<span>os.mkdir（“test”）</span>

获取文件属性：<span>os.stat（file）</span>

修改文件权限与时间戳：<span>os.chmod（file）</span>

终止当前进程：<span>os.exit（）</span>

获取文件大小：<span>os.path.getsize（filename）</span>

\
<span>文件操作：</span>\
<span>os.mknod("test.txt") <span>       创建空文件</span></span>\
<span>fp = open("test.txt",w)  <span>  
直接打开一个文件，如果文件不存在则创建文件</span></span>

关于open 模式：

<span><span>w     以写方式打开，</span>\
<span>a     以追加模式打开 (从 EOF 开始, 必要时创建新文件)</span>\
<span>r+     以读写模式打开</span>\
<span>w+     以读写模式打开 (参见 w )</span>\
<span>a+     以读写模式打开 (参见 a )</span>\
<span>rb     以二进制读模式打开</span>\
<span>wb     以二进制写模式打开 (参见 w )</span>\
<span>ab     以二进制追加模式打开 (参见 a )</span>\
<span>rb+    以二进制读写模式打开 (参见 r+ )</span>\
<span>wb+    以二进制读写模式打开 (参见 w+ )</span>\
<span>ab+    以二进制读写模式打开 (参见 a+ )</span></span>

<span> </span>

<span>fp.read(\[size\])  <span>  </span></span>                 \#size为读取的长度，以byte为单位

<span>fp.readline(\[size\])  </span>              
\#读一行，如果定义了size，有可能返回的只是一行的一部分

<span>fp.readlines(\[size\])   </span>            
\#把文件每一行作为一个list的一个成员，并返回这个list。其实它的内部是通过循环调用readline()来实现的。如果提供size参数，size是表示读取内容的总长，也就是说可能只读到文件的一部分。

<span>fp.write(str)  </span><span> </span><span>                  
\#把str写到文件中，write()并不会在str后加上一个换行符</span>

<span>fp.writelines(seq)    </span>       
\#把seq的内容全部写到文件中(多行一次性写入)。这个函数也只是忠实地写入，不会在每行后面加上任何东西。

<span>fp.close()   </span>                    
\#关闭文件。python会在一个文件不用后自动关闭文件，不过这一功能没有保证，最好还是养成自己关闭的习惯。 
如果一个文件在关闭后还对其进行操作会产生ValueError

<span>fp.flush()   </span>                                  
\#把缓冲区的内容写入硬盘

<span>fp.fileno()    </span>                                 
\#返回一个长整型的”文件标签“

<span>fp.isatty()    </span>                                 
\#文件是否是一个终端设备文件（unix系统中的）

<span>fp.tell()</span>                                        
\#返回文件操作标记的当前位置，以文件的开头为原点

<span>fp.next()    </span>                                  
\#返回下一行，并将文件操作标记位移到下一行。把一个file用于for … in
file这样的语句时，就是调用next()函数来实现遍历的。

<span>fp.seek(offset\[,whence\])  </span>           
\#将文件打操作标记移到offset的位置。这个offset一般是相对于文件的开头来计算的，一般为正数。但如果提供了whence参数就不一定了，whence可以为0表示从头开始计算，1表示以当前位置为原点计算。2表示以文件末尾为原点进行计算。需要注意，如果文件以a或a+的模式打开，每次进行写操作时，文件操作标记会自动返回到文件末尾。

<span>fp.truncate(\[size\])   </span>                   
\#把文件裁成规定的大小，默认的是裁到当前文件操作标记的位置。如果size比文件的大小还要大，依据系统的不同可能是不改变文件，也可能是用0把文件补到相应的大小，也可能是以一些随机的内容加上去。

<span>目录操作：</span>\
<span>os.mkdir("file")  </span><span>   </span><span>             
创建目录</span>\
<span>复制文件：</span>\
<span>shutil.copyfile("oldfile","newfile") <span>     
oldfile和newfile都只能是文件</span></span>\
<span>shutil.copy("oldfile","newfile")   <span>        
oldfile只能是文件夹，newfile可以是文件，也可以是目标目录</span></span>\
<span>复制文件夹：</span>\
<span>shutil.copytree("olddir","newdir") <span>      
olddir和newdir都只能是目录，且newdir必须不存在</span></span>\
<span>重命名文件（目录）</span>\
<span>os.rename("oldname","newname") <span>     
文件或目录都是使用这条命令</span></span>\
<span>移动文件（目录）</span>\
<span>shutil.move("oldpos","newpos")   </span>\
<span>删除文件</span>\
<span>os.remove("file")</span>\
<span>删除目录</span>\
<span>os.rmdir("dir")<span>只能删除空目录</span></span>\
<span>shutil.rmtree("dir")  <span> 
空目录、有内容的目录都可以删</span></span>\
<span>转换目录</span>\
<span>os.chdir("path")   <span>换路径</span></span>

<span>相关例子 </span>

<span> 1 </span>将文件夹下所有图片名称加上'\_fc'

<span>python代码:</span>

<span>\# -\*- coding:utf-8 -\*-</span>\
<span>import re</span>\
<span>import os</span>\
<span>import time</span>\
<span>\#str.split(string)分割字符串</span>\
<span>\#'连接符'.join(list) 将列表组成字符串</span>\
<span>def change\_name(path):</span>\
<span>    global i</span>\
<span>    if not os.path.isdir(path) and not
os.path.isfile(path):</span>\
<span>        return False</span>\
<span>    if os.path.isfile(path):</span>\
<span>        file\_path =
os.path.split(path) <span>\#分割出目录与文件</span></span>\
<span>        lists =
file\_path\[1\].split('.') <span>\#分割出文件与文件扩展名</span></span>\
<span>        file\_ext =
lists\[-1\] <span>\#取出后缀名(列表切片操作)</span></span>\
<span>        img\_ext =
\['bmp','jpeg','gif','psd','png','jpg'\]</span>\
<span>        if file\_ext in img\_ext:</span>\
<span>           
os.rename(path,file\_path\[0\]+'/'+lists\[0\]+'\_fc.'+file\_ext)</span>\
<span>            i+=1 <span>\#注意这里的i是一个陷阱</span></span>\
<span>        \#或者</span>\
<span>        \#img\_ext = 'bmp|jpeg|gif|psd|png|jpg'</span>\
<span>        \#if file\_ext in img\_ext:</span>\
<span>        \#    print('ok---'+file\_ext)</span>\
<span>    elif os.path.isdir(path):</span>\
<span>        for x in os.listdir(path):</span>\
<span>           
change\_name(os.path.join(path,x)) <span>\#os.path.join()在路径处理上很有用</span></span>

\
<span>img\_dir = 'D:\\\\xx\\\\xx\\\\images'</span>\
<span>img\_dir = img\_dir.replace('\\\\','/')</span>\
<span>start = time.time()</span>\
<span>i = 0</span>\
<span>change\_name(img\_dir)</span>\
<span>c = time.time() - start</span>\
<span>print('程序运行耗时:%0.2f'%(c))</span>\
<span>print('总共处理了 %s 张图片'%(i))</span>

输出结果：

<span>程序运行耗时:0.11</span>\
<span>总共处理了 109 张图片</span>

</div>
