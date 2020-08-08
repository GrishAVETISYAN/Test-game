
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateEvent : MonoBehaviour
{

    List<botManager> BMS;
    Coords CD;

    
    void Start()
    {
        BMS = new List<botManager>();
        changePos(new Vector2((int)(transform.position.x - 0.5f), (int)(transform.position.y - 0.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v2 = new Vector2((int)(transform.position.x - 0.5f), (int)(transform.position.y - 0.5f));
        if(CD.x != (int)(transform.position.x - 0.5f) || CD.y != (int)(transform.position.y - 0.5f))
        {
            _doEvent();
            changePos(v2);
        }
    }


    void changePos(Vector2 v2)
    {
        CD = new Coords((int)(v2.x), (int)(v2.y));
    }


    void _doEvent()
    {
        foreach (botManager BM in BMS)
        {
            BM._refresh();
        }
        //Debug.Log("event");
    }


    public void _addToBotManagerList(botManager BM)
    {
        
        BMS.Add(BM);
    }
    public void _removeToBotManagerList(botManager BM)
    {
        BMS.Remove(BM);
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
