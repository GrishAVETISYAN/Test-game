using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serializedWayPoints : MonoBehaviour
{
    dataBaseSprites Base;
    Sprite wayPoint;
    Sprite wayPointTrue;



    Vector2[] wayPoints;
    GameObject[] wayPointsObjects;
    int currsor;
    void Start()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        wayPoint = Base.spriteArray[2];
        wayPointTrue = Base.spriteArray[3];
        


    }

    public void _doAddPositions(Vector2[] _wayPoints)
    {
        wayPoints = _wayPoints;
    }
    public void _doAddCurrsor(int _currsor)
    {
        
        currsor = _currsor;
    }



    public void _doCreateWayPoints()
    {
        
        wayPointsObjects = new GameObject[wayPoints.Length];
        
        int i = 0;
        foreach (Vector2 v2 in wayPoints)
        {
            wayPointsObjects[i] = new GameObject();
            wayPointsObjects[i].name = "wayPoint";
            SpriteRenderer SP = wayPointsObjects[i].AddComponent<SpriteRenderer>();
            wayPointsObjects[i].transform.position = v2;
            if(i>= currsor) SP.sprite = wayPoint;
            else SP.sprite = wayPointTrue;
            SP.sortingOrder = 2;
            i++;
        }
    }

    public void _doDestroyWayPaints()
    {
        
            foreach (GameObject obj in wayPointsObjects)
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
