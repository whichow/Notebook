在Python中执行shell命令可以使用以下几种方式：
1. 使用`os.system()`，返回值为系统返回值，如：
```python
os.system("mkdir path")
```
2. 使用`os.popen()`，返回值为命令行输出，如：
```python
ls = os.popen("ls")
print ls
```