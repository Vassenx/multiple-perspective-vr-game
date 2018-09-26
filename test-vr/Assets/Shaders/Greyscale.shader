Shader "Hidden/Greyscale"
{
	Properties{
	_MainTex("Base (RGB)", 2D) = "white" {}
	_redFilter("Red Filter", Range(0, 1)) = 1
	_greenFilter("Green Filter", Range(0, 1)) = 1
	_blueFilter("Blue Filter", Range(0, 1)) = 1

	}
	SubShader{
		Pass {
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag

			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _redFilter;
			uniform float _greenFilter;
			uniform float _blueFilter;

			float4 frag(v2f_img i) : COLOR {
				float4 c = tex2D(_MainTex, i.uv);
				//c.r = c.r * _redFilter;
				//c.g = c.g * _greenFilter;
				//c.b = c.b * _blueFilter;
				c = float4(c.r * _redFilter, c.g * _greenFilter, c.b * _blueFilter, c.a);
				return c;
			}
			ENDCG
		}
	}
}
