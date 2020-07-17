using UnityEngine;

public class serializedVector : MonoBehaviour
{
    dataBaseSprites Base;
    Sprite currsor;//baseic petq vercni
    Sprite stop;//baseic petq vercni

    
    GameObject myCurrsor;
    SpriteRenderer myCurrsorSR;
    float alpha;
    void Start()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        currsor = Base.currsor;
        stop = Base.stop;

        myCurrsor = new GameObject();
        myCurrsorSR=myCurrsor.AddComponent<SpriteRenderer>();
        
        myCurrsorSR.sortingOrder = 1;

        
    }

    
    public void _doSerializedVector(Vector2 vector)
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
