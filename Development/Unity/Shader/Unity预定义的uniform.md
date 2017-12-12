```glsl
   uniform float4 _Time, _SinTime, _CosTime; // time values
   uniform float4 _ProjectionParams;
      // x = 1 or -1 (-1 if projection is flipped)
      // y = near plane; z = far plane; w = 1/far plane
   uniform float4 _ScreenParams; 
      // x = width; y = height; z = 1 + 1/width; w = 1 + 1/height
   uniform float3 _WorldSpaceCameraPos;
   uniform float4x4 _Object2World; // model matrix
   uniform float4x4 _World2Object; // inverse model matrix 
   uniform float4 _WorldSpaceLightPos0; 
      // position or direction of light source for forward rendering

   uniform float4x4 UNITY_MATRIX_MVP; // model view projection matrix 
   uniform float4x4 UNITY_MATRIX_MV; // model view matrix
   uniform float4x4 UNITY_MATRIX_V; // view matrix
   uniform float4x4 UNITY_MATRIX_P; // projection matrix
   uniform float4x4 UNITY_MATRIX_VP; // view projection matrix
   uniform float4x4 UNITY_MATRIX_T_MV; 
      // transpose of model view matrix
   uniform float4x4 UNITY_MATRIX_IT_MV; 
      // transpose of the inverse model view matrix
   uniform float4 UNITY_LIGHTMODEL_AMBIENT; // ambient color
```