using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class charGoTo : MonoBehaviour
{
    
    Vector2 realPosition;
    
    float errRange = 0.01f;
    

    // Update is called once per frame
    public Vector2 _geteGoTo(Vector2 targetPosition)
    {
        
        realPosition = gameObject.transform.position;
        Vector2 moveVector = getVector(realPosition, targetPosition);
        return (moveVector);



    }
    Vector2 getVector(Vector2 rp, Vector2 tp)
    {
        Vector2 moveVector;
        float X = tp.x - rp.x;
        float Y = tp.y - rp.y;


        float R = Mathf.Sqrt(X * X + Y * Y);

        if ((X < errRange && X > -errRange) ||( Y < errRange && Y > -errRange))
        {
            
            if (X == 0 && Y > errRange)
            {
                moveVector = new Vector2(0, 1f);
            }
            else if (X == 0 && Y < -errRange)
            {
                moveVector = new Vector2(0, -1f);
            }
            else if (X > errRange && Y == 0)
            {
                moveVector = new Vector2(1f, 0);
            }
            else if (X < -errRange && Y == 0)
            {
                moveVector = new Vector2(-1f, 0);
            }
            else moveVector = new Vector2(0, 0);
        }
        else
        {

            moveVector = new Vector2(X / R, Y / R);
        }
        return (moveVector);
    }
}
