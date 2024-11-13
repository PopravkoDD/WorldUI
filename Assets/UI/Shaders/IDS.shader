Shader "Hidden/IDS"
{
Properties {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Color Tint", Color) = (1, 1, 1, 1)
    }

    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        ZTest Always // Ensures the sprite is always rendered regardless of depth
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha // Standard alpha blending

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _Color;

            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                o.color = v.color * _Color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 texColor = tex2D(_MainTex, i.texcoord);
                return texColor * i.color;
            }
            ENDCG
        }
    }

    FallBack "Sprites/Default"
}
