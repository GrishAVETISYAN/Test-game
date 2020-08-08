using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serializedWayPoints : MonoBehaviour
{
    dataBaseSprites Base;
    Sprite wayPoint;
    Sprite wayPointTrue;
    Sprite wayPointCurrsor;



    Vector2[] wayPoints;
    int currsor;

    public GameObject[] wayPointsObjects;
    public GameObject[] wayPointsObjectsCurrsors;
    void Awake()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        wayPoint = Base.spriteArray[2];
        wayPointTrue = Base.spriteArray[3];
        wayPointCurrsor = Base.spriteArray[4];



    }

    public void _doSetPositions(Vector2[] _wayPoints)
    {
        wayPoints = _wayPoints;
    }
    public void _doSetCurrsor(int _currsor)
    {
        
        currsor = _currsor;
    }
    public void _doSetPositionsAndCurrsor(Vector2[] _wayPoints, int _currsor)
    {

        _doSetPositions(_wayPoints);
        _doSetCurrsor(_currsor);
    }


    public void _doCreateWayPoints()
    {
        
        wayPointsObjects = new GameObject[wayPoints.Length];


        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPointsObjects[i] = new GameObject();
            wayPointsObjects[i].name = "wayPoint";
            SpriteRenderer SP = wayPointsObjects[i].AddComponent<SpriteRenderer>();
            wayPointsObjects[i].transform.position = wayPoints[i];
            if(i>= currsor) SP.sprite = wayPoint;
            else SP.sprite = wayPointTrue;
            ZorderScript ZS = wayPointsObjects[i].AddComponent<ZorderScript>();
            ZS.plus = 5;

        }
        wayPointsObjectsCurrsors = new GameObject[wayPoints.Length-1];

        for (int i=0;i< wayPoints.Length-1;i++)
        {
            wayPointsObjectsCurrsors[i] = new GameObject();
            wayPointsObjectsCurrsors[i].name = "wayPointCurrsor";
            SpriteRenderer SP = wayPointsObjectsCurrsors[i].AddComponent<SpriteRenderer>();
            wayPointsObjectsCurrsors[i].transform.position = (wayPoints[i]+ wayPoints[i+1])/2;
            SP.sprite = wayPointCurrsor;
            ZorderScript ZS = wayPointsObjectsCurrsors[i].AddComponent<ZorderScript>();
            ZS.plus = 5;
            SP.drawMode = SpriteDrawMode.Tiled;
            SP.size = new Vector2(_getToPointDistance(wayPoints[i], wayPoints[i + 1]), SP.size.y);
            
            wayPointsObjectsCurrsors[i].transform.eulerAngles = new Vector3(0,0, Mathf.Atan2(wayPoints[i+1].y - wayPoints[i].y, wayPoints[i + 1].x - wayPoints[i].x) * 180 / Mathf.PI);


        }
    }

    float _getToPointDistance(Vector2 v1, Vector2 v2)
    {
        return (Vector2.Distance(v1,v2));
    }

    public void _doDestroyWayPaints()
    {
        if(wayPointsObjects != null)
            foreach (GameObject obj in wayPointsObjects)
            {
                Destroy(obj);
            }
        if (wayPointsObjectsCurrsors != null)
            foreach (GameObject obj in wayPointsObjectsCurrsors)
            {
                Destroy(obj);
            }

    }

    public void _doRefresh()
    {

        _doDestroyWayPaints();
        _doCreateWayPoints();

    }


}
