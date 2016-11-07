``` prettyprint
int length = sizeof(arr) / sizeof(arr[0]);
```

如果是字符数组的话还可以用strlen()来获取字符串长度(数组长度-1)：

``` prettyprint
char data[4] = { 'd', 'a', 'y', '\0' };int length = strlen(data);    //length = 3
```


