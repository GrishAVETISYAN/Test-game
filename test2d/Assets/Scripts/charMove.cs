using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    public Vector2 moveVector = new Vector2(0,0);
    public float moveSpeed =1f;
    serializedVector SV;
    void Start()
    {
        SV = gameObject.GetComponent<serializedVector>();
    }
    void FixedUpdate()
    {

        SV.vector = moveVector;
        Vector2 moveVectorTDT = new Vector2(moveVector.x*Time.deltaTime* moveSpeed, moveVector.y * Time.deltaTime* moveSpeed);
        gameObject.transform.Translate(moveVectorTDT);

    }
}
