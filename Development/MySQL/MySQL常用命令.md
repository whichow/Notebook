mysql -u root -p password    打开MySQL

show databases;    列出所有数据库

create database wordpress;    创建名为wordpress的数据库

drop database xxx;    删除数据库

use mydatabase\_db;    使用mydabase\_db数据库

show tables;    列出当前数据库中的所有表

show tables from otherdatabase\_db;    列出otherdatabase\_db中的所有表

desc | describe mytable;    列出当前数据库中mytable的表结构

show columns from mytable;    等同于desc

show columns from mytable from mydatabase\_db;    列出mydatabase\_db中mytable表的结构


