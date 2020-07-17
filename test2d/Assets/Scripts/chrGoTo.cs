using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class chrGoTo : MonoBehaviour
{
    public Vector2 targetPosition;
    Vector2 realPosition;
    [SerializeField] Vector2 moveVector;
    charMove CM;
    float errRange = 0.01f;
    void Start()
    {
        CM = gameObject.GetComponent<charMove>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        realPosition = gameObject.transform.position;
        moveVector = getVector(realPosition, targetPosition);
        CM.moveVector = moveVector;



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
