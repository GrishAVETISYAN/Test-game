using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    charMove CM;
    fightmanager2 FM;
    Animation_char AC;

    [SerializeField]bool move = false;
    bool _move = false;

    [SerializeField] bool side = false;
    bool _side = false;

    [SerializeField] int atackStatus = 0;
    [SerializeField] int atackStatusClass = 0;
    int _atackStatus = 0;

    private void Start()
    {
        CM = GetComponent<charMove>();
        AC = GetComponent<Animation_char>();
        FM = GetComponent<fightmanager2>();
    }


    private void Update()
    {
        move = CM.getIsMoved();
        side = CM.getSide();
        atackStatus = FM._getProcess();
        atackStatusClass = FM._getAnimationProcessAttackClass();

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
            
            //refreshAnimation();
            AC._animation_flip(side);
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
        
        if (!move)
        {
            if (atackStatus == 0)
            {
                AC._animation_player("idle", 2f,0);
            }
            else if (atackStatus == 1)
            {
                AC._animation_player("sweep" + atackStatusClass.ToString(), 2f, 1,1f);
            }
            else if (atackStatus == 2)
            {
                AC._animation_player("attack"+ atackStatusClass.ToString(), 2f, 1, 1f);
            }
            else if (atackStatus == 3)
            {
                AC._animation_player("idle_parring", 2f, 1);
            }
            else if (atackStatus == 4)
            {
                AC._animation_player("idle_shield", 1f,0);
            }
        }
        else if (move)
        {
            if (atackStatus == 0)
            {
                AC._animation_player("walk", 2,0);
            }
            else if (atackStatus == 1)
            {
                AC._animation_player("sweep" + atackStatusClass.ToString(), 2, 1, 2f);
            }
            else if (atackStatus == 2)
            {
                AC._animation_player("attack" + atackStatusClass.ToString(), 2, 1, 2f);
            }
            else if (atackStatus == 3)
            {
                AC._animation_player("walk_parring", 2, 1);
            }
            else if (atackStatus == 4)
            {
                AC._animation_player("walk_shield", 1,0);
            }


        }
    }
}
