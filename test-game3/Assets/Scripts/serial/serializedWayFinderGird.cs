using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serializedWayFinderGird : MonoBehaviour
{

    public GameObject canvas;
    public Font fnt;

    Text[,] texts;

    //Vector2 zero_position = new Vector2(0, 0);
    //float cells_distance = 1f;

    GameObject mainGird;
    


    public void _Do_Text(bool[,] closes, bool[,] blockBase, int[,]  sideStep, int[,]  sideDistanceToTarget, int[,] sideSideWeight, int[,] sideDir)
    {
        int len_x = closes.GetLength(1);
        int len_y = closes.GetLength(0);

        for (int y = 0; y < len_y; y++)
        {
            for (int x = 0; x < len_x; x++)
            {
                Text txt = texts[y, x];
                txt.text = "<color=white>("+x.ToString()+"," + y.ToString()+ ")</color>";
                if(closes[y, x])    txt.text += "<color=white> True </color>";
                else                txt.text += "<color=black> False </color>";
                if (sideStep[y, x] != -1) txt.text += "\n<color=yellow>" + sideStep[y, x].ToString() + "</color>";
                if (sideDistanceToTarget[y, x] != -1) txt.text += "    <color=blue>" + sideDistanceToTarget[y, x].ToString() + "</color>";
                if (sideSideWeight[y, x] != -1) txt.text += "    <color=red>" + sideSideWeight[y, x].ToString() + "</color>";

                if (blockBase[y, x]) txt.text += "\n<color=green> Open! </color>";
                else txt.text += "\n<color=red> Close! </color>";

                if (sideDir[y, x]==1) txt.text += "\n<color=purple>L</color>";
                else if (sideDir[y, x] == 2) txt.text += "\n<color=purple>LU</color>";
                else if (sideDir[y, x] == 3) txt.text += "\n<color=purple>U</color>";
                else if (sideDir[y, x] == 4) txt.text += "\n<color=purple>RU</color>";
                else if (sideDir[y, x] == 5) txt.text += "\n<color=purple>R</color>";
                else if (sideDir[y, x] == 6) txt.text += "\n<color=purple>RD</color>";
                else if (sideDir[y, x] == 7) txt.text += "\n<color=purple>D</color>";
                else if (sideDir[y, x] == 8) txt.text += "\n<color=purple>LD</color>";

            }
        }
    }
    public void _Do_create_gird(Vector2 zero_position, float cells_distance, bool[,] closes, int _start_pos_x, int _start_pos_y, int _target_pos_x, int _target_pos_y)
    {
        
        dataBaseSprites Base;
        Sprite cube;
        Sprite cube_close;
        Sprite cube_start;
        Sprite cube_target;

        Base = Camera.main.GetComponent<dataBaseSprites>();
        cube = Base.spriteArray[12];
        cube_close = Base.spriteArray[13];
        cube_start = Base.spriteArray[14];
        cube_target = Base.spriteArray[15];


        mainGird = new GameObject();
        mainGird.name = "mainGird";
        int len_x = closes.GetLength(1);
        int len_y = closes.GetLength(0);
        texts = new Text[len_y, len_x];

        for (int y = 0;y< len_y; y++)
        {
            for (int x = 0; x < len_x; x++)
            {

                GameObject GirdCell = new GameObject();
                GirdCell.name = "cell";

                SpriteRenderer GirdCellSR = GirdCell.AddComponent<SpriteRenderer>();

                ZorderScript ZS = GirdCell.AddComponent<ZorderScript>();
                ZS.plus = -96/2;
                GirdCell.transform.position = new Vector2(x * cells_distance,y* cells_distance);
                GirdCell.transform.parent = mainGird.transform;
                if (x == _start_pos_x && y == _start_pos_y)
                {
                    GirdCellSR.sprite = cube_start;
                }
                else if (x == _target_pos_x && y == _target_pos_y)
                {
                    GirdCellSR.sprite = cube_target;
                }
                else
                {
                    if (closes[y, x]) GirdCellSR.sprite = cube;
                    else GirdCellSR.sprite = cube_close;
                }

                GameObject text = CreateText(canvas.transform, x, y, Color.white);
                texts[y, x] = text.GetComponent<Text>();



            }

        }

        
    }
    GameObject CreateText(Transform canvas_transform, float x, float y, Color text_color)
    {
        GameObject UItextGO = new GameObject("Text");
        

        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);

        Text text = UItextGO.AddComponent<Text>();
        text.text = "txt";
        text.fontSize = 16;
        text.color = text_color;
        UItextGO.transform.SetParent(canvas_transform);
        text.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        text.font = fnt;
        

        return UItextGO;
    }

    public struct Coords
    {
        public Coords(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public int x { get; }
        public int y { get; }

        public override string ToString() => $"({x}, {y})";
    }
}
