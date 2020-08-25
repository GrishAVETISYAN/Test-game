Shader "Painting Shader"
{
    Properties
    {
        _DrawPosition("Draw Position", vector) = (-1,-1,0,0) 
    }

    SubShader
    {
        Lighting Off
        Blend One Zero
        
        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0
            
            float4 _DrawPosition;
            
            
            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                //float4 color = text2D(_SelfTexture2D, IN.localTexcoord.xy);
                float4 color = smoothstep(0, .2, distance(IN.localTexcoord.xy, _DrawPosition));




                return color;
            }
            ENDCG
        }
    }
}