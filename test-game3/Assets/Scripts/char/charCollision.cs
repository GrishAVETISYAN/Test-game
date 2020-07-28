using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class charCollision : MonoBehaviour
{
    playerManager PM;
    public void _doBegin()
    {
        PM=GetComponent<playerManager>();
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.ToString() == "Solid")
        {
            SolidScrip SS = collision.GetComponentInParent<SolidScrip>();
            PM._addComponentOnCharPhisicalMove(SS._GetNormal());
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Solid")
        {
            SolidScrip SS = collision.GetComponent<SolidScrip>();
            PM._deleteComponentOnCharPhisicalMove(SS._GetNormal());
        }
    }
}
