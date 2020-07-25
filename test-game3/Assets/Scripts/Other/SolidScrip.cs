using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidScrip : MonoBehaviour
{
    Vector2 Normal;
    bool rendering = false;
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        _doRefreshNormal();
        _doRefreshRendering();
    }

    

    void _doRefreshNormal()
    {
        Normal = new Vector2(Mathf.Cos((transform.eulerAngles.z - 90) * Mathf.PI / 180), Mathf.Sin((transform.eulerAngles.z - 90) * Mathf.PI / 180));
    }
    public Vector2 _GetNormal()
    {
        return (Normal);
    
    }

    void _doRefreshRendering()
    {
        if (rendering)
        {
            SR.enabled = true;
        }
        else
        {
            SR.enabled = false;
        }
    }


}
