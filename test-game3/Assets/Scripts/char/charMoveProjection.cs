using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class charMoveProjection : MonoBehaviour
{

    public Vector2 _vecProjectino(Vector2 Vec, Vector2 Norm) //Returns a projection vector that prevents you from hitting solid objects.
    {
        Vector2 projVec = new Vector2(0, 0);
        float Nalpha = Mathf.Atan2(Norm.y, Norm.x);
        float Valpha = Mathf.Atan2(Vec.y, Vec.x);


        float NalphaDegree = (Nalpha * 180f / Mathf.PI + 360f)%360f;
        float ValphaDegree = (Valpha * 180f / Mathf.PI+360f)%360f;

        if (Vec != new Vector2(0, 0))
        {
            if (ValphaDegree >= NalphaDegree - 90f && ValphaDegree <= NalphaDegree + 90f)
            {

                projVec = Vec;
            }
            else
            {


                float PAlphaDegree = (ValphaDegree - NalphaDegree - 90f + 360) % 360;
                float TalphaDegree = (ValphaDegree - PAlphaDegree + 360) % 360;

                float Talpha = TalphaDegree * Mathf.PI / 180f;
                float PAlpha = PAlphaDegree * Mathf.PI / 180f;


                float Vlen = 1;//im vectori erkarutyuny misht 1 e
                float k = Vlen * Mathf.Cos(PAlpha);
                projVec = new Vector2(k * Mathf.Cos(Talpha), k * Mathf.Sin(Talpha));
                //Debug.Log("Vec " + ValphaDegree.ToString() + ", Norm " + NalphaDegree.ToString() + ", PAlpha " + PAlphaDegree.ToString() + ", k " + k.ToString() + ", TAlpha " + TalphaDegree.ToString());

            }
        }
        else
        {
            projVec = new Vector2(0, 0);
        }


        



        return (projVec);
    }
}
