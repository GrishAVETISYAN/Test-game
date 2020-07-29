using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public int lenX = 5;
    public int lenY = 4;
    public bool[,] closesBase = new bool[,]{
        { true, true , true, false, true },
        { true, true, true, false, true },
        { true, true, true, false, true },
        { true, true, true, true, true }};

    public int[,] sideStepBase = new int[,]{
        { -1, -1 , -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 }};


    public int[,] sideSideDistanceToTargetBase = new int[,]{
        { -1, -1 , -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 }};

    public int[,] sideSideWeightBase = new int[,]{
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 },
        { -1, -1, -1, -1, -1 }};

    //bool[,] check = new bool[closes.GetLength(0), closes.GetLength(1)];


    Coords start_pos    = new Coords(1, 1);
    Coords target_pos   = new Coords(3, 3);

    
    void Start()
    {
        
        List<Coords> sideCoords = (get_sideCoords(start_pos));
        List<int> sideStep= (get_sideStep(start_pos));
        List<int> sideDistanceToTarget = (get_sideDistanceToTarget(start_pos));
        List<int> sideWeight = (get_side_weigh(sideStep, sideDistanceToTarget));

        changeSidestep(sideCoords, sideStep);
        ChangeSideDistanceToTarget(sideCoords, sideDistanceToTarget);
        ChangeSideSideWeight(sideCoords, sideWeight);

        List<Coords> tt = ret_coord_by_weight(find_min_weight());

        for (int i = 0; i < tt.Count; i++)
        {
            Debug.Log(tt[i].ToString());
        }

        
        sideCoords = (get_sideCoords(tt[0]));
        sideStep = (get_sideStep(tt[0]));
        sideDistanceToTarget = (get_sideDistanceToTarget(tt[0]));
        sideWeight = (get_side_weigh(sideStep, sideDistanceToTarget));


        changeSidestep(sideCoords, sideStep);
        ChangeSideDistanceToTarget(sideCoords, sideDistanceToTarget);
        ChangeSideSideWeight(sideCoords, sideWeight);






        serializedWayFinderGird SWFG = GetComponent<serializedWayFinderGird>();
        SWFG._Do_create_gird(new Vector2(0, 0), 1f, closesBase, start_pos.x, start_pos.y, target_pos.x, target_pos.y);
        SWFG._Do_Text(closesBase, sideStepBase, sideSideDistanceToTargetBase, sideSideWeightBase);


    }
    int find_min_weight()
    {
        int min = -1;
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                if (sideSideWeightBase[y, x] != -1)
                {
                    if(min == -1 || min > sideSideWeightBase[y, x])
                    {
                        min = sideSideWeightBase[y, x];
                    }
                    
                }
            }
        }
        return (min);
    }
    List<Coords> ret_coord_by_weight(int sum)
    {
        List<Coords> ret = new List<Coords>();
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                if(sideSideWeightBase[y,x] == sum)
                {
                    ret.Add(new Coords(x,y));
                }
            }
        }

        return (ret);
    }
    void ChangeSideSideWeight(List<Coords> _coords, List<int> _sideWeight)
    {
        for (int i = 0; i < _coords.Count; i++)
        {

            sideSideWeightBase[_coords[i].y, _coords[i].x] = _sideWeight[i];


        }
    }
    void changeSidestep(List<Coords> _coords, List<int> _sideSteps)
    {
        for (int i = 0; i < _coords.Count; i++)
        {

            sideStepBase[_coords[i].y, _coords[i].x] = _sideSteps[i];


        }
    }

    void ChangeSideDistanceToTarget(List<Coords> _coords, List<int> _sideDistanceToTarget)
    {
        for (int i = 0; i < _coords.Count; i++)
        {

            sideSideDistanceToTargetBase[_coords[i].y, _coords[i].x] = _sideDistanceToTarget[i];


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

        Coords array_size = new Coords(closesBase.GetLength(1), closesBase.GetLength(0));
        if (find_position.x < array_size.x - 1)
        {
            if (closesBase[find_position.y, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x+1) + target_pos.y - (find_position.y))*10);
            }
        }

        if (find_position.x < array_size.x - 1 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x + 1) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x])
            {
                retCords.Add((target_pos.x - (find_position.x) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.x > 0 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y-1)) * 10);
            }
        }
        if (find_position.x > 0)
        {
            if (closesBase[find_position.y, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y)) * 10);
            }
        }

        if (find_position.x > 0 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x - 1])
            {
                retCords.Add((target_pos.x - (find_position.x - 1) + target_pos.y - (find_position.y+1)) * 10);
            }
        }

        if (find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x])
            {
                retCords.Add((target_pos.x - (find_position.x) + target_pos.y - (find_position.y+1)) * 10);
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x + 1])
            {
                retCords.Add((target_pos.x - (find_position.x + 1) + target_pos.y - (find_position.y+1)) * 10);
            }
        }
        return (retCords);
    }
    List<int> get_sideStep(Coords find_position)
    {
        List<int> retCords = new List<int>();

        Coords array_size = new Coords(closesBase.GetLength(1), closesBase.GetLength(0));
        if (find_position.x < array_size.x - 1)
        {
            if (closesBase[find_position.y, find_position.x + 1])
            {
                retCords.Add(10);
            }
        }

        if (find_position.x < array_size.x - 1 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x + 1])
            {
                retCords.Add(14);
            }
        }
        if (find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x])
            {
                retCords.Add(10);
            }
        }
        if (find_position.x > 0 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x - 1])
            {
                retCords.Add(14);
            }
        }
        if (find_position.x > 0)
        {
            if (closesBase[find_position.y, find_position.x - 1])
            {
                retCords.Add(10);
            }
        }

        if (find_position.x > 0 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x - 1])
            {
                retCords.Add(14);
            }
        }

        if (find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x])
            {
                retCords.Add(10);
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x + 1])
            {
                retCords.Add(14);
            }
        }
        return (retCords);
    }
    List<Coords> get_sideCoords(Coords find_position)
    {
        List<Coords> retCords = new List<Coords>();

        Coords array_size= new Coords(closesBase.GetLength(1), closesBase.GetLength(0));
        if (find_position.x < array_size.x-1)
        {
            if(closesBase[find_position.y, find_position.x + 1])
            {
                retCords.Add(new Coords(find_position.x + 1, find_position.y));
            }
        }

        if (find_position.x < array_size.x-1 && find_position.y >0)
        {
            if (closesBase[find_position.y-1, find_position.x + 1])
            {
                retCords.Add(new Coords(find_position.x + 1, find_position.y-1));
            }
        }
        if (find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x])
            {
                retCords.Add(new Coords(find_position.x, find_position.y-1));
            }
        }
        if (find_position.x >0 && find_position.y > 0)
        {
            if (closesBase[find_position.y-1, find_position.x -1])
            {
                retCords.Add(new Coords(find_position.x -1, find_position.y-1));
            }
        }
        if (find_position.x > 0 )
        {
            if (closesBase[find_position.y, find_position.x - 1])
            {
                retCords.Add(new Coords(find_position.x - 1, find_position.y));
            }
        }
      
        if (find_position.x > 0 && find_position.y < array_size.y-1)
        {
            if (closesBase[find_position.y+1, find_position.x - 1])
            {
                retCords.Add(new Coords(find_position.x - 1, find_position.y+1));
            }
        }

        if (find_position.y < array_size.y-1)
        {
            if (closesBase[find_position.y + 1, find_position.x])
            {
                retCords.Add(new Coords(find_position.x, find_position.y+1));
            }
        }
        if (find_position.x < array_size.x-1 && find_position.y < array_size.y-1)
        {
            if (closesBase[find_position.y + 1, find_position.x+1])
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
