Shader "Unlit/WormholeVertShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
		_TPow("Transparency Power" , Float) = 1
        _FadeDistance("FadeDistance" , Float) = 1

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM


            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 Normal : NORMAL;

            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 Normal : NORMAL;
                float3 viewDir : TEXCOORD3;
                float depth : DEPTH;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _TPow;
            float _FadeDistance;


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.viewDir = normalize(  UnityWorldSpaceViewDir(  mul(unity_ObjectToWorld, v.vertex) ) );
                o.Normal = normalize( UnityObjectToWorldNormal(v.Normal) ) ;
                o.depth = -mul(UNITY_MATRIX_MV, v.vertex).z / _FadeDistance;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _Color;
                //col.rgb = normalize(  WorldSpaceViewDir(  fixed4(i.Normal.r,i.Normal.g,i.Normal.b,0)   ) );
                //col.rgb = dot(i.viewDir,i.Normal);
                col.rgb*= (1-pow(dot(i.viewDir,i.Normal), _TPow * (1+.4*cos(_Time*6))  ) );
                col.rgb *= (1-i.depth);
                return col;
            }
            ENDCG
        }
    }
}
