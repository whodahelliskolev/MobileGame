// Simplified Bumped Specular shader. Differences from regular Bumped Specular one:
// - no Main Color nor Specular Color
// - specular lighting directions are approximated per vertex
// - writes zero to alpha channel
// - Normalmap uses Tiling/Offset of the Base texture
// - no Deferred Lighting support
// - no Lightmap support
// - Emissive texture and intensity control
 
Shader "Mobile/Bump Specular Emissive" {
Properties {
    _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
    _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
    _BumpMap ("Normalmap", 2D) = "bump" {}
    _Emissive("Emissive", 2D) = "black" {}
    _EmissiveIntensity("_EmissiveIntensity", Range(0,10) ) = 0.5
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 250
   
CGPROGRAM
#pragma surface surf MobileBlinnPhong exclude_path:prepass nolightmap halfasview
// Add noforwardadd to the above line if there is a hardware crash
 
inline fixed4 LightingMobileBlinnPhong (SurfaceOutput s, fixed3 lightDir, fixed3 halfDir, fixed atten)
{
    fixed diff = max (0, dot (s.Normal, lightDir));
    fixed nh = max (0, dot (s.Normal, halfDir));
    fixed spec = pow (nh, s.Specular*128) * s.Gloss;
   
    fixed4 c;
    c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * (atten*2);
    c.a = 0.0;
    return c;
}
 
sampler2D _MainTex;
sampler2D _BumpMap;
half _Shininess;
sampler2D _Emissive;
float _EmissiveIntensity;
 
struct Input {
    float2 uv_MainTex;
    float2 uv_Emissive;
};
 
void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
    o.Albedo = tex.rgb;
    o.Gloss = tex.a;
    o.Alpha = tex.a;
    o.Specular = _Shininess;
    o.Normal = UnpackNormal (tex2D(_BumpMap, IN.uv_MainTex));
   
    float4 Tex2D1=tex2D(_Emissive,(IN.uv_Emissive.xyxy).xy);
    float4 Multiply2=Tex2D1 * _EmissiveIntensity.xxxx;
   
    o.Emission = Multiply2;
}
ENDCG
}
 
FallBack "Mobile/VertexLit"
}