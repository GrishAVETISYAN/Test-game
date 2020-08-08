using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botManager : MonoBehaviour
{
    public GameObject Target;
    GameObject TargetPoint;
    

    botMoveManager BMM;

    [SerializeField]int Behaviour = 1;//0-ban chi anum , 1-qayluma playeri pointi hetevic

    private void Start()
    {

        
    }
    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            
            TargetPoint = Target.GetComponent<playerFightPlease>().getPoint(gameObject);
            if (TargetPoint == null)
            {
                Behaviour = 0;
            }
                if (Behaviour == 1)
            {
                
                BMM = GetComponent<botMoveManager>();
                BMM._botMoveManagerInit();
                BMM._changeTargetPosition(TargetPoint.transform.position);
                _initTarget();
            }

        }

        if (Input.GetKey("space"))
        {
            if (Behaviour == 1)
            {
                BMM._botMoveManagerLoop(TargetPoint.transform.position);
            }
        }
    }

    

    void _goToTarget()
    {

    }

    public void _refresh()
    {
        Debug.Log("refresh");
        
        BMM._changeTargetPosition(new Vector2( Target.transform.position.x+0.5f, Target.transform.position.y + 0.5f));
    }




    void _initTarget()
    {
        Target.GetComponentInParent<translateEvent>()._addToBotManagerList(this);
    }
    void _destroyTarget()
    {
        Target.GetComponentInParent<translateEvent>()._removeToBotManagerList(this);
    }
}
