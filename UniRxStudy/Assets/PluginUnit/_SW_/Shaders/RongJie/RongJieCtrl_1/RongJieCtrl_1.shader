// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34137,y:33197,varname:node_3138,prsc:2|emission-2646-R,alpha-7663-OUT;n:type:ShaderForge.SFN_TexCoord,id:607,x:29819,y:34105,varname:node_607,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:117,x:30326,y:34025,varname:node_117,prsc:2,spu:0.2,spv:0.3|UVIN-6362-OUT;n:type:ShaderForge.SFN_Vector2,id:3420,x:29819,y:33966,varname:node_3420,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_Multiply,id:6362,x:30021,y:34024,varname:node_6362,prsc:2|A-3420-OUT,B-607-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8392,x:30589,y:34028,ptovrint:False,ptlb:node_8392,ptin:_node_8392,varname:_node_8392,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:d8e5c7e9356d81b408a5ed5eb34e0a2b,ntxv:0,isnm:False|UVIN-117-UVOUT;n:type:ShaderForge.SFN_Tex2d,id:8904,x:30584,y:34327,ptovrint:False,ptlb:node_8904,ptin:_node_8904,varname:_node_8904,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:cbf5f14fc9d5ecd4f9f575203e8d107f,ntxv:0,isnm:False|UVIN-3523-UVOUT;n:type:ShaderForge.SFN_Panner,id:3523,x:30338,y:34327,varname:node_3523,prsc:2,spu:-0.3,spv:-0.1|UVIN-6039-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:6039,x:29975,y:34326,varname:node_6039,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Add,id:6354,x:30810,y:34232,varname:node_6354,prsc:2|A-8392-RGB,B-8904-RGB;n:type:ShaderForge.SFN_ComponentMask,id:3134,x:31047,y:34236,varname:node_3134,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6354-OUT;n:type:ShaderForge.SFN_Multiply,id:1629,x:32140,y:33571,varname:node_1629,prsc:2|A-8136-OUT,B-6640-OUT;n:type:ShaderForge.SFN_Abs,id:8482,x:32425,y:33576,varname:node_8482,prsc:2|IN-1629-OUT;n:type:ShaderForge.SFN_Vector1,id:6640,x:31814,y:33655,varname:node_6640,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Tex2d,id:7082,x:32230,y:33844,ptovrint:False,ptlb:node_7082,ptin:_node_7082,varname:_node_7082,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5d6dad5e2a36e0241b8c146a7eb1528b,ntxv:0,isnm:False|UVIN-8302-OUT;n:type:ShaderForge.SFN_If,id:9849,x:33015,y:33809,varname:node_9849,prsc:2|A-8482-OUT,B-4700-OUT,GT-1292-OUT,EQ-1292-OUT,LT-8687-OUT;n:type:ShaderForge.SFN_Vector1,id:1292,x:32831,y:34006,varname:node_1292,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:8687,x:32848,y:34086,varname:node_8687,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7389,x:31047,y:34147,varname:node_7389,prsc:2,v1:0.015;n:type:ShaderForge.SFN_Multiply,id:6386,x:31317,y:34220,varname:node_6386,prsc:2|A-7389-OUT,B-3134-OUT;n:type:ShaderForge.SFN_Vector2,id:6811,x:31301,y:33894,varname:node_6811,prsc:2,v1:1,v2:1;n:type:ShaderForge.SFN_TexCoord,id:7329,x:31301,y:34017,varname:node_7329,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Multiply,id:3251,x:31553,y:34005,varname:node_3251,prsc:2|A-6811-OUT,B-7329-UVOUT;n:type:ShaderForge.SFN_Add,id:8302,x:31850,y:34113,varname:node_8302,prsc:2|A-3251-OUT,B-6386-OUT;n:type:ShaderForge.SFN_Multiply,id:7663,x:33732,y:33624,varname:node_7663,prsc:2|A-8940-OUT,B-8153-B;n:type:ShaderForge.SFN_Tex2d,id:2646,x:33525,y:32940,ptovrint:False,ptlb:node_2646,ptin:_node_2646,varname:_node_2646,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c70033d3f6741dd4e9d8b4391ec72671,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8153,x:33358,y:33748,ptovrint:False,ptlb:node_8153,ptin:_node_8153,varname:_node_8153,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3ab589c04177fc049a5a924eb027de6b,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Clamp01,id:8940,x:33349,y:33456,varname:node_8940,prsc:2|IN-9849-OUT;n:type:ShaderForge.SFN_Slider,id:8136,x:31713,y:33534,ptovrint:False,ptlb:time,ptin:_time,varname:node_8136,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1282051,max:10;n:type:ShaderForge.SFN_Clamp01,id:4700,x:32806,y:33861,varname:node_4700,prsc:2|IN-120-OUT;n:type:ShaderForge.SFN_Subtract,id:120,x:32478,y:33937,varname:node_120,prsc:2|A-7082-A,B-4976-OUT;n:type:ShaderForge.SFN_Vector1,id:4976,x:32244,y:34076,varname:node_4976,prsc:2,v1:-0.024;proporder:8392-8904-7082-2646-8153-8136;pass:END;sub:END;*/

Shader "" {
    Properties {
        _node_8392 ("node_8392", 2D) = "white" {}
        _node_8904 ("node_8904", 2D) = "white" {}
        _node_7082 ("node_7082", 2D) = "white" {}
        _node_2646 ("node_2646", 2D) = "white" {}
        _node_8153 ("node_8153", 2D) = "white" {}
        _time ("time", Range(0, 10)) = 0.1282051
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
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            uniform sampler2D _node_8392; uniform float4 _node_8392_ST;
            uniform sampler2D _node_8904; uniform float4 _node_8904_ST;
            uniform sampler2D _node_7082; uniform float4 _node_7082_ST;
            uniform sampler2D _node_2646; uniform float4 _node_2646_ST;
            uniform sampler2D _node_8153; uniform float4 _node_8153_ST;
            uniform float _time;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _node_2646_var = tex2D(_node_2646,TRANSFORM_TEX(i.uv0, _node_2646));
                float3 emissive = float3(_node_2646_var.r,_node_2646_var.r,_node_2646_var.r);
                float3 finalColor = emissive;
                float4 node_2094 = _Time;
                float2 node_117 = ((float2(1,1)*i.uv0)+node_2094.g*float2(0.2,0.3));
                float4 _node_8392_var = tex2D(_node_8392,TRANSFORM_TEX(node_117, _node_8392));
                float2 node_3523 = (i.uv0+node_2094.g*float2(-0.3,-0.1));
                float4 _node_8904_var = tex2D(_node_8904,TRANSFORM_TEX(node_3523, _node_8904));
                float2 node_8302 = ((float2(1,1)*i.uv0)+(0.015*(_node_8392_var.rgb+_node_8904_var.rgb).rg));
                float4 _node_7082_var = tex2D(_node_7082,TRANSFORM_TEX(node_8302, _node_7082));
                float node_9849_if_leA = step(abs((_time*0.1)),saturate((_node_7082_var.a-(-0.024))));
                float node_9849_if_leB = step(saturate((_node_7082_var.a-(-0.024))),abs((_time*0.1)));
                float node_1292 = 1.0;
                float4 _node_8153_var = tex2D(_node_8153,TRANSFORM_TEX(i.uv0, _node_8153));
                return fixed4(finalColor,(saturate(lerp((node_9849_if_leA*0.0)+(node_9849_if_leB*node_1292),node_1292,node_9849_if_leA*node_9849_if_leB))*_node_8153_var.b));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
