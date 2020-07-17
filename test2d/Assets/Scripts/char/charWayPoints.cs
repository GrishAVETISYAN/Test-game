using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class charWayPoints : MonoBehaviour
{
    public Vector2[] WPs= {new Vector2(0,-1), new Vector2(1, 1), new Vector2(-1, 1) };
    public int curssor = 0;
    bool end = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void _doAddCurrsor()
    {
        if(curssor == WPs.Length-1)
        {
            end = true;
        }
        else
        curssor++;
    }

}
