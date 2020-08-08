using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    playerMoveManager PMM;
    fightManager FM;
    Animation_char AC;

    [SerializeField]bool move = false;
    bool _move = false;

    [SerializeField] bool side = false;
    bool _side = false;

    [SerializeField] int atackStatus = 0;
    int _atackStatus = 0;

    private void Start()
    {
        PMM = GetComponent<playerMoveManager>();
        AC = GetComponent<Animation_char>();
        FM = GetComponent<fightManager>();
    }


    private void Update()
    {
        move = PMM.getIsMoved();
        side = PMM.getSide();
        atackStatus = FM._getAttackStatus();

        findChange();
        


    }

    void findChange()
    {
        if (_move != move)
        {
            refreshAnimation();
            _move = move;
        }

        if (_side != side)
        {
            
            refreshAnimation();
            _side = side;
        }

        if (_atackStatus != atackStatus)
        {
            
            refreshAnimation();
            
            _atackStatus = atackStatus;
        }
    }

    void refreshAnimation()
    {
        AC._animation_flip(side);
        if (!move)
        {
            if (atackStatus == 0)
            {
                AC._animation_player("Idle", 2);
            }
            else if (atackStatus == 1)
            {
                AC._animation_player("sweep", 2, 1);
            }
            else if (atackStatus == 2)
            {
                AC._animation_player("attack", 10, 1);
            }
            else if (atackStatus == 3)
            {
                AC._animation_player("Idle_to_idle_shield", 2, 1);
            }
            else if (atackStatus == 4)
            {
                AC._animation_player("Idle_shield", 1);
            }
        }
        else if (move)
        {
            if (atackStatus == 0)
            {
                AC._animation_player("walk", 2);
            }
            else if (atackStatus == 1)
            {
                AC._animation_player("walk_to_sweep", 2, 1);
            }
            else if (atackStatus == 2)
            {
                AC._animation_player("attack", 2, 1);
            }
            else if (atackStatus == 3)
            {
                AC._animation_player("walk_to_walk_shield", 2, 1);
            }
            else if (atackStatus == 4)
            {
                AC._animation_player("walk_shield", 1);
            }


        }
    }
}
