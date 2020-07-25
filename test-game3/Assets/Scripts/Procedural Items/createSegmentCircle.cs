using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class createSegmentCircle : MonoBehaviour
{
    PolygonCollider2D PC;
    void Awake()
    {
        PC = GetComponent<PolygonCollider2D>();
        _doCreateColider();
    }

    // Update is called once per frame
    void _doCreateColider()
    {
        PC.pathCount = 1;
        PC.points = _getProceduralCircleColider(60f,2f);
    }

    Vector2[] _getProceduralCircleColider(float alpha, float R)
    {
        return(_getssCreateColider(alpha, R, (int)(alpha / 10)));
    }

    Vector2[] _getssCreateColider(float alpha, float R, int n)
    {
        Vector2[] v2s = new Vector2[n+2];
        v2s[0] = new Vector2(0,0);


        for (int i = 0; i < n+1; i++)
        {
            float stepAlpha = alpha / n * i;
            Vector2 v2= new Vector2(Mathf.Cos((alpha /2-stepAlpha)*Mathf.PI/180) *R, Mathf.Sin((alpha / 2 - stepAlpha )* Mathf.PI / 180) * R);
            //Debug.Log(stepAlpha);
            v2s[i + 1] = v2;
        }
        return (v2s);
        
    }
}
