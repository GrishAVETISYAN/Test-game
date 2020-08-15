using DragonBones;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class charFightPlease : MonoBehaviour
{
    dataBaseSprites Base;
    Sprite pointTrue;
    Sprite pointFalse;

    
    
    public float radius = 1.5f;
    public int rounds = 4;

    GameObject[] points;
    public GameObject[] lords;
    public bool[] closess;
    private void Start()
    {
        points = new GameObject[rounds];
        lords = new GameObject[rounds];
        closess = new bool[rounds];

        for (int i = 0; i < rounds; i++)
        {
            closess[i] = true;
        }

        Base = Camera.main.GetComponent<dataBaseSprites>();
        pointTrue = Base.spriteArray[5];
        pointFalse = Base.spriteArray[16];


        for (int i = 0; i < rounds; i++) {
            GameObject point = new GameObject();
            point.name = "points "+(i+1).ToString();
            SpriteRenderer pointSR = point.AddComponent<SpriteRenderer>();
            pointSR.sprite = pointTrue;
            point.transform.parent = transform;
            point.transform.localPosition = new Vector2(Mathf.Cos(i * (360f / rounds) *Mathf.PI/180f) * radius, Mathf.Sin(i * (360f / rounds)  * Mathf.PI / 180) * radius);
            points[i] = point;
         }

        //ZorderScript ZS = myCurrsor.AddComponent<ZorderScript>();
        //ZS.plus = 5;
    }

    public GameObject getPoint(GameObject GM)
    {
        for (int i = 0; i< rounds; i++)
        {
            
            if (lords[i] == GM)
            {
                
                lords[i] = null;
                open(i);
            }
        }
        Vector2 botPos = GM.transform.position;
        float[] dist = new float[rounds];
        for (int i = 0; i < rounds; i++)
        {
            dist[i] = -1;
            if (closess[i])
            {
                dist[i] = Vector2.Distance(botPos, points[i].transform.position);
            }
        }
        float targetDist = -1;
        int targetID = -1;
        for (int i = 0; i < rounds; i++)
        {
            if(dist[i]!=-1 && targetDist == -1)
            {
                targetDist = dist[i];
                targetID = i;
            }
            if (dist[i] != -1 && targetDist != -1 && dist[i]< targetDist)
            {
                targetDist = dist[i];
                targetID = i;
            }
        }

        if (targetID != -1)
        {
            close(targetID);
            lords[targetID] = GM;
            return (points[targetID]);
            
            
        }
        else
        {
            return (null);

        }
        
    }

    void close(int id)
    {
        closess[id] = false;
        points[id].GetComponent<SpriteRenderer>().sprite = pointFalse;
    }

    void open(int id)
    {
        closess[id] = true;
        points[id].GetComponent<SpriteRenderer>().sprite = pointTrue;
    }
    public void _clear()
    {
        closess = new bool[rounds];

        for (int i = 0; i < rounds; i++)
        {
            closess[i] = true;
            points[i].GetComponent<SpriteRenderer>().sprite = pointTrue;
        }
    }
}
