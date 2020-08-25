using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerFightController : MonoBehaviour
{

    [SerializeField] string attack = "m0";
    [SerializeField] string attackCombo = "m2";
    [SerializeField] string shield = "m1";

    bool bA = false;
    bool bC = false;
    bool bS = false;

    bool _bA = false;
    bool _bC = false;
    bool _bS = false;

    fightmanager2 FM;
    
    void Start()
    {
        FM = GetComponent<fightmanager2>();
    }

    // Update is called once per frame
    void Update()
    {
        //pizdec kerpi canrabernuma. PIZDEC KERPI GAVNOYA!!!


        bA = isMouse(attack) ? Input.GetMouseButton(int.Parse(attack[1].ToString())) : Input.GetKey(attack);
        bC = isMouse(attackCombo) ? Input.GetMouseButton(int.Parse(attackCombo[1].ToString())) : Input.GetKey(attackCombo);
        bS = isMouse(shield) ? Input.GetMouseButton(int.Parse(shield[1].ToString())) : Input.GetKey(shield);








        if (bA && !_bA)
        {
            doClick(0, 0);
            _bA = bA;

        }
        else if (!bA && _bA)
        {
            doClick(0, 2);
            _bA = bA;

        }


        if (bC && !_bC)
        {
            doClick(1, 0);
            _bC = bC;

        }
        else if (!bC && _bC)
        {
            doClick(1, 2);
            _bC = bC;

        }

        if (bS && !_bS)
        {
            doClick(2, 0);
            _bS = bS;

        }
        else if (!bS && _bS)
        {
            doClick(2, 2);
            _bS = bS;

        }

    }

    void doClick(int cur, int stat)
    {
        if(cur == 0)
        {
            if(stat == 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float alpha = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
                FM._doAttack(alpha, 0, true);
            }
        }

        if (cur == 1)
        {
            if (stat == 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //float dist = Vector2.Distance(transform.position, new Vector2(mousePos.x, mousePos.y));
                float alpha = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * 180 / Mathf.PI;
                FM._doAttackCombo(alpha, 0, 10);
            }
        }

        if (cur == 2)
        {
            if (stat == 0)
            {
                FM._doShield();

                Debug.Log("suk");
            }
            else if(stat == 2)
            {
                FM._stopShield();
                Debug.Log("a");
            }
        }
    }
    bool isMouse(string str)
    {
        char[] chrs = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        bool ret = false;
        if(str[0] == 'm')
        {
            foreach (char chr in chrs)
            {
                if (str[1] == chr)
                {
                    ret = true;
                }
            }
        }
        return (ret);
    }
}
