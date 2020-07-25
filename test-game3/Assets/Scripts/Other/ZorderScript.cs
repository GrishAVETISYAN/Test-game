using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorderScript : MonoBehaviour
{
    public int plus;
    SpriteRenderer SR;
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SR.sortingOrder = (int)((-transform.position.y+((float)plus)/96f)*96);
    }
}
 