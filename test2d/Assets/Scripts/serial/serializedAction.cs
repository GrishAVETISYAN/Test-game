using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serializedAction : MonoBehaviour
{
    dataBaseSprites Base;

    Sprite stop;
    Sprite zamax;
    Sprite attack;
    Sprite powerAttack;
    


    GameObject actionSerialized;
    SpriteRenderer actionSerializedSR;
    

    void Start()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        stop = Base.spriteArray[11];
        zamax = Base.spriteArray[10];
        attack = Base.spriteArray[7];
        powerAttack = Base.spriteArray[9];

        actionSerialized = new GameObject();
        actionSerialized.name = "currsor";
        actionSerializedSR = actionSerialized.AddComponent<SpriteRenderer>();

        actionSerializedSR.sortingOrder = 1;
    }

    public void _doSerializedAction(int action)
    {
        actionSerialized.transform.position = gameObject.transform.position;

        if (action==0)
        {
            actionSerializedSR.sprite = stop;
            
        }
        if (action == 1)
        {
            actionSerializedSR.sprite = zamax;
            
        }
        if (action ==2)
        {
            actionSerializedSR.sprite = attack;

        }
        actionSerialized.transform.position = new Vector2(transform.position.x, transform.position.y+1);




    }
}
