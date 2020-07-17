using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botManager : MonoBehaviour
{
    charMove CM;
    charGoTo CGT;
    serializedVector SV;
    Vector2 targetPosition;
    Vector2 moveVector;



    void Start()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        SV = GetComponent<serializedVector>();
    }

    
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveVector = CGT._geteGoTo(targetPosition);

        CM._doMove                  (moveVector);
        SV._doSerializedVector      (moveVector);
        



    }
}
