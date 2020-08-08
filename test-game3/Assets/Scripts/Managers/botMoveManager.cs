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


    [SerializeField]    Vector2 targetWayFindPos;
    

    public void _botMoveManagerInit()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        SV = GetComponent<serializedVector>();

        CWP = GetComponent<charWayPoints>();
        SWP = GetComponent<serializedWayPoints>();

        WFPS = Camera.main.GetComponent<wayFindPositionSystem>(); ;

        SV._doBegin();


        

    }


    public void _botMoveManagerLoop(Vector2 tagetPos)
    {
        if(wayPoints.Length > 0) {
            wayPoints[wayPoints.Length - 1] = tagetPos;
            _doLoopGoToWayPoints(wayPoints, wayPointsCurrsor);
        }

    }

    public void _changeTargetPosition(Vector2 _targetWayFindPos)
    {
        targetWayFindPos = _targetWayFindPos;
        wayPoints = WFPS._retAStarCoords(targetWayFindPos, new Vector2(transform.position.x, transform.position.y));

        


        wayPointsCurrsor = 0;
        
        _doStartGoToWayPoints(wayPoints, wayPointsCurrsor);
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

        SWP._doDestroyWayPaints();
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
