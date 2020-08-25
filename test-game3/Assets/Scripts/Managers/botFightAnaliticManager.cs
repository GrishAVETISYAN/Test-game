using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botFightAnaliticManager : MonoBehaviour
{



    //[SerializeField] int presentAction = 0;





    #region HELPERS
    //presentAction         --------------------------------
    //0 - ban chi anum
    //1 - gnuma depi trvac ket
    //2 - gnal target chari pointneric meki mot
    //3 - attacka-a ani

    //presentTargetReson            --------------------------------    
    //******1 - Targety inchvor obekt-a              
    //******2 - Targety Char-a

    //*****1* - Targety Kaynaca
    //*****2* - Targety Qayluma

    //****1** - Targty Attacka Action chuni 
    //****2** - Targty Zazmax a anum 
    //****3** - Targty Attacka a anum 
    //****4** - Targty Parirovaniaya a anum 
    //****5** - Targty Shild a anum 



    //presentSelfReson            --------------------------------  
    //*****1 - HP > 90%
    //*****2 - HP > 70% <90%
    //*****3 - HP > 50% <70%
    //*****4 - HP > 30% <50%
    //*****5 - HP > 10% <30%
    //*****6 - HP > 0%  <10% 
    //*****7 - HP <= 0%



    //****1* - Balance > 90%
    //****2* - Balance > 70% <90%
    //****3* - Balance > 50% <70%
    //****4* - Balance > 30% <50%
    //****5* - Balance > 10% <30%
    //****6* - Balance > 0%  <10% 
    //****7* - Balance <= 0%


    //***1** - Mana > 90%
    //***2** - Mana > 70% <90%
    //***3** - Mana > 50% <70%
    //***4** - Mana > 30% <50%
    //***5** - Mana > 10% <30%
    //***6** - Mana > 0%  <10% 
    //***7** - Mana <= 0%


    //**1*** - Menq Kaynaca
    //**2*** - Menq Qayluma

    //*1**** - Menq Attacka Action chuni 
    //*2**** - Menq Zazmax a anum 
    //*3**** - Menq Attacka a anum 
    //*4**** - Menq Parirovaniaya a anum 
    //*5**** - Menq Shild a anum 

    //1***** - motika
    //2***** - heru


    //90012 - erb mardy kaynaca mnacacy kap chuni
    #endregion
    public GameObject Target;
    botManager BM;

    charHealth TargetHelth;
    charMove TargetCharMove;
    fightmanager2 TargetFightManager;

    charHealth SelfHelth;
    charWayPoints SelfWayPoints;
    charMove SelfCharMove;
    fightmanager2 SelfFightManager;




    int presentAction;
    int _presentAction = -1;
    bool wait = true;

    //[SerializeField] 
    int[] presentReason;

    [SerializeField] string[] ReasonAction;
    string[] Reason;
    int[,] ParamReasonMin;
    int[,] ParamReason;
    int[,] ParamReasonMax;

    string[] Action;
    int[,] ParamAction;

    
    

    void Start()
    {
        BM = GetComponent<botManager>();


        changeTarget();

        int cnt = ReasonAction.Length;
        Reason = new string[cnt];
        Action = new string[cnt];
        for(int i = 0; i < cnt; i++)
        {
            string[] splites = ReasonAction[i].Split('|');
            Reason[i] = splites[0];
            Action[i] = splites[1];
        }

        CompileReason(Reason);
        CompileAction(Action);


        #region debug Reason and Action
        
        for (int i = 0;i< ParamReason.GetLength(0); i++)
        {
            string DebugReason =    "Reason:";
            string DebugReasonMin = "ReasonMin:";
            string DebugReasonMax = "ReasonMax:";
            string DebugAction = "Action:";

            for (int j = 0; j < ParamReason.GetLength(1); j++)
            {
                DebugReason     += ParamReason[i, j] + " ";
                DebugReasonMin  += ParamReasonMin[i, j] + " ";
                DebugReasonMax  += ParamReasonMax[i, j] + " ";
            }
            for (int j = 0; j < ParamAction.GetLength(1); j++)
            {
                DebugAction += ParamAction[i, j] + " ";
            }

            Debug.Log(DebugReason + " <=> " + DebugReasonMin + " <=> " + DebugReasonMax + " <=> " + DebugAction);
            
        }
        
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        
         getPresentReason();
         CheckReason();
        

    }

    void changeTarget()
    {
        TargetHelth = Target.GetComponent<charHealth>();
        TargetCharMove = Target.GetComponent<charMove>();
        TargetFightManager = Target.GetComponent<fightmanager2>();

        SelfHelth =  GetComponent<charHealth>();
        SelfWayPoints = GetComponent<charWayPoints>();
        SelfCharMove = GetComponent<charMove>();
        SelfFightManager = GetComponent<fightmanager2>();
    }


    
    IEnumerator doActionDelay(int actIndex)
    {
        
            presentAction = actIndex;
            wait = false;
            yield return new WaitForSeconds((float)ParamAction[actIndex,2]/1000f);
            wait = true;
            if (presentAction != -1)
            {
                if (_presentAction != presentAction || ParamAction[presentAction, 4] == 1)
                {


                    doAction();

                }
                else
                {
                    presentAction = -1;
                }
            }

    }
    void doAction()
    {

        
            //Debug.Log("Do Action |||  presentAction:" + presentAction.ToString()+ " _presentAction:" + _presentAction.ToString());
            GameObject TargetPoint = Target.GetComponent<charFightPlease>().getPoint(gameObject);
            BM._setPresentSituation(ParamAction[presentAction, 0], ParamAction[presentAction, 1], TargetPoint, Target);//poxel es yngerochy
            _presentAction = presentAction;
            presentAction = -1;
        
        
        
    }

    void doPreAction(int[] arr)
    {
        int rand = UnityEngine.Random.Range(0, 100);


        for (int i = 0; i < arr.Length; i++)
        {
            if (rand <= ParamAction[arr[i], 3])
            {
                if (wait)
                {
                    StartCoroutine(doActionDelay(arr[i]));
                }
                break;
            }
        }

    }
    void CheckReason()
    {
        List<int> doActionAtID = new List<int>();
        for (int i = 0; i < ParamReason.GetLength(0); i++)
        {
            bool cont = true;
            for (int j = 0; j < ParamReason.GetLength(1); j++)
            {

                int InsideReason = ParamReason[i, j];
                int InsideReasonMin = ParamReasonMin[i, j];
                int InsideReasonMax = ParamReasonMax[i, j];


                if (InsideReason == -1 && InsideReasonMin == -1 && InsideReasonMax == -1)
                {
                    continue;
                }
                else if (InsideReason != -1 && InsideReasonMin == -1 && InsideReasonMax == -1 &&
                        presentReason[j] != InsideReason) { cont = false; }
                else if (InsideReason == -1 && InsideReasonMin != -1 && InsideReasonMax != -1)
                {
                    if (InsideReasonMin < InsideReasonMax)
                    {
                        if (presentReason[j] > InsideReasonMin && presentReason[j] < InsideReasonMax) { cont = false; }
                    }
                    if (InsideReasonMin > InsideReasonMax)
                    {
                        if (presentReason[j] < InsideReasonMin || presentReason[j] > InsideReasonMax) { cont = false; }
                    }
                    if (InsideReasonMin == InsideReasonMax)
                    {
                        if (presentReason[j] == InsideReasonMin) { cont = false; }
                    }
                }
                else if (InsideReason == -1 && InsideReasonMin != -1 && InsideReasonMax == -1 &&
                        presentReason[j] >= InsideReasonMin) { cont = false; }
                else if (InsideReason == -1 && InsideReasonMin == -1 && InsideReasonMax != -1 &&
                        presentReason[j] <= InsideReasonMax) { cont = false; }
                else if (InsideReason != -1 && InsideReasonMin != -1 && InsideReasonMax == -1 &&
                        presentReason[j] > InsideReasonMin) { cont = false; }
                else if (InsideReason != -1 && InsideReasonMin == -1 && InsideReasonMax != -1 &&
                        presentReason[j] < InsideReasonMax) { cont = false; }


            }
            if (cont)
            {
                doActionAtID.Add(i);
            }
        }


        int[] newDoActionAtID = new int[doActionAtID.Count];


        for (int i = 0; i < newDoActionAtID.Length; i++)
        {
            int lower = ParamAction[doActionAtID[0], 3];
            int id = doActionAtID[0];


            for (int j = 1; j < doActionAtID.Count; j++)
            {
                if (lower > ParamAction[doActionAtID[j], 3])
                {
                    lower = ParamAction[doActionAtID[j], 3];
                    id = doActionAtID[j];
                }

            }
            doActionAtID.Remove(id);
            newDoActionAtID[i] = id;

        }
        if (newDoActionAtID.Length > 0)
        {
            doPreAction(newDoActionAtID);

            #region debaging doActionAtID
            /*
            string debaging = "can doActionAtID: ";
            for (int i = 0; i < newDoActionAtID.Length; i++)
            {
                debaging += newDoActionAtID[i] + " ";
            }

            Debug.Log(debaging);
            */
            #endregion
        }


    }
    void getPresentReason()
    {

        presentReason = new int[12];

        for(int i = 0;i< presentReason.Length; i++)
        {
            presentReason[i] = -1;
        }
        
        // 0 - Target type
        // 1 - Target move
        // 2 - Target action
        // 3 - Target HP
        // 4 - Target Balance
        // 5 - Target Mana

        // 6 -  distance
        // 7 -  Self Move
        // 8 -  Self Action
        // 9 -  Self HP
        // 10 - Self Balance
        // 11 - Self Mana

        
        

        bool tst = Target.tag == "Char";
        presentReason[0] = tst?1:0;

        if (tst)
        {

            presentReason[1] = TargetCharMove.getIsMoved() ? 1:0;
            presentReason[2] = TargetFightManager._getProcess();
            presentReason[3] = (int)(((float)TargetHelth._getHealth() / (float)TargetHelth._getHealthMax()) * 100);
            presentReason[4] = (int)(((float)TargetHelth._getBalance() / (float)TargetHelth._getBalancehMax()) * 100);
            presentReason[5] = (int)(((float)TargetHelth._getMana() / (float)TargetHelth._getManaMax()) * 100);

            presentReason[6] = (int)(Vector2.Distance(
                new Vector2(transform.position.x, transform.position.y),
                new Vector2(Target.transform.position.x, Target.transform.position.y))*10);

            presentReason[7] = SelfCharMove.getIsMoved() ? 1 : 0;
            presentReason[8] = SelfFightManager._getProcess();
            presentReason[9] = (int)(((float)SelfHelth._getHealth() / (float)SelfHelth._getHealthMax()) * 100);
            presentReason[10] = (int)(((float)SelfHelth._getBalance() / (float)SelfHelth._getBalancehMax()) * 100);
            presentReason[11] = (int)(((float)SelfHelth._getMana() / (float)SelfHelth._getManaMax()) * 100);

            
        }


        
    }
    void CompileReason(string[] ReasonStrings)
    {
        int ReasonsCount = ReasonStrings.Length;

        ParamReason =       new int[ReasonsCount,12];
        ParamReasonMin =    new int[ReasonsCount,12];
        ParamReasonMax =    new int[ReasonsCount,12];

        for (int i = 0; i < ParamReason.GetLength(0); i++)
        {
            for (int j = 0; j < ParamReason.GetLength(1); j++)
            {
                ParamReason[i, j] = -1;
                ParamReasonMin[i, j] = -1;
                ParamReasonMax[i, j] = -1;
            }
        }

        for (int i = 0; i < ReasonsCount; i++)
        {
            string[] strSplits = ReasonStrings[i].Split(';');
            int lenStrSplits = strSplits.Length;

            foreach (string str in strSplits)
            {
                string[] strSplit = str.Split(':');
                int len = strSplit.Length;

                for (int j = 0; j < len; j++)
                {
                    strSplit[j] = strSplit[j].ToLower();
                }

                int currsor = -1;
                if (strSplit[0] == "targetype" || strSplit[0] == "ttype" || strSplit[0] == "tt") { currsor = 0; }
                else if (strSplit[0] == "targetmove" || strSplit[0] == "tmove" || strSplit[0] == "tmv") { currsor = 1; }
                else if (strSplit[0] == "targetactio" || strSplit[0] == "taction" || strSplit[0] == "ta") { currsor = 1; }
                else if (strSplit[0] == "targethp" || strSplit[0] == "thp") { currsor = 3; }
                else if (strSplit[0] == "targetbalance" || strSplit[0] == "tbalance" || strSplit[0] == "tb") { currsor = 4; }
                else if (strSplit[0] == "targetmana" || strSplit[0] == "tmana" || strSplit[0] == "tma") { currsor = 5; }

                else if (strSplit[0] == "distance" || strSplit[0] == "dis" || strSplit[0] == "d") { currsor = 6; }
                else if (strSplit[0] == "selfmove" || strSplit[0] == "smove" || strSplit[0] == "smv") { currsor = 7; }
                else if (strSplit[0] == "selfactio" || strSplit[0] == "saction" || strSplit[0] == "sa") { currsor = 8; }
                else if (strSplit[0] == "selfhp" || strSplit[0] == "shp") { currsor = 9; }
                else if (strSplit[0] == "selfbalance" || strSplit[0] == "sbalance" || strSplit[0] == "sb") { currsor = 10; }
                else if (strSplit[0] == "selfmana" || strSplit[0] == "smana" || strSplit[0] == "sma") { currsor = 11; }


                

                #region indexes
                // 0 - Target type
                // 1 - Target move
                // 2 - Target action
                // 3 - Target HP
                // 4 - Target Balance
                // 5 - Target Mana

                // 6 -  Self Type
                // 7 -  Self Move
                // 8 -  Self Action
                // 9 -  Self HP
                // 10 - Self Balance
                // 11 - Self Mana


                #endregion

                if (len >= 3)
                {
                    if (currsor != -1)
                    {
                        if (strSplit[1] == "==" || strSplit[1] == "=")
                        {
                            ParamReason[i,currsor] = int.Parse(strSplit[2]);
                            ParamReasonMin[i,currsor]  = -1;
                            ParamReasonMax[i,currsor]  = -1;
                        }
                        else if (strSplit[1] == "!=" || strSplit[1] == "!")
                        {
                            ParamReason[i,currsor]  = -1;
                            ParamReasonMin[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMax[i,currsor]  = int.Parse(strSplit[2]);
                        }
                        else if (strSplit[1] == ">")
                        {
                            ParamReason[i,currsor]  = -1;
                            ParamReasonMin[i,currsor]  = -1;
                            ParamReasonMax[i,currsor]  = int.Parse(strSplit[2]);
                        }
                        else if (strSplit[1] == "<")
                        {
                            ParamReason[i,currsor]  = -1;
                            ParamReasonMin[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMax[i,currsor]  = -1;
                        }
                        else if (strSplit[1] == "=>" || strSplit[1] == ">=")
                        {
                            ParamReason[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMin[i,currsor]  = -1;
                            ParamReasonMax[i,currsor]  = int.Parse(strSplit[2]);
                        }
                        else if (strSplit[1] == "=<" || strSplit[1] == "<=")
                        {
                            ParamReason[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMin[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMax[i,currsor]  = -1;
                        }
                        else if (strSplit[1] == "e")
                        {
                            ParamReason[i,currsor]  = -1;
                            ParamReasonMin[i,currsor]  = int.Parse(strSplit[3]);
                            ParamReasonMax[i,currsor]  = int.Parse(strSplit[2]);
                        }
                        else if (strSplit[1] == "n")
                        {
                            ParamReason[i,currsor]  = -1;
                            ParamReasonMin[i,currsor]  = int.Parse(strSplit[2]);
                            ParamReasonMax[i,currsor]  = int.Parse(strSplit[3]);
                        }
                        else
                        {
                            ParamReason[i, currsor] = -1;
                            ParamReasonMin[i, currsor] = -1;
                            ParamReasonMax[i, currsor] = -1;
                        }
                    }

                }
                
            }
        }
    }
    void CompileAction(string[] ActionStrings)
    {
        int ActionCount = ActionStrings.Length;
        ParamAction = new int[ActionCount, 5];
        
        for (int i = 0; i < ParamAction.GetLength(0); i++)
        {

            ParamAction[i, 0] = -1;
            ParamAction[i, 1] = 0;
            ParamAction[i, 2] = 0;
            ParamAction[i, 3] = 100;
            ParamAction[i, 4] = 0;

        }
        for (int i = 0; i < ActionCount; i++)
        {
            string[] strSplits = ActionStrings[i].Split(';');
            int lenStrSplits = strSplits.Length;

            foreach (string str in strSplits)
            {
                string[] strSplit = str.Split(':');
                int len = strSplit.Length;

                for (int j = 0; j < len; j++)
                {
                    strSplit[j] = strSplit[j].ToLower();
                }
                int currsor = -1;
                if (strSplit[0] == "action" || strSplit[0] == "act" || strSplit[0] == "a") { currsor = 0;}
                else if (strSplit[0] == "action param" || strSplit[0] == "actionparam" || strSplit[0] == "actparam" || strSplit[0] == "ap") { currsor = 1; }
                else if (strSplit[0] == "delay" || strSplit[0] == "del" || strSplit[0] == "d") { currsor = 2; }
                else if (strSplit[0] == "random" || strSplit[0] == "rand" || strSplit[0] == "r") { currsor = 3; }
                else if (strSplit[0] == "loop" || strSplit[0] == "lp" || strSplit[0] == "l") { currsor = 4; }
                #region indexes
                // 0 - Action
                // 1 - Action Param

                // 2 - Delay
                // 3 - Random

                // 4 - loop
                #endregion
                if (len >= 2)
                {
                    if (currsor != -1)
                    {
                            ParamAction[i, currsor] = int.Parse(strSplit[1]);
                    }
                }
            }
        }
    }
}
