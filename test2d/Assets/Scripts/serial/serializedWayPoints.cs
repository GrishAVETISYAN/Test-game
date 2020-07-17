using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serializedWayPoints : MonoBehaviour
{
    dataBaseSprites Base;
    public Sprite wayPoint;
    


    public Vector2[] wayPoints;
    public GameObject[] wayPointsObjects;
    void Start()
    {
        Base = Camera.main.GetComponent<dataBaseSprites>();
        wayPoint = Base.wayPoint;
        _doCreateWayPoints();


    }

    // Update is called once per frame
    void Update()
    {
        
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
            SP.sprite = wayPoint;
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


}
