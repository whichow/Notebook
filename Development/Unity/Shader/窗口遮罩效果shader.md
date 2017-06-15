
被遮罩的物体shader
```glsl
Shader "Test/Unity/Unlit/Unlit-Texture-Be-Mask" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _Color ("Color", Color) = (1, 1, 1, 1)
 _Stencil ("Stencil Ref", Float) = 1
}
 
SubShader {
 Tags { "Queue"="Transparent" }
 LOD 100
 Blend SrcAlpha OneMinusSrcAlpha 
 
 Pass { 
     Stencil
     {
         Ref [_Stencil]
         Comp Equal
     }
 
     CGPROGRAM
     #pragma vertex vert
     #pragma fragment frag
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
     fixed4 _Color;
 
     v2f vert (appdata_t v)
     {
         v2f o;
         o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
         o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
         return o;
     }
 
     fixed4 frag (v2f i) : COLOR
     {
         fixed4 col = tex2D(_MainTex, i.texcoord);
         col = _Color * col;
         return col;
     }
     ENDCG
     }
}
}
```
遮罩shader
```glsl
Shader "Test/Unity/Unlit/Unlit-Texture-Mask" {
Properties {
 _MainTex ("Base (RGB)", 2D) = "white" {}
 _Color ("Color", Color) = (1, 1, 1, 1)
 _Stencil ("Stencil Ref", Float) = 1
}
 
SubShader {
 Tags { "Queue"="Transparent" }
 LOD 100
 Blend SrcAlpha OneMinusSrcAlpha 
 
 Pass {
     Stencil
     {
         Ref [_Stencil]
         Comp Always
         Pass Replace
     }
 
     CGPROGRAM
     #pragma vertex vert
     #pragma fragment frag
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
     fixed4 _Color;
 
     v2f vert (appdata_t v)
     {
         v2f o;
         o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
         o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
         return o;
     }
 
     fixed4 frag (v2f i) : COLOR
     {
         fixed4 col = tex2D(_MainTex, i.texcoord);
         col = _Color * col;
         return col;
     }
     ENDCG
     }
}
}
```

[Unity3D Shader示例之使用模板测试Stencil Test制作窗口效果](http://www.hiwrz.com/2016/07/09/unity/246/)

[How to cull/render to through a 'window'?](http://answers.unity3d.com/questions/590800/how-to-cullrender-to-through-a-window.html)

[Using the Stencil Buffer in Unity Free](https://alastaira.wordpress.com/2014/12/27/using-the-stencil-buffer-in-unity-free/)

[ShaderLab: Stencil](https://docs.unity3d.com/Manual/SL-Stencil.html)