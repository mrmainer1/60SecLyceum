﻿Shader "Hidden/TEXDraw-UIE"
{
    Properties
    {
        // Establish sensible default values
        [HideInInspector] _MainTex("Atlas", 2D) = "white" {}
        [HideInInspector] _FontTex("Font", 2D) = "black" {}
        [HideInInspector] _CustomTex("Custom", 2D) = "black" {}
        [HideInInspector] _Color("Tint", Color) = (1,1,1,1)
        _FontTexSDFScale("FontTexSDFScale", float) = 1
    }

    Category
    {
        Lighting Off


        //   Our textures and colors are not premultiplied, but we use this equation for alpha so that
        //   transparency goes towards 0 as more semi - transparent layers are added(like premultiplied).
        //   This is relevant in the case where we render into a render texture that is to be drawn on
        //   top of another render target afterwards.
        //   Reminder:
        //   dst.a' = 1 - (1 - dst.a)(1 - src.a)
        //          = 1 - (1 - dst.a - src.a + dst.a * src.a)
        //          = 1 - 1 + dst.a + src.a - dst.a * src.a
        //          = dst.a + src.a - dst.a * src.a
        //          = src.a * 1 + dst.a * (1 - src.a)
        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha


        // Users pass depth between [Near,Far] = [-1,1]. This gets stored on the depth buffer in [Near,Far] [0,1] regardless of the underlying graphics API.
        Cull Off    // Two sided rendering is crucial for immediate clipping
        ZWrite Off
        Stencil
        {
            Ref         255 // 255 for ease of visualization in RenderDoc, but can be just one bit
            ReadMask    255
            WriteMask   255

            CompFront Always
            PassFront Keep
            ZFailFront Replace
            FailFront Keep

            CompBack Equal
            PassBack Keep
            ZFailBack Zero
            FailBack Keep
        }

        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
            "PreviewType" = "Plane"
        }

        // SM3.5 version
        SubShader
        {
            Tags { "UIE_VertexTexturingIsAvailable" = "1" "UIE_ShaderModelIs35" = "1" }
            Pass
            {
                CGPROGRAM
                #if UNITY_VERSION <= 202210
                #define UIE_CUSTOM_SHADER 1
                #pragma target 3.5
                #pragma vertex vert
                #pragma fragment frag
                #pragma require samplelod

                #include "UnityUIE.cginc"

                v2f vert(appdata_t v) {
                     return uie_std_vert(v);
                }
                UIE_FRAG_T frag(v2f IN) : SV_Target {
                     UIE_FRAG_T c = uie_std_frag(IN);
                     c.xyz = IN.color.xyz;
                     return c;
                }
                #endif
                ENDCG
            }
        }

        // SM2.0 version
        SubShader
        {
            Pass
            {
                CGPROGRAM
                #if UNITY_VERSION <= 202210
                #define UIE_CUSTOM_SHADER 1
                #pragma target 2.0
                #pragma vertex vert
                #pragma fragment frag
                
                #include "UnityUIE.cginc"

                v2f vert(appdata_t v) {
                     return uie_std_vert(v);
                }
                UIE_FRAG_T frag(v2f IN) : SV_Target {
                     UIE_FRAG_T c = uie_std_frag(IN);
                     c.xyz = IN.color.xyz;
                     return c;
                }
                #endif
                ENDCG
            }
        }
    } // Category
}