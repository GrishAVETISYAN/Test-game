using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class serializedVector : MonoBehaviour
{
    public Sprite currsor;//baseic petq vercni
    public Sprite stop;//baseic petq vercni

    public Vector2 vector;
    GameObject myCurrsor;
    SpriteRenderer myCurrsorSR;
    [SerializeField] float alpha;
    void Start()
    {
        myCurrsor = new GameObject();
        myCurrsorSR=myCurrsor.AddComponent<SpriteRenderer>();
        
        myCurrsorSR.sortingOrder = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        myCurrsor.transform.position = gameObject.transform.position;

        if(vector != new Vector2(0, 0))
        {
            myCurrsorSR.sprite = currsor;
            alpha = getVectorAngel(vector);
        }
        else 
        {
            myCurrsorSR.sprite = stop;
            alpha = 0;
        }
        myCurrsor.transform.eulerAngles = new Vector3(0, 0, alpha);




    }

    float getVectorAngel(Vector2 vector)
    {
        float alpha = Mathf.Atan2(vector.y,vector.x)*180/Mathf.PI;
        return(alpha);
    }
}
