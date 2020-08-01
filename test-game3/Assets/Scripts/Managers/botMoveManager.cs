using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botMoveManager : MonoBehaviour
{
    charMove CM;
    charGoTo CGT;
    serializedVector SV;

    charWayPoints CWP;
    serializedWayPoints SWP;

    wayFindPositionSystem WFPS;

    [SerializeField]    Vector2[] wayPoints;
    [SerializeField]    int wayPointsCurrsor = 0;


    [SerializeField]    GameObject targetWayFindObj;
    [SerializeField]    GameObject startWayFindObj;

    void Start()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        SV = GetComponent<serializedVector>();

        CWP = GetComponent<charWayPoints>();
        SWP = GetComponent<serializedWayPoints>();

        WFPS = Camera.main.GetComponent<wayFindPositionSystem>(); ;

        SV._doBegin();


        

    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            wayPoints = WFPS._retAStarCoords(targetWayFindObj.transform.position,startWayFindObj.transform.position);
            _doStartGoToWayPoints(wayPoints, wayPointsCurrsor);
        }
        if (Input.GetKey("space"))
        {
            _doLoopGoToWayPoints(wayPoints, wayPointsCurrsor);
        }

        

        



    }

    void _doLoopGoToWayPoints(Vector2[] _wayPoints, int _wayPointsCurrsor)//Go to way points loop
    {

        if (!CWP._getWayPointsEnd())
        {
            
            Vector2 moveVector = CGT._getGoTo(CWP._getTargetPosition());

            CM._doMove(moveVector);
            SV._doSerializedVector(moveVector);

            if (CGT._getGoToHome())
            {
                
                __doAddCurrsor();
                CWP._doAddCurrsorCheck(_wayPointsCurrsor);
                SWP._doSetCurrsor(_wayPointsCurrsor);
                SWP._doRefresh();


            }
        }
    }
    void _doStartGoToWayPoints(Vector2[] _wayPoints,int _wayPointsCurrsor)//Go to way points Init
    {

        CWP._doSetPositionsAndCurrsor(_wayPoints, _wayPointsCurrsor);
        SWP._doSetPositionsAndCurrsor(_wayPoints, _wayPointsCurrsor);

        SWP._doCreateWayPoints();
    }
    void _doLoopGoToPosition(Vector2 targetPosition)//Go to position Loop
    {
        //example: _doLoopGoToPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        Vector2 moveVector = CGT._getGoTo(targetPosition);

        CM._doMove                  (moveVector);
        SV._doSerializedVector      (moveVector);
    }

    void __doAddCurrsor()
    {
        if (wayPoints!= null)
        {
            if (wayPointsCurrsor == wayPoints.Length - 1)
            {
                //end = true;
                wayPointsCurrsor++;
            }
            else
                wayPointsCurrsor++;
        }
    }
}
