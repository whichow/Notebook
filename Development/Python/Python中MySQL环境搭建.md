Python中MySQL环境搭建
<div>

<div>

安装mysql

</div>

<div>

yum install mysql-server

</div>

<div>

启动mysql

</div>

<div>

service mysql start

</div>

<div>

配置mysql

</div>

<div>

mysql\_secure\_installation

</div>

<div>

安装mysql驱动

</div>

<div>

pip install mysql-connector-python-rf

</div>

<div>

\

</div>

<div
style="box-sizing: border-box; padding: 8px; border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.148438);">

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">&gt;&gt;&gt; import mysql.connector</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">conn = mysql.connector.connect(user='root', password='password', database='test', use\_unicode=True)</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor = conn.cursor()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor.execute('create table user (id varchar(20) primary key, name varchar(20))')</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor.execute('insert into user (id, name) values (%s, %s)', \['1', 'Michael'\])</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">conn.commit()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor.close()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">\
</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor = conn.cursor()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor.execute('select \* from user where id = %s', ('1',))</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">values = cursor.fetchall()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">print values</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">cursor.close()</span></span></span>

</div>

<div>

<span style="font-size: 12px;"><span
style="font-family: Monaco, Menlo, Consolas, 'Courier New', monospace;"><span
style="color: rgb(51, 51, 51);">conn.close()</span></span></span>

</div>

</div>

<div>

\

</div>

<div>

C的MySQL Python驱动

</div>

<div>

pip install MySQL-python

</div>

<div>

\

</div>

<div
style="-en-codeblock: true; box-sizing: border-box; padding: 8px; font-family: Monaco, Menlo, Consolas, &quot;Courier New&quot;, monospace; font-size: 12px; color: rgb(51, 51, 51); border-top-left-radius: 4px; border-top-right-radius: 4px; border-bottom-right-radius: 4px; border-bottom-left-radius: 4px; background-color: rgb(251, 250, 248); border: 1px solid rgba(0, 0, 0, 0.14902); background-position: initial initial; background-repeat: initial initial;">

<div>

import MySQLdb

</div>

<div>

db = MySQLdb.connect("localhost","myusername","mypassword","mydb" )

</div>

<div>

cursor = db.cursor()

</div>

<div>

cursor.execute("SELECT VERSION()")

</div>

<div>

data = cursor.fetchone()

</div>

<div>

\

</div>

<div>

print "Database version : %s " % data

</div>

<div>

db.close()

</div>

</div>

<div>

\

</div>

</div>
