# C类型转换
int--&gt;BYTE\[\]
```c
int data = 123456;
unsigned char buf[4];
memcpy(buf, &data, sizeof(int));
```

BYTE\[\]--&gt;int

```c
memcpy(&data, buf, sizeof(int));
```

int--&gt;BYTE\[\]

```c
unsigned char* buf = (unsigned char*)&data;
```


