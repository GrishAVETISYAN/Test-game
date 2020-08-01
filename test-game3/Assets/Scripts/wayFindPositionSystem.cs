using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class wayFindPositionSystem : MonoBehaviour
{
    public GameObject zero_pos_obj;
    public GameObject max_pos_obj;

    Vector2 zero_pos_obj_pos;
    Vector2 max_pos_obj_pos;

    AStar As;

    float distance = 1f;

    int len_x;
    int len_y;
    bool[,] closes;
    void Awake()
    {
        createGrid();
       
        
    }
    void Start()
    {
        As = GetComponent<AStar>();

    }

    public Vector2[] _retAStarCoords( Vector2 target, Vector2 start)
    {

        As._AddClosesBas(closes);
        
        As._AddStartTargetCoord((int)((  target.x- zero_pos_obj_pos.x) / distance), (int)((  target.y- zero_pos_obj_pos.y) / distance), (int)((start.x- zero_pos_obj_pos.x ) /distance), (int)(( start.y- zero_pos_obj_pos.y) / distance));
        AStar.Coords[] Data = As._findWay();
        Vector2[] retData = new Vector2[Data.Length];

        for(int i = 0; i < Data.Length; i++)
        {
            retData[i] = new Vector2(zero_pos_obj_pos.x + Data[i].x * distance, zero_pos_obj_pos.y + Data[i].y * distance);
        }

        Vector2[] _retData = retData;

        
        return (retData);
    }

    public void _setClosesTrue(int x, int y)
    {
        
        closes[(int)((y - zero_pos_obj_pos.y) / distance ), (int)((x - zero_pos_obj_pos.x) / distance)] = false;
    
    }

    void createGrid()
    {
        zero_pos_obj_pos = new Vector2(zero_pos_obj.transform.position.x, zero_pos_obj.transform.position.y);
        max_pos_obj_pos = new Vector2(max_pos_obj.transform.position.x, max_pos_obj.transform.position.y);
        len_x = (int)(max_pos_obj_pos.x / distance) - (int)(zero_pos_obj_pos.x / distance) + 1;
        len_y = (int)(max_pos_obj_pos.y / distance) - (int)(zero_pos_obj_pos.y / distance) + 1;

        closes = new bool[len_y, len_x];
        Debug.Log("closes len"+len_x.ToString() +" "+len_y.ToString());
        for (int y = 0; y < len_y; y++)
        {
            for (int x = 0; x < len_x; x++)
            {
                closes[y, x] = true;
            }
        }
    }
    

}
