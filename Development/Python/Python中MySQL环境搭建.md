Python中MySQL环境搭建
安装mysql

yum install mysql-server

启动mysql

service mysql start

配置mysql

mysql\_secure\_installation

安装mysql驱动

pip install mysql-connector-python-rf

&gt;&gt;&gt; import mysql.connector

conn = mysql.connector.connect(user='root', password='password', database='test', use\_unicode=True)

cursor = conn.cursor()

cursor.execute('create table user (id varchar(20) primary key, name varchar(20))')

cursor.execute('insert into user (id, name) values (%s, %s)', \['1', 'Michael'\])

conn.commit()

cursor.close()

cursor = conn.cursor()

cursor.execute('select \* from user where id = %s', ('1',))

values = cursor.fetchall()

print values

cursor.close()

conn.close()

C的MySQL Python驱动

pip install MySQL-python

import MySQLdb

db = MySQLdb.connect("localhost","myusername","mypassword","mydb" )

cursor = db.cursor()

cursor.execute("SELECT VERSION()")

data = cursor.fetchone()

print "Database version : %s " % data

db.close()


