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
    Sprite parirovanie;
    Sprite shild;



    GameObject actionSerialized;
    SpriteRenderer actionSerializedSR;
    

    public void _doBegin()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        stop = Base.spriteArray[11];
        zamax = Base.spriteArray[10];
        attack = Base.spriteArray[7];
        powerAttack = Base.spriteArray[9];
        parirovanie= Base.spriteArray[8];
        shild = Base.spriteArray[6];

        actionSerialized = new GameObject();
        actionSerialized.name = "Action";
        actionSerializedSR = actionSerialized.AddComponent<SpriteRenderer>();

        actionSerialized.transform.position = gameObject.transform.position;
        actionSerialized.transform.parent = transform;

        ZorderScript ZS = actionSerialized.AddComponent<ZorderScript>();
        ZS.plus = 101;
    }

    public void _doSerializedAction(int action)
    {
       

        if (action==0)
        {
            actionSerializedSR.sprite = stop;
            
        }
        if (action == 1)
        {
            actionSerializedSR.sprite = zamax;
            
        }
        if (action == 2)
        {
            actionSerializedSR.sprite = attack;

        }
        if (action == 3)
        {
            actionSerializedSR.sprite = parirovanie;

        }
        if (action == 4)
        {
            actionSerializedSR.sprite = shild;

        }
        actionSerialized.transform.position = new Vector2(transform.position.x, transform.position.y+1);




    }
}
