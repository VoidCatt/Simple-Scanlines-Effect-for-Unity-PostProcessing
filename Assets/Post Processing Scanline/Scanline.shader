Shader "Hidden/Custom/CRTEffect"
{
    HLSLINCLUDE
    #include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

    TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
    float _ScanlineSpeed;
    float _ScanlineStrength;
    int _ScanlineCycle;

    half4 Frag(VaryingsDefault i) : SV_Target
    {
        half2 uv = i.texcoord;
        half4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, uv);
        color -= sin((uv.y + _Time.x * _ScanlineSpeed) * _ScanlineCycle) * _ScanlineStrength;
        return color;
    }
    ENDHLSL

    SubShader
    {
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            HLSLPROGRAM
            #pragma vertex VertDefault
            #pragma fragment Frag
            ENDHLSL
        }
    }

}