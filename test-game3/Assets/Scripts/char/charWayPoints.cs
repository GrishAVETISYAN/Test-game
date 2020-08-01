using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class charWayPoints : MonoBehaviour
{
    Vector2[] WPs= {new Vector2(0,-1), new Vector2(1, 1), new Vector2(-1, 1) };
    int curssor = 0;
    [SerializeField]bool end = false;
    

    public bool _getWayPointsEnd()
    {

        return (end);
        
    }
    public Vector2 _getTargetPosition()
    {
        return (WPs[curssor]);
    }

    public Vector2[] _getTargetPositions()
    {
        return (WPs);
    }
    public int _getTargetPositionCurrsor()
    {
        return (curssor);
    }

    public void _doAddCurrsorCheck(int _curssor)
    {
        curssor = _curssor;
        if (curssor == WPs.Length)
        {
            end = true;
            
        }
        

    }

    public void _doSetPositions(Vector2[] _wayPoints)
    {
        WPs = _wayPoints;
    }
    public void _doSetCurrsor(int _currsor)
    {

        curssor = _currsor;
    }

    public void _doSetPositionsAndCurrsor(Vector2[] _wayPoints,int _currsor)
    {

        _doSetPositions(_wayPoints);
        _doSetCurrsor(_currsor);
    }

}
