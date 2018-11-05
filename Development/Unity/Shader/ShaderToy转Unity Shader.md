# ShaderToy转Unity Shader

fragCoord.xy / iResolution.xy =>  i.uv

fragCoord => _ScreenParams.xy*i.uv

vecN => floatN

matN => floatNxN

mix => lerp

fract =>frac

mod => fmod

atan => atan2

dFdx => ddx

dFdy => ddy

texture => tex2D

iTime => _Time.y

iResolution => _ScreenParams

vec2 *= mat2 => mul(float2x2, float2)



- Replace **iGlobalTime** shader input (“shader playback time in seconds”) with **_Time.y**
- Replace **iResolution.xy** (“viewport resolution in pixels”) with **_ScreenParams.xy**
- Replace **vec2** types with **float2**, **mat2** with **float2x2** etc.
- Replace **vec3(1)** shortcut constructors in which all elements have same value with explicit **float3(1,1,1)**
- Replace **Texture2D** with **Tex2D**
- Replace **atan(x,y)** with **atan2(y,x)** <- Note parameter ordering!
- Replace **mix()** with **lerp()**
- Replace ***=** with **mul()**
- Remove third (bias) parameter from Texture2D lookups
- **mainImage(out vec4 fragColor, in vec2 fragCoord)** is the fragment shader function, equivalent to **float4 mainImage(float2 fragCoord : SV_POSITION) : SV_Target**
- UV coordinates in GLSL have 0 at the top and increase downwards, in HLSL 0 is at the bottom and increases upwards, so you may need to use **uv.y = 1 – uv.y** at some point.



[[Unity Shadertoys (a.k.a Converting GLSL shaders to Cg/HLSL)](https://alastaira.wordpress.com/2015/08/07/unity-shadertoys-a-k-a-converting-glsl-shaders-to-cghlsl/)]