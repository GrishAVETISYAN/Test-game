using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMoveProjection : MonoBehaviour
{
    /*
    private void Start()
    {
        Vector2 Vec = new Vector2(Mathf.Cos(90 * Mathf.PI / 180f), Mathf.Sin(90 * Mathf.PI / 180f));
        Vector2 Norm = new Vector2(Mathf.Cos(-45f * Mathf.PI / 180f), Mathf.Sin(-45f * Mathf.PI / 180f));
        Debug.Log("1 Vec");
        Debug.Log(Vec);
        Debug.Log("1 Norm");
        Debug.Log(Norm);
        Debug.Log("1 Norm");
        Debug.Log(VecProjectino(Vec, Norm));
    }*/


    public Vector2 _vecProjectino(Vector2 Vec, Vector2 Norm)
    {
        Vector2 projVec = new Vector2(0, 0);
        float Nalpha = Mathf.Atan2(Norm.y, Norm.x);
        float Valpha = Mathf.Atan2(Vec.y, Vec.x);


        float NalphaDegree = Nalpha * 180f / Mathf.PI;
        float ValphaDegree = Valpha * 180f / Mathf.PI;

        if ((ValphaDegree <= ((NalphaDegree + 90f) % 360) && ValphaDegree >= 0) || (ValphaDegree >= ((NalphaDegree + 270f ) % 360) && ValphaDegree <= 360f))
        {
            
            projVec = Vec;
        }
        else
        {
            
            float TalphaDegree = (90 - NalphaDegree);
            float PAlphaDegree = (NalphaDegree + ValphaDegree)-90f;
            
            float Talpha = TalphaDegree * Mathf.PI / 180f;
            float PAlpha = PAlphaDegree * Mathf.PI / 180f;
            

            float Vlen = 1;//im vectori erkarutyuny misht 1 e
            float k = Vlen * Mathf.Sin(PAlpha);
            projVec = new Vector2(k * Mathf.Cos(Talpha), k * Mathf.Sin(Talpha));

        }
        return (projVec);
    }
}
