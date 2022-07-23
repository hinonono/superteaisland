// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DoubleSide"
{
	Properties
	{
		_MainTexOne ("TEXONE", 2D) = "white" {}//正面贴图
		_MainTexTwo ("TEXTWO", 2D) = "white" {}//反面贴图
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }//渲染队列
		LOD 100
		Pass//pass用来渲染前面，裁剪掉背面
		{
		    Tags{"LightMode" = "ForwardBase"}
			Cull Back//裁剪背面
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTexOne;
			float4 _MainTexOne_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTexOne);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTexOne, i.uv);		
				return col;
			}
			ENDCG
		}
		Pass//pass用来渲染背面，裁剪前面
		{
		    Tags{"LightMode" = "ForwardBase"}
			Cull Front//裁剪前面
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTexTwo;
			float4 _MainTexTwo_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTexTwo);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTexTwo, i.uv);		
				return col;
			}
			ENDCG
		}

	}
}