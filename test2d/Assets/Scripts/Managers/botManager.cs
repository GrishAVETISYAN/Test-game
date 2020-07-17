using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botManager : MonoBehaviour
{
    charMove CM;
    charGoTo CGT;
    serializedVector SV;
    Vector2 targetPosition;

    

    void Start()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        SV = GetComponent<serializedVector>();
    }

    
    void Update()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CGT.targetPosition = targetPosition;



    }
}
