Windows默认编码为gkb，而编辑器一般都为utf-8，所以读取/输出控制台或者创建/写入Windows文件时会出现乱码，这时候就需要进行转码

控制台输出时 
str.decode('gbk').encode('utf-8')    \#gbk-&gt;unicode-&gt;utf-8
创建文件时 

str.decode('utf-8').encode('gbk')    \#utf-8-&gt;unicode-&gt;gbk


