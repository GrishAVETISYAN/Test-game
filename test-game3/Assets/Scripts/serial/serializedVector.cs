using UnityEngine;

public class serializedVector : MonoBehaviour
{
    dataBaseSprites Base;
    Sprite currsor;//baseic petq vercni
    Sprite stop;//baseic petq vercni

    
    GameObject myCurrsor;
    SpriteRenderer myCurrsorSR;
    float alpha;
    public void _doBegin()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        currsor = Base.spriteArray[0];
        stop = Base.spriteArray[1];

        myCurrsor = new GameObject();
        myCurrsor.name = "currsor";
        myCurrsorSR =myCurrsor.AddComponent<SpriteRenderer>();

        ZorderScript ZS = myCurrsor.AddComponent<ZorderScript>();
        ZS.plus = 5;

        myCurrsor.transform.position = gameObject.transform.position;
        myCurrsor.transform.parent = transform;


    }

    
    public void _doSerializedVector(Vector2 vector)
    {
        

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
