```glsl
Shader "hongGe/GrabTexture3"
{
    Properties
    {
        _Offset ("UVOffset", float) = 0.01//uv偏移
        _Percent ("Percent", float) = 0.1//百分比
    }
    SubShader
    {
        Tags{"Queue"="Transparent"}
        GrabPass{}
    
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            sampler2D _GrabTexture;
            float _Offset;
            float _Percent;
    
            struct VertexOutput
            {
                float4 pos:SV_POSITION;
                float2 uv:TEXCOORD0;
            };
    
            VertexOutput vert(appdata_base v)
            {
                VertexOutput o;
                o.pos = mul(UNITY_MATRIX_MVP,v.vertex);
                o.uv = float2(v.texcoord.x , 1-v.texcoord.y);
                
                return o;
            }
    
            float4 frag(VertexOutput input):COLOR
            {
            half4 a = tex2D(_GrabTexture,input.uv + float2(_Offset,0));
            half4 b = tex2D(_GrabTexture,input.uv + float2(-_Offset,0));
            half4 c = tex2D(_GrabTexture,input.uv + float2(0,_Offset));
            half4 d = tex2D(_GrabTexture,input.uv + float2(0,-_Offset));
            
            half4 e = tex2D(_GrabTexture,input.uv + float2(_Offset / 2,_Offset / 2));
            half4 f = tex2D(_GrabTexture,input.uv + float2(-_Offset / 2,_Offset / 2));
            half4 g = tex2D(_GrabTexture,input.uv + float2(_Offset / 2,-_Offset / 2));
            half4 h = tex2D(_GrabTexture,input.uv + float2(-_Offset / 2,-_Offset / 2));
            
            half4 texCol = tex2D(_GrabTexture,input.uv);
            texCol = (texCol + a + b + c + d + e + f + g + h) * _Percent;
            return texCol;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
```

[[Unity Shader编程]用Shader实现图片模糊效果](http://www.unity.5helpyou.com/3328.html)