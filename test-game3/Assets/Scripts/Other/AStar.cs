using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AStar : MonoBehaviour
{

    /*
     * bool[,] closesBase = new bool[,]{
        { true, true , true, true, true , true , true },
        { true, true, true, true, true, true , true  },
        { true, true, true, false, true, true , true  },
        { true, true, false, false, true , true , true },
        { true, true, true, true, true , true , true }};*/
    
     bool[,] closesBase;

    int lenX;
    int lenY;




    bool[,] blockBase;
     int[,] sideStepBase;
     int[,] sideSideDistanceToTargetBase;
    int[,] sideSideWeightBase;
    int[,] sideSideDir;

    //bool[,] check = new bool[closes.GetLength(0), closes.GetLength(1)];


    Coords start_pos    = new Coords(1, 2);
    Coords target_pos   = new Coords(5, 2);


    public List<Coords>  findWay(bool[,] _closesBase)
    {
        closesBase = _closesBase;
        lenX = closesBase.GetLength(1);
        lenY = closesBase.GetLength(0);

        blockBase = new bool[lenY, lenX];
        sideStepBase = new int[lenY, lenX];
        sideSideDistanceToTargetBase = new int[lenY, lenX];
        sideSideWeightBase = new int[lenY, lenX];
        sideSideDir = new int[lenY, lenX];

        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {

                blockBase[y, x] = true;

                sideStepBase[y, x] = -1;
                sideSideDistanceToTargetBase[y, x] = -1;
                sideSideWeightBase[y, x] = -1;
                sideSideDir[y, x] = -1;



            }
        }




       

       List<AStarStruct> AStartStructList = get_side(start_pos);
       change_side(AStartStructList);
       block(start_pos);


       List<Coords> minCoords;
       minCoords = ret_coord_by_weight(find_min_weight());
        
       bool b = check_0();



        while (!b) {

            if (minCoords.Count == 0)
            {
                // inchvor ban anel. bayc chi kara senc ban lini
            }
            else if (minCoords.Count >= 1)
            {
                AStartStructList = get_side(minCoords[0]);
                change_side(AStartStructList);
                block(minCoords[0]);
            }
            

            minCoords = ret_coord_by_weight(find_min_weight());
            b = check_0();


        }


        List<Coords> wayFinder = new List<Coords>();
        wayFinder.Add(target_pos);
        Coords last = wayFinder[wayFinder.Count - 1];



        while (last.x != start_pos.x || last.y != start_pos.y)
        {
            if (sideSideDir[last.y, last.x] == 1)
            {
                last = new Coords(last.x - 1, last.y);
            }
            else if (sideSideDir[last.y, last.x] == 2)
            {
                last = new Coords(last.x - 1, last.y + 1);
            }
            else if (sideSideDir[last.y, last.x] == 3)
            {
                last = new Coords(last.x, last.y + 1);
            }
            else if (sideSideDir[last.y, last.x] == 4)
            {
                last = new Coords(last.x + 1, last.y + 1);
            }
            else if (sideSideDir[last.y, last.x] == 5)
            {
                last = new Coords(last.x + 1, last.y);
            }
            else if (sideSideDir[last.y, last.x] == 6)
            {
                last = new Coords(last.x + 1, last.y - 1);
            }
            else if (sideSideDir[last.y, last.x] == 7)
            {
                last = new Coords(last.x, last.y - 1);
            }
            else if (sideSideDir[last.y, last.x] == 8)
            {
                last = new Coords(last.x - 1, last.y - 1);
            }
            wayFinder.Add(last);
            

        }


        foreach(Coords cd in wayFinder)
        {
            Debug.Log(cd);
        }

       return (wayFinder);
       //serializedWayFinderGird SWFG = GetComponent<serializedWayFinderGird>();
       //SWFG._Do_create_gird(new Vector2(0, 0), 1f, closesBase, start_pos.x, start_pos.y, target_pos.x, target_pos.y);
       //SWFG._Do_Text(closesBase, blockBase, sideStepBase, sideSideDistanceToTargetBase, sideSideWeightBase, sideSideDir);
       

    }

    bool check_0()
    {
        bool b = false;
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                if (sideSideDistanceToTargetBase[y, x] == 0)
                {
                    b = true;
                }
                



            }
        }
        return (b);

    }
    int find_min_weight()
    {
        int min = -1;
        for (int y = 0; y < lenY; y++)
        {
            for (int x = 0; x < lenX; x++)
            {
                if (sideSideWeightBase[y, x] != -1 && blockBase[y, x] && closesBase[y, x])
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
                if(sideSideWeightBase[y,x] == sum && blockBase[y, x] && closesBase[y, x])
                {
                    ret.Add(new Coords(x,y));
                }
            }
        }

        return (ret);
    }
    


    void block(Coords block_position)
    {
        blockBase[block_position.y, block_position.x] = false;
    }
    void change_side(List<AStarStruct> side)
    {
        for (int i = 0; i < side.Count; i++)
        {
            if (sideStepBase[side[i].coords.y, side[i].coords.x] == -1)
            {
                sideStepBase[side[i].coords.y, side[i].coords.x] = side[i].side_step;
                sideSideDistanceToTargetBase[side[i].coords.y, side[i].coords.x] = side[i].side_distance_to_target;
                sideSideWeightBase[side[i].coords.y, side[i].coords.x] = side[i].side_weigh;
                sideSideDir[side[i].coords.y, side[i].coords.x] = side[i].side_dir;
            }
            else if (sideStepBase[side[i].coords.y, side[i].coords.x]> side[i].side_step)
            {
                sideStepBase[side[i].coords.y, side[i].coords.x] = side[i].side_step;
                sideSideDistanceToTargetBase[side[i].coords.y, side[i].coords.x] = side[i].side_distance_to_target;
                sideSideWeightBase[side[i].coords.y, side[i].coords.x] = side[i].side_weigh;
                sideSideDir[side[i].coords.y, side[i].coords.x] = side[i].side_dir;
            }


        }
    }
    List<AStarStruct>  get_side(Coords find_position)
    {
        List<Coords> retCords = new List<Coords>();
        List<int> retSideStep = new List<int>();
        List<int> sideDistanceToTarget = new List<int>();
        List<int> side_weigh = new List<int>();

        List<AStarStruct> AStartStructList = new List<AStarStruct>();

        Coords array_size = new Coords(lenX, lenY);
        int addToSideStep = 0;

        
        if (sideStepBase[find_position.y, find_position.x] != -1)
        {
            addToSideStep = sideStepBase[find_position.y, find_position.x];
        }
            if (find_position.x < array_size.x - 1)
        {
            if (closesBase[find_position.y, find_position.x + 1] && blockBase[find_position.y, find_position.x + 1])
            {
                AStartStructList.Add(
                    
                    new AStarStruct(
                            new Coords(find_position.x + 1, find_position.y),
                            addToSideStep+10,
                            (Mathf.Abs(target_pos.x - (find_position.x + 1)) + Mathf.Abs(target_pos.y - (find_position.y))) * 10,
                            1
                    )
                );
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x + 1] && blockBase[find_position.y-1, find_position.x + 1])
            {

                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x + 1, find_position.y-1),
                            addToSideStep + 14,
                            (Mathf.Abs(target_pos.x - (find_position.x + 1)) + Mathf.Abs(target_pos.y - (find_position.y-1))) * 10,
                            2
                    )
                );
                
            }
        }
        if (find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x] && blockBase[find_position.y-1, find_position.x])
            {
                
                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x, find_position.y-1),
                            addToSideStep + 10,
                            (Mathf.Abs(target_pos.x - (find_position.x)) + Mathf.Abs(target_pos.y - (find_position.y-1))) * 10
                            ,3
                    )
                );
            }
        }
        if (find_position.x > 0 && find_position.y > 0)
        {
            if (closesBase[find_position.y - 1, find_position.x - 1] && blockBase[find_position.y-1, find_position.x - 1])
            {
                


                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x - 1, find_position.y-1),
                            addToSideStep + 14,
                            (Mathf.Abs(target_pos.x - (find_position.x - 1)) + Mathf.Abs(target_pos.y - (find_position.y-1))) * 10
                            ,4
                    )
                );
            }
        }
        if (find_position.x > 0)
        {
            if (closesBase[find_position.y, find_position.x - 1] && blockBase[find_position.y, find_position.x - 1])
            {
                
                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x - 1, find_position.y),
                            addToSideStep + 10,
                            (Mathf.Abs(target_pos.x - (find_position.x - 1)) + Mathf.Abs(target_pos.y - (find_position.y))) * 10
                            ,5
                    )
                );
            }
        }
        if (find_position.x > 0 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x - 1] && blockBase[find_position.y+1, find_position.x - 1])
            {
                

                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x - 1, find_position.y+1),
                            addToSideStep + 14,
                            (Mathf.Abs(target_pos.x - (find_position.x - 1)) + Mathf.Abs(target_pos.y - (find_position.y+1))) * 10
                            ,6
                    )
                );
            }
        }
        if (find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x] && blockBase[find_position.y+1, find_position.x + 1])
            {
                AStartStructList.Add(
                    new AStarStruct(
                            new Coords(find_position.x, find_position.y + 1),
                            addToSideStep + 10,
                            (Mathf.Abs(target_pos.x - (find_position.x )) + Mathf.Abs(target_pos.y - (find_position.y + 1))) * 10
                            ,7
                    )
                );
                
            }
        }
        if (find_position.x < array_size.x - 1 && find_position.y < array_size.y - 1)
        {
            if (closesBase[find_position.y + 1, find_position.x + 1] && blockBase[find_position.y+1, find_position.x + 1])
            {
                AStartStructList.Add(
                       new AStarStruct(
                               new Coords(find_position.x + 1, find_position.y + 1),
                               addToSideStep + 14,
                               (Mathf.Abs(target_pos.x - (find_position.x + 1)) + Mathf.Abs(target_pos.y - (find_position.y + 1))) * 10
                               ,8
                               
                       )
                   );
                
            }
        }
        return (AStartStructList);
    }


    struct AStarStruct
    {
        public AStarStruct(Coords _coords,int _side_step, int _side_distance_to_target, int _side_dir)
        {
            coords = _coords;
            side_step = _side_step;
            side_distance_to_target = _side_distance_to_target;
            side_weigh = _side_distance_to_target+ _side_step;
            side_dir = _side_dir;
        }

        public Coords coords { get; }
        public int side_step { get; }
        public int side_distance_to_target { get; }
        public int side_weigh { get; }
        public int side_dir { get; }


        public override string ToString() => $"(coords{coords}, side_step{side_step}, side_distance_to_target{side_distance_to_target}, side_weigh{side_weigh}, side_dir{side_dir})";
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
