using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botManager : MonoBehaviour
{
    public GameObject Target;

    botMoveManager BMM;

    private void Start()
    {
        
        
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            BMM = GetComponent<botMoveManager>();
            BMM._botMoveManagerInit();
            BMM._changeTargetPosition(Target.transform.position);
            _initTarget();

        }

        if (Input.GetKey("space"))
        {
            BMM._botMoveManagerLoop(Target.transform.position);
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
        Target.GetComponent<translateEvent>()._addToBotManagerList(this);
    }
    void _destroyTarget()
    {
        Target.GetComponent<translateEvent>()._removeToBotManagerList(this);
    }
}
