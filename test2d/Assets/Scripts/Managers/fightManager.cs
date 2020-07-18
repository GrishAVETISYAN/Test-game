using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightManager : MonoBehaviour
{
    public int actionMode = 0;
    public bool lookMouseClk = true;

    public float click = 0;

    public float zamax = 0;
    public float attack = 0;


    public float[] zamaxAttackTime  = {0.1f, 1f};//poqric mec
    public float[] attackTime       = {0.1f, 1f};
    public int     attackCurrsor    = 0;

    public float[] parirovanieTime = { 0.1f, 1f };//poqric mec
    //public float[] attackTime = { 0.1f, 1f };

    serializedAction SA;

    void Start()
    {
        SA = GetComponent<serializedAction>();
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
        
        _doCheckLoop();





    }
    void _doIdle()
    {
        
        actionMode = 0;
    }
    void _doAttack()
    {
        actionMode = 2;
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

    }
}
