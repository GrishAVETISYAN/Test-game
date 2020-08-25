Shader "painting shader"
{
    Properties
    {
        //_DrawPosition("Drow positio",Vector) = (-1,-1,0,0)
        _DrawBrush("Brush",2D) = "white"{}
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

            sampler2D _DrawBrush;
            float4 _DrawPosition;
            float _DrawAngle;//esiel ankyuna
            float _RestoreAmount;

            

            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                float4 previousColor = tex2D(_SelfTexture2D,IN.localTexcoord.xy);
                

                float2 pos = IN.localTexcoord.xy - _DrawPosition;

                float2x2 rot = float2x2(cos(_DrawAngle), -sin(_DrawAngle), sin(_DrawAngle),cos(_DrawAngle));
                pos = mul(rot,pos);//frcnuma 
                pos /= 0.1; //chapy poxuma
                pos += float2(.5, .5);//beruma cordinatneri skizby mejtex

                float4 drowColor = tex2D(_DrawBrush, pos);
                //float4 drowColor = smoothstep(0.02,.05,distance(IN.localTexcoord.xy,_DrawPosition));

                return min(previousColor, drowColor)+ _RestoreAmount;
            }
            ENDCG
        }
    }
}