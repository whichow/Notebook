   ```glsl
   struct appdata_base {
      float4 vertex : POSITION;
      float3 normal : NORMAL;
      float4 texcoord : TEXCOORD0;
   };
   struct appdata_tan {
      float4 vertex : POSITION;
      float4 tangent : TANGENT;
      float3 normal : NORMAL;
      float4 texcoord : TEXCOORD0;
   };
   struct appdata_full {
      float4 vertex : POSITION;
      float4 tangent : TANGENT;
      float3 normal : NORMAL;
      float4 texcoord : TEXCOORD0;
      float4 texcoord1 : TEXCOORD1;
      float4 texcoord2 : TEXCOORD2;
      float4 texcoord3 : TEXCOORD3;
      fixed4 color : COLOR;
      // and additional texture coordinates only on XBOX360
   };

   struct appdata_img {
      float4 vertex : POSITION;
      half2 texcoord : TEXCOORD0;
   };
   ```

- POSITION is the vertex position, typically a float3 or float4.
- NORMAL is the vertex normal, typically a float3.
- TEXCOORD0 is the first UV coordinate, typically float2, float3 or float4.
- TEXCOORD1, TEXCOORD2 and TEXCOORD3 are the 2nd, 3rd and 4th UV coordinates, respectively.
- TANGENT is the tangent vector (used for normal mapping), typically a float4.
- COLOR is the per-vertex color, typically a float4.