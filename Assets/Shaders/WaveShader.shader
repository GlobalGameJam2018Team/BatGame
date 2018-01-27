Shader "Custom/WaveShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_InnerRingDiameter ("Inner dist", Float) = 0
		_ExternRingDiameter("Extern dist", Float) = 0
		_MinimumRenderDistance ("Min render dist",Float) = 10
		_MaximumFadeDistance ("Max fade dist", Float) = 20
	}
		SubShader{
				Tags{ "RenderType" = "Opaque"  }

				LOD 200

			Stencil{
			Ref 1
			Pass replace
		}

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		//float _Mi
		float _InnerRingDiameter;
		float _ExternRingDiameter;
		float _MinimumRenderDistance;
		float _MaximumFadeDistance;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			float distance = length(_WorldSpaceCameraPos - IN.worldPos);
			float2 position = float2((0.5 - IN.uv_MainTex.x) * 2, (0.5 - IN.uv_MainTex.y) * 2);
			float ringDistanceFromCenter = sqrt(position.x * position.x + position.y * position.y) * _ExternRingDiameter;
			
			//clip(1 - ringDistanceFromCenter);
			clip(ringDistanceFromCenter - _InnerRingDiameter);
			
			//fixed3 color = fi
			//clip(distance - _MinimumRenderDistance);
			//fixed opacity = clamp((distance - _MinimumRenderDistance) / (_MaximumFadeDistance - _MinimumRenderDistance), 0, 1);
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo  = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
