Shader "Custom/MaskColorToonShader" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}

		_ColorStrength("Color Strength", Range(1,4)) = 1

		_EmissionColor ("Emission Color", Color) = (1,1,1,1)
		_EmissionTex ("Emission (RGB)", 2D) = "white" {}
		_EmissionStrength("Emission Strength", Range(0,4)) = 1

		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 

		//_Position ("World Position", Vector) = (0,0,0,0)
		//_Radius ("Sphere Radius", Range(0,100)) = 0
		//_Softness ("Sphere Softness", Range(0,100)) = 0
	}

	SubShader {
		Tags { "RenderType"="Opaque" }
		UsePass "Toon/Basic Outline/OUTLINE"
		LOD 200
		
CGPROGRAM
#pragma surface surf ToonRamp

sampler2D _Ramp;

// custom lighting function that uses a texture ramp based
// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
	#endif
	
	half d = dot (s.Normal, lightDir)*0.5 + 0.5;
	half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
	
	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	return c;
}


sampler2D _MainTex, _EmissionTex;

struct Input {
	float2 uv_MainTex : TEXCOORD0;
	float2 uv_EmissionTex;
	float3 worldPos;
};

fixed4 _Color, _EmissionColor;

//Spherical Mask
uniform float4 GLOBALmask_Position;
uniform half GLOBALmask_Radius;
uniform half GLOBALmask_Softness;
half _ColorStrength, _EmissionStrength;

void surf (Input IN, inout SurfaceOutput o) {
	//Color
	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	//Nuances de gris
	half grayscale = (c.r + c.g + c.b) * 0.333;
	fixed3 c_g = fixed3(grayscale,grayscale,grayscale);
	//Sphere
	half d = distance(GLOBALmask_Position,IN.worldPos);
	half sum = saturate((d - GLOBALmask_Radius) / -GLOBALmask_Softness);
	fixed4 lerpColor = lerp(fixed4(c_g,1),c * _ColorStrength,sum);
	//Emission
	fixed4 e = tex2D(_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;
	fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e, sum);


	o.Albedo = lerpColor.rgb;
	//----------------
	o.Alpha = c.a;
	o.Emission = lerpEmission.rgb;
}
ENDCG

	} 

	Fallback "Diffuse"
}
