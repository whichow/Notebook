int--&gt;BYTE\[\]
<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
int data = 123456;
unsigned char buf[4];memcpy(buf, &data, sizeof(int));
```

</div>

<div>

<span style="line-height: 1.6;">BYTE\[\]--&gt;int</span>\

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted}
memcpy(&data, buf, sizeof(int));
```

</div>

<span
style="font-family: Helvetica, 'Hiragino Sans GB', 微软雅黑, 'Microsoft YaHei UI', SimSun, SimHei, arial, sans-serif; white-space: normal;">int--&gt;BYTE\[\]</span>

</div>

</div>

<div>

<div>

``` {.prettyprint .linenums .prettyprinted style=""}
unsigned char* buf = (unsigned char*)&data;
```

</div>

\
<span style="line-height: 28.8999996185303px;"></span>

</div>
