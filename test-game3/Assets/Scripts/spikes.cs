using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    List<charHealth> CHs;
    float time = 1f;
    void Awake()
    {
        CHs = new List<charHealth>();
        transform.tag = "Spikes";
    }

    private void Update()
    {
        
        if (CHs.Count >0) {
            
            time -= Time.deltaTime;
            if (time <= 0)
            {
                foreach (charHealth CH in CHs)
                {
                    CH._getAttack(5);
                }
                    
                time = 1f;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Char")
        {
            
            charHealth CH = collision.transform.GetComponentInParent<charHealth>();
            CHs.Add(CH);
            CH._getAttack(10);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Char")
        {

            charHealth CH = collision.transform.GetComponentInParent<charHealth>();
            CHs.Remove(CH);
            

        }
    }

    

    



}
