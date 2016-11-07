int--&gt;BYTE\[\]
``` prettyprint
int data = 123456;
unsigned char buf[4];memcpy(buf, &data, sizeof(int));
```

BYTE\[\]--&gt;int

``` prettyprint
memcpy(&data, buf, sizeof(int));
```

int--&gt;BYTE\[\]

``` prettyprint
unsigned char* buf = (unsigned char*)&data;
```


