using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botFightAnaliticManager : MonoBehaviour
{
    public GameObject Target;
    botManager BM;
    charWayPoints CWP;
    int presentAction = 0;
    int actionType = 0;

    [SerializeField]long presentReson = 0;
    long _presentReson = 0;

    //Actions   --------------------------------
    //0 - ban chi anum
    //1 - gnuma depi trvac ket
    //2 - gnal target chari pointneric meki mot
    //3 - attacka-a ani

    //reasons   --------------------------------    
    //******1 - Targety inchvor obekt-a              
    //******2 - Targety Char-a

    //*****1* - Targety Kaynaca
    //*****2* - Targety Qayluma

    //****1** - Targty Attacka Action chuni 
    //****2** - Targty Zazmax a anum 
    //****3** - Targty Attacka a anum 
    //****4** - Targty Parirovaniaya a anum 
    //****5** - Targty Shild a anum 

    //***1*** - motika
    //***2*** - heru
    

    //**1**** - HP > 90%
    //**2**** - HP > 70% <90%
    //**3**** - HP > 50% <70%
    //**4**** - HP > 30% <50%
    //**5**** - HP > 10% <30%
    //**6**** - HP < 10%



    //*1***** - Balance > 90%
    //*2***** - Balance > 70% <90%
    //*3***** - Balance > 50% <70%
    //*4***** - Balance > 30% <50%
    //*5***** - Balance > 10% <30%
    //*6***** - Balance < 10%


    //1****** - Mana > 90%
    //2****** - Mana > 70% <90%
    //3****** - Mana > 50% <70%
    //4****** - Mana > 30% <50%
    //5****** - Mana > 10% <30%
    //6****** - Mana < 10%


    //90000012 - erb mardy kaynaca mnacacy kap chuni







    [SerializeField] long[] behaviourReason;
    [SerializeField] int[] behaviourAction;

    void Start()
    {
        BM = GetComponent<botManager>();
        CWP = GetComponent<charWayPoints>();

    }

    // Update is called once per frame
    void Update()
    {
        getData();
        if (_presentReson != presentReson)
        {
            
            _presentReson = presentReson;
            checking();
        }
        /*
        if (Input.GetKeyDown("space"))
        {
            
            presentAction = 2;
            changeSituatin();
        }
        if (Input.GetKeyUp("space"))
        {
            presentAction = 0;
            changeSituatin();
        }

        if (Input.GetKeyDown("m"))
        {
            presentAction = 3;
            changeSituatin();
        }
        if (Input.GetKeyUp("m"))
        {
            presentAction = 0;
            changeSituatin();
        }*/
    }
    void checking()
    {
        int i = 0;
        foreach(int sl in behaviourReason)
        {
            if(compare(sl, presentReson))
            {
                if (presentAction != behaviourAction[i])
                {
                    presentAction = behaviourAction[i];
                    changeSituatin();
                }
            }
            i++;
        }
    }
    void getData()
    {
        presentReson = 90000000;



        bool tst = Target.tag == "Char";

        if (tst) {

            
            presentReson +=  2;
            presentReson += !Target.GetComponent<charMove>().getIsMoved() ? 10 : 20;
            presentReson += 100 * (Target.GetComponent<fightmanager2>()._getAnimationProcess() + 1);


            
            presentReson += (GetComponent<charWayPoints>()._getWayPointsEnd()?1:2) * 1000;


            float HP = (float)GetComponent<charHealth>()._getHealth() / (float)GetComponent<charHealth>()._getHealthMax();
            int addHP = 0;
            if (HP >= 0.9f) addHP = 1;
            else if (HP < 0.9f && HP >= 0.7f) addHP = 2;
            else if (HP < 0.7f && HP >= 0.5f) addHP = 3;
            else if (HP < 0.5f && HP >= 0.3f) addHP = 4;
            else if (HP < 0.3f && HP >= 0.1f) addHP = 5;
            else if (HP < 0.1f) addHP = 6;
            presentReson += addHP * 10000;

            float Balance = (float)GetComponent<charHealth>()._getBalance() / (float)GetComponent<charHealth>()._getBalancehMax();
            int addBalance = 0;
            if (Balance >= 0.9f) addBalance = 1;
            else if (Balance < 0.9f && Balance >= 0.7f) addBalance = 2;
            else if (Balance < 0.7f && Balance >= 0.5f) addBalance = 3;
            else if (Balance < 0.5f && Balance >= 0.3f) addBalance = 4;
            else if (Balance < 0.3f && Balance >= 0.1f) addBalance = 5;
            else if (Balance < 0.1f) addBalance = 6;
            presentReson += addBalance * 100000;

            float Mana = (float)GetComponent<charHealth>()._getMana() / (float)GetComponent<charHealth>()._getManaMax();
            int addMana = 0;
            if (Mana >= 0.9f) addMana = 1;
            else if (Mana < 0.9f && Mana >= 0.7f) addMana = 2;
            else if (Mana < 0.7f && Mana >= 0.5f) addMana = 3;
            else if (Mana < 0.5f && Mana >= 0.3f) addMana = 4;
            else if (Mana < 0.3f && Mana >= 0.1f) addMana = 5;
            else if (Mana < 0.1f) addMana = 6;
            presentReson += addMana * 1000000;

            //Debug.Log("HP:" + HP.ToString() + "-a:" + addHP.ToString() + " Balance:" + Balance.ToString() + "-a:" + addBalance.ToString() + " Mana:" + Mana.ToString() + "-a:" + addMana.ToString());
        }


        if (getCurrsor(presentReson, 1) == 1)
        {
            if (getCurrsor(presentReson, 2) == 0)
            {

            }
        }
    }

    bool compare(long master, long slave)//
    {
        bool b = true;
        for(int i =1; i<8; i++)
        {
            long mastCheck = getCurrsor(master, i);
            long slaveCheck = getCurrsor(slave, i);
            if (!(mastCheck==0 || mastCheck == slaveCheck))
            {
                b = false;
            }
        }
        return (b);
    }
    long getCurrsor(long target, int currsor)
    {
        //65420012
        //0
        int tens = 1;
        for(int i = 0;i< currsor; i++)
        {
            tens *= 10;
        }
        long ret = (target - (long)(target / tens) * tens)/(tens/10);

        return ret;
    }
    void changeSituatin()
    {
        GameObject TargetPoint;
        if (Target.tag == "Char")
            TargetPoint = Target.GetComponent<charFightPlease>().getPoint(gameObject);
        else
            TargetPoint = Target;

        BM._setPresentSituation(presentAction, actionType, TargetPoint,Target);
    }
}
