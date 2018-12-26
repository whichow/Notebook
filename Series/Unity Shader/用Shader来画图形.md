- 画正方形

要画正方形，我们可以通过UV是否大于或者小于某个值来设置颜色

```
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    if(i.uv.x < 0.1)
    {
    	col.rgb = 0.;
    }
    if(i.uv.y < 0.1)
    {
    	col.rgb = 0.;
    }
    if(i.uv.x > 0.9)
    {
    	col.rgb = 0.;
    }
    if(i.uv.y > 0.9)
    {
    	col.rgb = 0.;
    }
    return col;
}
```

改进写法，通过step来实现比较

```
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    float left = step(.1, i.uv.x);
    float bottom = step(.1, i.uv.y);
    float right = step(i.uv.x, .9);
    float up = step(i.uv.y, .9);
    float c = left * bottom * right * up;
    col.rgb = float3(c, c, c);
    return col;
}
```

- 画圆形

```
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    //设置圆的中心点
    float2 center = float2(.5, .5);
    //判断与中心点的距离
    float d = distance(i.uv, center);
    if(d > .5)
    {
    	col.rgb = 0.;
    }
    return col;
}
```

改进写法

```
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    float2 center = float2(.5, .5);
    //与中心点的距离
    float d = distance(i.uv, center);
    //小于0.5为1，否则为0
    float c = step(d, .5);
    col.rgb = float3(c, c, c);
    return col;
}
```

对圆做平滑处理

```
fixed4 frag (v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    float2 center = float2(.5, .5);
    //与中心点的距离
    float d = distance(i.uv, center);
    //小于0.5为1，否则为0
    float c = smoothstep(.49, .51, d);
    col.rgb = float3(c, c, c);
    return col;
}
```

- 画重复图案

如果要画重复图案，可以通过frac函数来实现，frac函数的功能就是取小数部分

```
frac(i.uv * 10);  //先将uv放大10倍，再用frac取小数，图案就能重复10次了
```

