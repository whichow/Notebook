```shell
adduser user    //新增一个用户
passwd user     //设置用户密码
```
执行sudo时提示"user is not in the sudoers file"解决方法
```shell
visudo
```
找到这一行
```
root ALL=(ALL) ALL
```
在后面添加
```
user ALL=(ALL) ALL
```