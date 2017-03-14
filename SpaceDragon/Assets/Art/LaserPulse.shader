// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:True,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1,x:33135,y:32331,varname:node_1,prsc:2|emission-4435-OUT,alpha-6709-OUT;n:type:ShaderForge.SFN_Subtract,id:18,x:32114,y:32340,varname:node_18,prsc:2|A-22-OUT,B-19-OUT;n:type:ShaderForge.SFN_Vector1,id:19,x:31935,y:32422,varname:node_19,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:21,x:32286,y:32340,varname:node_21,prsc:2|IN-18-OUT;n:type:ShaderForge.SFN_Frac,id:22,x:31935,y:32288,varname:node_22,prsc:2|IN-24-OUT;n:type:ShaderForge.SFN_ComponentMask,id:24,x:31764,y:32288,varname:node_24,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-6072-OUT;n:type:ShaderForge.SFN_Multiply,id:25,x:32461,y:32390,cmnt:Triangle Wave,varname:node_25,prsc:2|A-21-OUT,B-26-OUT;n:type:ShaderForge.SFN_Vector1,id:26,x:32286,y:32476,varname:node_26,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:133,x:32665,y:32453,cmnt:Panning gradient,varname:node_133,prsc:2|VAL-25-OUT,EXP-9384-OUT;n:type:ShaderForge.SFN_Color,id:168,x:32665,y:32269,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.2391481,c3:0.1102941,c4:1;n:type:ShaderForge.SFN_TexCoord,id:5169,x:31306,y:32359,varname:node_5169,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:4435,x:32970,y:32423,varname:node_4435,prsc:2|A-168-RGB,B-6251-OUT;n:type:ShaderForge.SFN_Slider,id:6709,x:32675,y:32799,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_6709,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7,max:1;n:type:ShaderForge.SFN_Time,id:1299,x:31226,y:32522,varname:node_1299,prsc:2;n:type:ShaderForge.SFN_Append,id:4120,x:31334,y:32698,varname:node_4120,prsc:2|A-3723-OUT,B-9095-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3723,x:31120,y:32654,ptovrint:False,ptlb:X speed,ptin:_Xspeed,varname:node_3723,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:9095,x:31120,y:32745,ptovrint:False,ptlb:Y speed,ptin:_Yspeed,varname:_Xspeed_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:8742,x:31574,y:32620,varname:node_8742,prsc:2|A-1299-T,B-4120-OUT;n:type:ShaderForge.SFN_Add,id:6072,x:31685,y:32507,varname:node_6072,prsc:2|A-5169-UVOUT,B-8742-OUT;n:type:ShaderForge.SFN_Sin,id:9286,x:32083,y:32636,varname:node_9286,prsc:2|IN-1299-T;n:type:ShaderForge.SFN_RemapRange,id:9384,x:32268,y:32651,varname:node_9384,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:4|IN-9286-OUT;n:type:ShaderForge.SFN_Multiply,id:6251,x:32821,y:32492,varname:node_6251,prsc:2|A-133-OUT,B-6009-OUT;n:type:ShaderForge.SFN_Slider,id:6009,x:32399,y:32695,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:node_6009,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7,max:1;proporder:168-6709-3723-9095-6009;pass:END;sub:END;*/

Shader "Custom/LaserPulse" {
    Properties {
        _GlowColor ("Glow Color", Color) = (1,0.2391481,0.1102941,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.7
        _Xspeed ("X speed", Float ) = 1
        _Yspeed ("Y speed", Float ) = 1
        _Brightness ("Brightness", Range(0, 1)) = 0.7
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _GlowColor;
            uniform float _Opacity;
            uniform float _Xspeed;
            uniform float _Yspeed;
            uniform float _Brightness;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 node_1299 = _Time + _TimeEditor;
                float3 emissive = (_GlowColor.rgb+(pow((abs((frac((i.uv0+(node_1299.g*float2(_Xspeed,_Yspeed))).r)-0.5))*2.0),(sin(node_1299.g)*2.0+2.0))*_Brightness));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,_Opacity);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "Meta"
            Tags {
                "LightMode"="Meta"
            }
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_META 1
            #include "UnityCG.cginc"
            #include "UnityMetaPass.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers xbox360 ps3 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _GlowColor;
            uniform float _Xspeed;
            uniform float _Yspeed;
            uniform float _Brightness;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float2 texcoord2 : TEXCOORD2;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
                return o;
            }
            float4 frag(VertexOutput i) : SV_Target {
                UnityMetaInput o;
                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
                
                float4 node_1299 = _Time + _TimeEditor;
                o.Emission = (_GlowColor.rgb+(pow((abs((frac((i.uv0+(node_1299.g*float2(_Xspeed,_Yspeed))).r)-0.5))*2.0),(sin(node_1299.g)*2.0+2.0))*_Brightness));
                
                float3 diffColor = float3(0,0,0);
                o.Albedo = diffColor;
                
                return UnityMetaFragment( o );
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
