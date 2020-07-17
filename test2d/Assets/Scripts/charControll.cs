using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControll : MonoBehaviour
{
    float sqrt2_2 = 0.70710678118f;
    //public float acc = 10f;
    //public float speed0 = 5f;

    Vector2 moveVector = new Vector2(0,0);
    //[SerializeField] Vector2 moveAccVector = new Vector2(0, 0);
    charMove CM;
    serializedVector SV;


    void Start()
    {
        
        CM = gameObject.GetComponent<charMove>();//sik
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool bW = Input.GetKey(KeyCode.W);
        bool bA = Input.GetKey(KeyCode.A);
        bool bS = Input.GetKey(KeyCode.S);
        bool bD = Input.GetKey(KeyCode.D);

        int trueCount = 0;
        if (bW) trueCount++;
        if (bA) trueCount++;
        if (bS) trueCount++;
        if (bD) trueCount++;

        if(trueCount==0 || trueCount == 4) moveVector = new Vector2(0,0);
        else if (trueCount == 1 || trueCount == 3) moveVector = new Vector2( (bD ? 1 : 0) -  (bA ? 1 : 0),  (bW ? 1 : 0) -  (bS ? 1 : 0));
        else if (trueCount == 2) moveVector = new Vector2(sqrt2_2 * (bD ? 1 : 0) - sqrt2_2 * (bA ? 1 : 0),  sqrt2_2 * (bW ? 1 : 0) - sqrt2_2 * (bS ? 1 : 0));
        
        /*
        if (moveAccVector.x != moveVector.x)
        {
            
            if (moveAccVector.x < moveVector.x - acc / 2)
                moveAccVector.x += acc * Time.deltaTime;
            if (moveAccVector.x > moveVector.x + acc / 2)
                moveAccVector.x -= acc * Time.deltaTime ;
            if (moveAccVector.x >= moveVector.x - acc / 2 && moveAccVector.x <= moveVector.x + acc / 2)
                moveAccVector.x = moveVector.x;
        }

        if (moveAccVector.y != moveVector.y)
        {
            if (moveAccVector.y < moveVector.y - acc/2)
                moveAccVector.y += acc * Time.deltaTime;
            if (moveAccVector.y > moveVector.y + acc / 2)
                moveAccVector.y -= acc * Time.deltaTime;
            if (moveAccVector.y >= moveVector.y - acc / 2 && moveAccVector.y <= moveVector.y + acc / 2)
                moveAccVector.y = moveVector.y;
        }*/
        CM.moveVector = moveVector;//sik
        
    }
}
