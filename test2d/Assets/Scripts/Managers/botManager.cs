using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botManager : MonoBehaviour
{
    charMove CM;
    charGoTo CGT;
    serializedVector SV;
    
    



    charWayPoints CWP;
    serializedWayPoints SWP;

    Vector2 moveVector;


    void Start()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        SV = GetComponent<serializedVector>();

        CWP = GetComponent<charWayPoints>();
        SWP = GetComponent<serializedWayPoints>();

        SWP._doSetPositions(CWP._getTargetPositions());
        SWP._doSetCurrsor(CWP._getTargetPositionCurrsor());
        SWP._doCreateWayPoints();
    }

    
    void Update()
    {


        /*
        //depi mouse gnal
        Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moveVector = CGT._geteGoTo(targetPosition);

        CM._doMove                  (moveVector);
        SV._doSerializedVector      (moveVector);*/

        //wayPointnerovGnaly
        if (!CWP._getWayPointsEnd()) {
            moveVector = CGT._getGoTo(CWP._getTargetPosition());

            CM._doMove(moveVector);
            SV._doSerializedVector(moveVector);

            if (CGT._getGoToHome())
            {
                
                CWP._doAddCurrsor();
                SWP._doSetCurrsor(CWP._getTargetPositionCurrsor());
                SWP._doRefresh();


            }
        }

    }
}
