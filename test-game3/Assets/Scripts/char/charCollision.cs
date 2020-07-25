using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class charCollision : MonoBehaviour
{
    charPhisicalMove CPM;
    void Start()
    {
        CPM=GetComponent<charPhisicalMove>();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.ToString() == "Solid")
        {
            SolidScrip SS = collision.GetComponentInParent<SolidScrip>();
            CPM._addComponent(SS._GetNormal());
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Solid")
        {
            SolidScrip SS = collision.GetComponent<SolidScrip>();
            CPM._deleteComponent(SS._GetNormal());
        }
    }
}
