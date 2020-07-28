using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public bool[,] closes = new bool[,]{
        { true, true , true, false, true },
        { true, true, true, false, true },
        { true, true, true, false, true },
        { true, true, true, true, true }};

    //bool[,] check = new bool[closes.GetLength(0), closes.GetLength(1)];
        

    Coords start_pos    = new Coords(0, 0);
    Coords target_pos   = new Coords(3, 3);


    void Start()
    {
        List<Coords> sideCoords = (get_sideCoords(new Coords(2,1)));
        List<int> sideStep= (get_sideStep(new Coords(2, 1)));
        List<int> sideDistanceToTarget = (get_sideDistanceToTarget(new Coords(2, 1)));
        List<int> sideWeight = (get_side_weigh(sideStep, sideDistanceToTarget));


        for (int i =0;i< sideCoords.Count;i++)
        {
            Debug.Log(sideCoords[i].ToString() + " _ " + sideStep[i].ToString() + " _ " + sideDistanceToTarget[i].ToString() + " _ " + sideWeight[i].ToString() + " (" + i.ToString() + ")");
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    List<int> get_side_weigh(List<int> sum1, List<int> sum2)
    {
        List<int> retCords = new List<int>();
        for(int i =0;i< sum1.Count; i++)
        {
            retCords.Add(sum1[i]+ sum2[i]);
        }
        return (retCords);
    }
    //
    List<int> get_sideDistanceToTarget(Coords find_position)
    {
        List<int> retCords = new List<int>();

        Coords array_size = new Coords(closes.GetLength(1), closes.GetLength(0));
        if (find_position.x < array_size.x - 1)
        {
            if (closes[find_position.y, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x+1) + target_pos.y - (find_position.y))*10);
            }
        }

        if (find_position.x < array_size.x - 1 && find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x + 1) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x])
            {
                retCords.Add((target_pos.x - (find_position.x) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.x > 0 && find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.x > 0)
        {
            if (closes[find_position.y, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y)) * 10);
            }
        }

        if (find_position.x > 0 && find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y+1)) * 10);
            }
        }

        if (find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x])
            {
                retCords.Add((target_pos.x - (find_position.x) + target_pos.y - (find_position.y+1)) * 10);
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x + 1) + target_pos.y - (find_position.y+1)) * 10);
            }
        }
        return (retCords);
    }
    List<int> get_sideStep(Coords find_position)
    {
        List<int> retCords = new List<int>();

        Coords array_size = new Coords(closes.GetLength(1), closes.GetLength(0));
        if (find_position.x < array_size.x - 1)
        {
            if (closes[find_position.y, find_position.x + 1])
            {
                retCords.Add(10);
            }
        }

        if (find_position.x < array_size.x - 1 && find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x + 1])
            {
                retCords.Add(14);
            }
        }
        if (find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x])
            {
                retCords.Add(10);
            }
        }
        if (find_position.x > 0 && find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x - 1])
            {
                retCords.Add(14);
            }
        }
        if (find_position.x > 0)
        {
            if (closes[find_position.y, find_position.x - 1])
            {
                retCords.Add(10);
            }
        }

        if (find_position.x > 0 && find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x - 1])
            {
                retCords.Add(14);
            }
        }

        if (find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x])
            {
                retCords.Add(10);
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y < array_size.y - 1)
        {
            if (closes[find_position.y + 1, find_position.x + 1])
            {
                retCords.Add(14);
            }
        }
        return (retCords);
    }
    List<Coords> get_sideCoords(Coords find_position)
    {
        List<Coords> retCords = new List<Coords>();

        Coords array_size= new Coords(closes.GetLength(1), closes.GetLength(0));
        if (find_position.x < array_size.x-1)
        {
            if(closes[find_position.y, find_position.x + 1])
            {
                retCords.Add(new Coords(find_position.x + 1, find_position.y));
            }
        }

        if (find_position.x < array_size.x-1 && find_position.y >0)
        {
            if (closes[find_position.y-1, find_position.x + 1])
            {
                retCords.Add(new Coords(find_position.x + 1, find_position.y-1));
            }
        }
        if (find_position.y > 0)
        {
            if (closes[find_position.y - 1, find_position.x])
            {
                retCords.Add(new Coords(find_position.x, find_position.y-1));
            }
        }
        if (find_position.x >0 && find_position.y > 0)
        {
            if (closes[find_position.y-1, find_position.x -1])
            {
                retCords.Add(new Coords(find_position.x -1, find_position.y-1));
            }
        }
        if (find_position.x > 0 )
        {
            if (closes[find_position.y, find_position.x - 1])
            {
                retCords.Add(new Coords(find_position.x - 1, find_position.y));
            }
        }
      
        if (find_position.x > 0 && find_position.y < array_size.y-1)
        {
            if (closes[find_position.y+1, find_position.x - 1])
            {
                retCords.Add(new Coords(find_position.x - 1, find_position.y+1));
            }
        }

        if (find_position.y < array_size.y-1)
        {
            if (closes[find_position.y + 1, find_position.x])
            {
                retCords.Add(new Coords(find_position.x, find_position.y+1));
            }
        }
        if (find_position.x < array_size.x-1 && find_position.y < array_size.y-1)
        {
            if (closes[find_position.y + 1, find_position.x+1])
            {
                retCords.Add(new Coords(find_position.x+1, find_position.y+1));
            }
        }
        return (retCords);
    }

    struct Coords
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
