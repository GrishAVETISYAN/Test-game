﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class charGoTo : MonoBehaviour
{

    Vector2 realPosition;

    float errRange = 0.01f;

    bool goToHome = false;

    public bool _getGoToHome()
    {
        return (goToHome);
    }
    // Update is called once per frame
    public Vector2 _getGoTo(Vector2 targetPosition)
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
        goToHome = false;
        if ((X < errRange && X > -errRange) &&( Y < errRange && Y > -errRange))
        {

            
                goToHome = true;
                moveVector = new Vector2(0, 0);
            
        }
        else
        {

            moveVector = new Vector2(X / R, Y / R);
        }
        return (moveVector);
    }
}
