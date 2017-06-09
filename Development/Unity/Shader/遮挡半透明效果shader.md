```glsl
Shader "YlyTestShader1" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
 
SubShader {
    Tags { "Queue"="Transparent" "RenderType"="Opaque" }
    LOD 100
 
    Pass { 
        ZTest Greater
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
 
    CGPROGRAM
    #pragma vertex vert_img
    #pragma fragment frag
 
    #include "UnityCG.cginc"
 
    sampler2D _MainTex;
 
    fixed4 frag (v2f_img i) : SV_Target
    {
        fixed4 col = tex2D(_MainTex, i.uv);
        col.a = 0.25;
        return col;
    }
    ENDCG
    }
 
    Pass { 
    ZTest LEqual
    CGPROGRAM
    #pragma vertex vert
    #pragma fragment frag
    #pragma multi_compile_fog
 
    #include "UnityCG.cginc"
 
    struct appdata_t {
        float4 vertex : POSITION;
        float2 texcoord : TEXCOORD0;
    };
 
    struct v2f {
        float4 vertex : SV_POSITION;
        half2 texcoord : TEXCOORD0;
    };
 
    sampler2D _MainTex;
    float4 _MainTex_ST;
 
    v2f vert (appdata_t v)
    {
        v2f o;
        o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
        o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
        return o;
    }
 
    fixed4 frag (v2f i) : SV_Target
    {
        fixed4 col = tex2D(_MainTex, i.texcoord);
        return col;
    }
    ENDCG
    }
 }
}
```

[Unity3D Shader示例之角色被建筑遮住呈现半透明效果](http://www.hiwrz.com/2016/12/11/unity/330/)