使用material.SetXXX可以给Shader中的对应变量赋值

```csharp
material.SetMatrix("_MVPMatrix", mvp);
material.SetMatrix("_MVMatrix", mv);
material.SetMatrix("_VMatrix", v);
material.SetColor("_Color", Color.red);
```

Properties只是在Unity Editor面板上显示，可以不在Properties中声明属性而直接赋值
```shader
Shader "Custom/MVP" {
    Properties{
        _Color("Color",COLOR) = (1,1,1,1)
    }
    SubShader {
        Pass{
            CGPROGRAM
#pragma vertex vert
#pragma fragment frag

            struct app_data {
                float4 vertex:POSITION;
            };

            struct v2f {
                float4 position:SV_POSITION;
            };

            float4x4 _MVPMatrix;
            float4x4 _MVMatrix;
            float4x4 _VMatrix;

            float4 _Color;

            v2f vert(app_data i) {
                v2f o;
                o.position = mul(_MVPMatrix, i.vertex);
                return o;
            }

            float4 frag(v2f i) :SV_TARGET{
                return _Color;
            }

            ENDCG
        }
    }
}
```

[unity脚本矩阵和shader内置矩阵区别联系 思考和梳理](http://lib.csdn.net/article/47/36766?knId=1280)

[Unityでなるべくシェーディング処理を自作してみる](http://esprog.hatenablog.com/entry/2016/04/14/184423)