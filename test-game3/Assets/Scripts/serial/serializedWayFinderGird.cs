using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serializedWayFinderGird : MonoBehaviour
{
    
    public GameObject txt;

    public bool[,] closes = new bool[,]{
        { true, true , true, true, true },
        { true, true, false, false, true },
        { true, true, true, false, true },
        { true, true, true, true, true }};

    Vector2 zero_position = new Vector2(0, 0);
    float cells_distance = 1f;

    GameObject mainGird;
    void Start()
    {
        
        
        _Do_create_gird( zero_position, closes.GetLength(1), closes.GetLength(0),  cells_distance);
    }

   

    void _Do_create_gird(Vector2 zero_position, int len_x, int len_y, float cells_distance)
    {
        dataBaseSprites Base;
        Sprite cube;
        Sprite cube_close;

        Base = Camera.main.GetComponent<dataBaseSprites>();
        cube = Base.spriteArray[12];
        cube_close = Base.spriteArray[13];


        mainGird = new GameObject();
        mainGird.name = "mainGird";

        for(int y = 0;y< len_y; y++)
        {
            for (int x = 0; x < len_x; x++)
            {

                GameObject GirdCell = new GameObject();
                GirdCell.name = "cell";

                SpriteRenderer GirdCellSR = GirdCell.AddComponent<SpriteRenderer>();

                ZorderScript ZS = GirdCell.AddComponent<ZorderScript>();
                ZS.plus = -96/2;
                GirdCell.transform.position = new Vector2(x* cells_distance,y* cells_distance);
                GirdCell.transform.parent = mainGird.transform;
                if (closes[y,x]) GirdCellSR.sprite = cube;
                else GirdCellSR.sprite = cube_close;


                GameObject txtObj = Instantiate(txt);
                txtObj.transform.position = new Vector2(x * cells_distance, y * cells_distance);
                
                txtObj.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

            }

        }

        
    }
}
