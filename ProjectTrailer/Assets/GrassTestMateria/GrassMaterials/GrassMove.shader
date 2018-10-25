// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "GrassShader"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		[PerRendererData] _AlphaTex ("External Alpha", 2D) = "white" {}
		_Float1("Float 1", Float) = 0.5
		_Tree_part2_000("Tree_part2_000", 2D) = "white" {}
		_Float0("Float 0", Float) = 0.5
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
	}

	SubShader
	{
		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True" }

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha
		
		
		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			#include "UnityShaderVariables.cginc"
			#include "Lighting.cginc"
			#include "AutoLight.cginc"


			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				float3 ase_normal : NORMAL;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
				UNITY_VERTEX_OUTPUT_STEREO
				float4 ase_texcoord1 : TEXCOORD1;
				float4 ase_texcoord2 : TEXCOORD2;
			};
			
			uniform fixed4 _Color;
			uniform float _EnableExternalAlpha;
			uniform sampler2D _MainTex;
			uniform sampler2D _AlphaTex;
			uniform float _Float0;
			uniform sampler2D _Tree_part2_000;
			uniform float4 _Tree_part2_000_ST;
			uniform float _Float1;
			
			v2f vert( appdata_t IN  )
			{
				v2f OUT;
				UNITY_SETUP_INSTANCE_ID(IN);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
				float3 ase_worldPos = mul(unity_ObjectToWorld, IN.vertex).xyz;
				float2 uv22 = IN.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float4 appendResult29 = (float4(( sin( ase_worldPos.x ) * ( _Float0 * ( uv22.y * cos( _Time.y ) ) ) ) , 0.0 , 0.0 , 0.0));
				
				OUT.ase_texcoord1.xyz = ase_worldPos;
				float3 ase_worldNormal = UnityObjectToWorldNormal(IN.ase_normal);
				OUT.ase_texcoord2.xyz = ase_worldNormal;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				OUT.ase_texcoord1.w = 0;
				OUT.ase_texcoord2.w = 0;
				
				IN.vertex.xyz += ( IN.color.r * appendResult29 ).xyz; 
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			fixed4 SampleSpriteTexture (float2 uv)
			{
				fixed4 color = tex2D (_MainTex, uv);

#if ETC1_EXTERNAL_ALPHA
				// get the color from an external texture (usecase: Alpha support for ETC1 on android)
				fixed4 alpha = tex2D (_AlphaTex, uv);
				color.a = lerp (color.a, alpha.r, _EnableExternalAlpha);
#endif //ETC1_EXTERNAL_ALPHA

				return color;
			}
			
			fixed4 frag(v2f IN  ) : SV_Target
			{
				float2 uv_Tree_part2_000 = IN.texcoord.xy * _Tree_part2_000_ST.xy + _Tree_part2_000_ST.zw;
				float4 tex2DNode4 = tex2D( _Tree_part2_000, uv_Tree_part2_000 );
				float2 appendResult81 = (float2(tex2DNode4.r , tex2DNode4.g));
				float4 temp_output_51_0 = ( float4( appendResult81, 0.0 , 0.0 ) * float4(0.2671325,0.3195555,0.6509434,0) );
				float4 appendResult80 = (float4(temp_output_51_0.r , temp_output_51_0.r , tex2DNode4.b , tex2DNode4.a));
				float3 ase_worldPos = IN.ase_texcoord1.xyz;
				float3 worldSpaceLightDir = UnityWorldSpaceLightDir(ase_worldPos);
				float3 ase_worldNormal = IN.ase_texcoord2.xyz;
				float dotResult39 = dot( worldSpaceLightDir , ase_worldNormal );
				float4 temp_output_41_0 = ( appendResult80 * step( _Float1 , dotResult39 ) );
				
				fixed4 c = temp_output_41_0;
				c.rgb *= c.a;
				return c;
			}
		ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	Fallback "GrassShader"
}
/*ASEBEGIN
Version=15401
28.8;390.4;1430;392;1771.88;492.665;2.229999;True;True
Node;AmplifyShaderEditor.TimeNode;20;-1690.284,851.8538;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CosOpNode;21;-1349.815,859.3364;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;22;-1712.732,705.806;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;18;-1177.83,658.088;Float;False;Property;_Float0;Float 0;2;0;Create;True;0;0;False;0;0.5;0.2;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;24;-1159.002,784.5079;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;4;-1132.491,-700.119;Float;True;Property;_Tree_part2_000;Tree_part2_000;1;0;Create;True;0;0;False;0;7b4ce5fc45e77924592e6a96b2b0a060;7b4ce5fc45e77924592e6a96b2b0a060;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.WorldPosInputsNode;25;-1210.14,475.3235;Float;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-964.7357,708.2368;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldSpaceLightDirHlpNode;37;-494.1232,-501.6562;Float;False;False;1;0;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.WorldNormalVector;36;-446.1232,-325.6562;Float;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.ColorNode;52;-101.606,-767.8528;Float;False;Constant;_Color0;Color 0;7;0;Create;True;0;0;False;0;0.2671325,0.3195555,0.6509434,0;0,0,0,0;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SinOpNode;26;-975.8032,497.7616;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;81;-378.1299,-810.4407;Float;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;27;-791.8401,494.9142;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;51;244.044,-964.093;Float;True;2;2;0;FLOAT2;0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.DotProductOpNode;39;-224.1232,-395.6562;Float;False;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-788.3736,596.7745;Float;False;Constant;_YValue0;Y Value = 0;3;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;38;-308.1233,-79.6562;Float;False;Property;_Float1;Float 1;0;0;Create;True;0;0;False;0;0.5;0.5;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;29;-532.1273,454.9852;Float;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.StepOpNode;40;-84.76325,-356.7164;Float;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;15;-718.177,172.1866;Float;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;80;473.7257,-665.4901;Float;True;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SamplerNode;34;-718.6483,-73.16461;Float;True;Property;_Grass000_normal;Grass000_normal;5;0;Create;True;0;0;False;0;53e5b1b68d8eb2b4bb0966e1c54e5866;53e5b1b68d8eb2b4bb0966e1c54e5866;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;35;-1130.519,-458.7531;Float;True;Property;_Grass000_metallic;Grass000_metallic;6;0;Create;True;0;0;False;0;0066468659f8b10439e5336e7d32506c;0066468659f8b10439e5336e7d32506c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;23;-1368.522,754.5767;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;74;536.1662,-390.2505;Float;False;FLOAT3;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;33;-1133.446,-269.3272;Float;True;Property;_Grass000_roughness;Grass000_roughness;4;0;Create;True;0;0;False;0;187a03b1b28d271409e1af9da899e192;187a03b1b28d271409e1af9da899e192;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-686.5902,-345.0797;Float;True;2;2;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;31;-934.4232,-1011.055;Float;True;Property;_Grass000_Opacity;Grass000_Opacity;3;0;Create;True;0;0;False;0;abd3d0484addcb044a465178fb029870;abd3d0484addcb044a465178fb029870;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;41;73.66664,-460.4163;Float;True;2;2;0;FLOAT4;0,0,0,0;False;1;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.OneMinusNode;72;-445.0315,-905.3813;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-391.619,251.2508;Float;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;79;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;5;GrassShader;0f8ba0101102bb14ebf021ddadce9b49;0;0;SubShader 0 Pass 0;2;True;3;1;False;-1;10;False;-1;0;1;False;-1;0;False;-1;False;True;2;False;-1;False;False;True;2;False;-1;False;False;True;5;Queue=Transparent;IgnoreProjector=True;RenderType=Transparent;PreviewType=Plane;CanUseSpriteAtlas=True;False;0;False;False;False;False;False;False;False;False;False;True;2;0;GrassShader;0;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;21;0;20;2
WireConnection;24;0;22;2
WireConnection;24;1;21;0
WireConnection;28;0;18;0
WireConnection;28;1;24;0
WireConnection;26;0;25;1
WireConnection;81;0;4;1
WireConnection;81;1;4;2
WireConnection;27;0;26;0
WireConnection;27;1;28;0
WireConnection;51;0;81;0
WireConnection;51;1;52;0
WireConnection;39;0;37;0
WireConnection;39;1;36;0
WireConnection;29;0;27;0
WireConnection;29;1;30;0
WireConnection;29;2;30;0
WireConnection;40;0;38;0
WireConnection;40;1;39;0
WireConnection;80;0;51;0
WireConnection;80;1;51;0
WireConnection;80;2;4;3
WireConnection;80;3;4;4
WireConnection;23;0;22;2
WireConnection;74;0;41;0
WireConnection;74;1;41;0
WireConnection;74;2;41;0
WireConnection;41;0;80;0
WireConnection;41;1;40;0
WireConnection;72;0;31;1
WireConnection;17;0;15;1
WireConnection;17;1;29;0
WireConnection;79;0;41;0
WireConnection;79;1;17;0
ASEEND*/
//CHKSM=8D4317D51283027E6A8BFBC0CBAF7EC43E5C5BA0