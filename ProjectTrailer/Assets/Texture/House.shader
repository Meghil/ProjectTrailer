// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Custom/House"
{
	Properties
	{
		_houses_ao("houses_ao", 2D) = "white" {}
		_houses_diffuse("houses_diffuse", 2D) = "white" {}
		_houses_metallic("houses_metallic", 2D) = "white" {}
		_houses_normal("houses_normal", 2D) = "white" {}
		_houses_roughness("houses_roughness", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _houses_normal;
		uniform float4 _houses_normal_ST;
		uniform sampler2D _houses_diffuse;
		uniform float4 _houses_diffuse_ST;
		uniform sampler2D _houses_metallic;
		uniform float4 _houses_metallic_ST;
		uniform sampler2D _houses_roughness;
		uniform float4 _houses_roughness_ST;
		uniform sampler2D _houses_ao;
		uniform float4 _houses_ao_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_houses_normal = i.uv_texcoord * _houses_normal_ST.xy + _houses_normal_ST.zw;
			o.Normal = tex2D( _houses_normal, uv_houses_normal ).rgb;
			float2 uv_houses_diffuse = i.uv_texcoord * _houses_diffuse_ST.xy + _houses_diffuse_ST.zw;
			o.Albedo = tex2D( _houses_diffuse, uv_houses_diffuse ).rgb;
			float2 uv_houses_metallic = i.uv_texcoord * _houses_metallic_ST.xy + _houses_metallic_ST.zw;
			o.Metallic = tex2D( _houses_metallic, uv_houses_metallic ).r;
			float2 uv_houses_roughness = i.uv_texcoord * _houses_roughness_ST.xy + _houses_roughness_ST.zw;
			o.Smoothness = tex2D( _houses_roughness, uv_houses_roughness ).r;
			float2 uv_houses_ao = i.uv_texcoord * _houses_ao_ST.xy + _houses_ao_ST.zw;
			o.Occlusion = tex2D( _houses_ao, uv_houses_ao ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=15401
40;48.8;1455;738;806;294;1;True;True
Node;AmplifyShaderEditor.SamplerNode;2;-360,220;Float;True;Property;_houses_diffuse;houses_diffuse;1;0;Create;True;0;0;False;0;099940a5bac01b448bf7e59d2d7cedf0;099940a5bac01b448bf7e59d2d7cedf0;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;172,-106;Float;True;Property;_houses_normal;houses_normal;4;0;Create;True;0;0;False;0;32f8fa55f2b5dca4eb5752915ec61ab8;32f8fa55f2b5dca4eb5752915ec61ab8;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;3;-475,130;Float;True;Property;_houses_height;houses_height;2;0;Create;True;0;0;False;0;3817ca8297aeed549a0c0ab3e5af04ca;3817ca8297aeed549a0c0ab3e5af04ca;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-465,-58;Float;True;Property;_houses_ao;houses_ao;0;0;Create;True;0;0;False;0;193b12739566f07479bb54d661eceaa4;193b12739566f07479bb54d661eceaa4;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-417,-228;Float;True;Property;_houses_metallic;houses_metallic;3;0;Create;True;0;0;False;0;7fcc4b96fd10fc74c82ac65a809aa69b;7fcc4b96fd10fc74c82ac65a809aa69b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;6;-123,-228;Float;True;Property;_houses_roughness;houses_roughness;5;0;Create;True;0;0;False;0;35f141e6851b9ec4db8e86910d3722c9;35f141e6851b9ec4db8e86910d3722c9;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;Custom/House;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;-1;False;-1;-1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;0;0;2;0
WireConnection;0;1;5;0
WireConnection;0;3;4;0
WireConnection;0;4;6;0
WireConnection;0;5;1;0
ASEEND*/
//CHKSM=91C2313586F0477AE409234AF3C267C1B072470E