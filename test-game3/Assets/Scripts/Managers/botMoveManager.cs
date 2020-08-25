using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botMoveManager : MonoBehaviour
{

    const bool SERIALIZED = false;

    charMove CM;
    charGoTo CGT;
    

    charWayPoints CWP;


    #if SERIALIZED
    serializedVector SV;
    serializedWayPoints SWP;
    #endif
    wayFindPositionSystem WFPS;

    [SerializeField]    Vector2[] wayPoints;
    [SerializeField]    int wayPointsCurrsor = 0;


    [SerializeField]    Vector2 targetWayFindPos;

    private void Start()
    {
        _botMoveManagerInit();
    }

    void _botMoveManagerInit()
    {
        CM = GetComponent<charMove>();
        CGT = GetComponent<charGoTo>();
        CWP = GetComponent<charWayPoints>();
        WFPS = Camera.main.GetComponent<wayFindPositionSystem>(); ;

        #if SERIALIZED
        SV = GetComponent<serializedVector>();
        SWP = GetComponent<serializedWayPoints>();
        SV._doBegin();
        #endif


        

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
    public void _stop()
    {
        CM._doMove(Vector2.zero);
        wayPoints = null;
        CWP._setWayPointsEnd(true);



        wayPointsCurrsor = 0;

        //_doStartGoToWayPoints(wayPoints, wayPointsCurrsor);
    }


    void _doLoopGoToWayPoints(Vector2[] _wayPoints, int _wayPointsCurrsor)//Go to way points loop
    {

        if (!CWP._getWayPointsEnd())
        {
            
            Vector2 moveVector = CGT._getGoTo(CWP._getTargetPosition());

            CM._doMove(moveVector);
            #if SERIALIZED
                    SV._doSerializedVector(moveVector);
            #endif

            if (CGT._getGoToHome())
            {
                
                __doAddCurrsor();
                CWP._doAddCurrsorCheck(_wayPointsCurrsor);
                #if SERIALIZED
                        SWP._doSetCurrsor(_wayPointsCurrsor);
                        SWP._doRefresh();
                #endif


            }
        }
    }
    void _doStartGoToWayPoints(Vector2[] _wayPoints,int _wayPointsCurrsor)//Go to way points Init
    {

        CWP._doSetPositionsAndCurrsor(_wayPoints, _wayPointsCurrsor);
        #if SERIALIZED
            SWP._doSetPositionsAndCurrsor(_wayPoints, _wayPointsCurrsor);
            SWP._doDestroyWayPaints();
            SWP._doCreateWayPoints();
        #endif
    }
    void _doLoopGoToPosition(Vector2 targetPosition)//Go to position Loop
    {
        //example: _doLoopGoToPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));


        Vector2 moveVector = CGT._getGoTo(targetPosition);

        CM._doMove                  (moveVector);
        #if SERIALIZED
                SV._doSerializedVector      (moveVector);
        #endif
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
