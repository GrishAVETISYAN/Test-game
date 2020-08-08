using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightManager : MonoBehaviour
{
    public int actionMode = 0;
    public bool lookMouseClk = true;

    public float click = 0;
    public bool BoolClickShild = false;//dardznel vor miayn bool ov karavarvi mishki pahy arandzin

    public float zamax = 0;
    public float attack = 0;
    public float parirovanie = 0;


    public float[] zamaxAttackTime  = {0.1f, 1f};//poqric mec
    public float[] attackTime       = {0.1f, 1f};
    public int     attackCurrsor    = 0;

    public float parirovanieTime = 0.1f;
    //public float shildMinTime = 0.1f;
    //public float shildTime = 0.1f;

    serializedAction SA;

    void Start()
    {
        SA = GetComponent<serializedAction>();
        SA._doBegin();
    }

    // Update is called once per frame
    void Update()
    {
        SA._doSerializedAction(actionMode);
        if (Input.GetMouseButtonDown(0))
        {
            click = 0;
            _doZamaxAttack(0);
        }
        if (Input.GetMouseButton(0))
        {
            click+= Time.deltaTime;
            if(click> zamaxAttackTime[0] * 3 / 4)
            {
                _doZamaxAttackChangeToZamaxAttack(1);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            click = 0;
            _doParirovanie();
            BoolClickShild = true;
        }
        if (Input.GetMouseButton(1))
        {
            
            click += Time.deltaTime;
            if (click > zamaxAttackTime[0] * 3 / 4)
            {
                _doZamaxAttackChangeToZamaxAttack(1);
            }
            
        }
        if (Input.GetMouseButtonUp(1))
        {

            BoolClickShild = false;
        }

        _doCheckLoop();





    }

    public int _getAttackStatus()
    {
        return (actionMode);
    }
    void _doIdle()
    {
        
        actionMode = 0;
    }
    void _doAttack()
    {
        if (actionMode == 1)
        {
            actionMode = 2;
        }
    }
    void _doShild()
    {
        if ( actionMode == 3)
        {
            actionMode = 4;
        }
    }

    void _doParirovanie()
    {
        if (actionMode == 0 || actionMode == 1)
        {
            parirovanie = 0;
            actionMode = 3;
        }
    }
    void _doZamaxAttack(int _attackCurrsor)
    {
        if (actionMode == 0)
        {
            attackCurrsor = _attackCurrsor;
            attack = 0;
            zamax = 0;
            actionMode = 1;
        }
    }
    
    void _doZamaxAttackChangeToZamaxAttack(int _attackCurrsor)
    {
        if (actionMode == 1)attackCurrsor = _attackCurrsor;
    }
    void _doCheckLoop()
    {
        if (actionMode == 1)
        {
            if(zamax> zamaxAttackTime[attackCurrsor])
            {
                _doAttack();
            }
            zamax += Time.deltaTime;
        }
        if (actionMode == 2)
        {
            if (attack > attackTime[attackCurrsor])
            {
                _doIdle();
            }
            attack += Time.deltaTime;
        }
        if (actionMode == 3)
        {
            if (parirovanie > parirovanieTime)
            {
                _doShild();
            }
            parirovanie += Time.deltaTime;
        }
        if (actionMode == 4)
        {
            if (!BoolClickShild)
            {
                _doIdle();
            }
            
        }

    }
}
