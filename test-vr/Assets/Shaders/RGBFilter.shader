Shader "Hidden/RGBFilter"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _redFilter ("Amount of red to allow through", Range(0,1)) = 1.0
        _blueFilter ("Amount of blue to allow through", Range(0,1)) = 1.0
        _greenFilter ("Amount of green to allow through", Range(0,1)) = 1.0
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"
			
			sampler2D _MainTex;
            uniform float _redFilter;
            uniform float _blueFilter;
            uniform float _greenFilter;

			float4 frag (v2f_img i) : COLOR
			{
				float4 col = tex2D(_MainTex, i.uv);
				// just invert the colors
				col = float4(col.r * _redFilter, col.g * _greenFilter, col.b * _blueFilter, col.a);
				return col;
			}
			ENDCG
		}
	}
}
