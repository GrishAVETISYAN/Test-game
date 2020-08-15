using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botManager : MonoBehaviour
{
    GameObject Target;
    GameObject TargetPoint;
    
    


    botMoveManager BMM;
    fightmanager2 FM;

    [SerializeField]int presentSituation = 0;
    bool onStart = true;

    private void Start()
    {
        BMM = GetComponent<botMoveManager>();
        FM = GetComponent<fightmanager2>();


    }
    private void Update()
    {

        
        if (presentSituation == 2)
        {
            if (onStart)
            {
                
                BMM._botMoveManagerInit();
                BMM._changeTargetPosition(TargetPoint.transform.position);
                _initTarget();

                onStart = false;
            }

            BMM._botMoveManagerLoop(TargetPoint.transform.position);
        }
        else if (presentSituation == 3)
        {
            if (onStart)
            {
                FM._doAttack(Mathf.Atan2(Target.transform.position.y - transform.position.y, Target.transform.position.x - transform.position.x)*Mathf.Rad2Deg);

                onStart = false;
            }

           
        }

    }

        
    

    

    public void _setPresentSituation(int _presentSituation, GameObject targetPoint, GameObject target)
    {
        TargetPoint = targetPoint;
        Target = target;
        presentSituation = _presentSituation;
        onStart = true;
    }

    public void _refresh()
    {
        Debug.Log("refresh");
        if (presentSituation == 2)
            BMM._changeTargetPosition(new Vector2(TargetPoint.transform.position.x+0.5f, TargetPoint.transform.position.y + 0.5f));
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
