### 使用mysqldump命令备份数据库
```shell
$ mysqldump --opt -u [name] -p [pass] [dbname] > [backup.sql]
```
- [name]数据库用户名
- [pass]数据库密码
- [dbname]数据库名
- [backup.sql]备份的数据库文件名
例如，要备份一个名为'Tutorials'的数据库到'tut_backup.sql'文件中，数据库的用户名为'root'密码为空，可以使用下面的命令：
```shell
$ mysqldump -u root -p Tutorials > tut_backup.sql
```
还可以备份数据库中指定的表，例如，只备份'Tutorial'数据库中的'php_tutorials'和'asp_tutorials'表，可以使用下面的命令，表之间用空格隔开：
```shell
$ mysqldump -u root -p Tutorials php_tutorials asp_tutorials > tut_backup.sql
```
有时候还需要一次性备份多个数据库。这种情况下可以使用'--database'选项，后面跟要备份的数据库列表。数据库之间使用空格隔开：
```shell
$ mysqldump -u root -p --databases Tutorials Articles Comments > content_backup.sql
```
如果想要备份所有的数据库，则可以使用'--all-databases'选项
```shell
$ mysqldump -u root -p --all-databases > alldb_backup.sql
```
还有一些其他有用的选项：
`--add-drop-table`: 在导出的文件中已经存在同名的表，则删除掉原来的表
`--no-data`: 只导出数据库的结构，而不导出内容
`--add-locks`: 导出过程中给数据的表加锁

如果你的MySQL数据库非常大，你可能需要压缩导出的数据库文件，我们使用管道输出到gzip，最后输出gzip文件：
```shell
$ mysqldump -u [name] -p [pass] [dbname] | gzip -9 > [backup.sql.gz]
```
解压命令：
```shell
$ gunzip [backup.sql.gz]
```
### 恢复MySQL数据库
要恢复之前备份的数据库，需要以下两个步骤：
- 创建一个相同名字的数据库
- 将文件内容加载到数据库中
```shell
$ mysql -u [name] -p [pass] [db_to_restore] < [backupfile.sql]
```
将之前备份的'tut_backup.sql'恢复到'Tutorials'数据库中：
```shell
$ mysql -u root -p Tutorials < tut_backup.sql
```
要恢复压缩过的备份文件，可以使用：
```shell
$ gunzip < [backup.sql.gz] | mysql -u [name] -p [pass] [dbname]
```
如果要恢复一个已经存在的数据库，需要使用`mysqlimport`命令：
```shell
$ mysqlimport -u [name] -p [pass] [dbname] [backup.sql]
```

[How to Back Up and Restore a MySQL Database](http://webcheatsheet.com/sql/mysql_backup_restore.php)

[Backing Up Your Database](https://codex.wordpress.org/Backing_Up_Your_Database)

[Restoring Your Database From Backup](https://codex.wordpress.org/Restoring_Your_Database_From_Backup)