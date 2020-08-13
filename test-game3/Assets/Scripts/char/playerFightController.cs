using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerFightController : MonoBehaviour
{
    fightmanager2 FM;
    void Start()
    {
        FM = GetComponent<fightmanager2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //float dist = Vector2.Distance(transform.position, new Vector2(mousePos.x, mousePos.y));
            float alpha = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x)*180/Mathf.PI;
            FM._doAttack(alpha,0,true);
        }
        if (Input.GetMouseButtonDown(2))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //float dist = Vector2.Distance(transform.position, new Vector2(mousePos.x, mousePos.y));
            float alpha = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * 180 / Mathf.PI;
            FM._doAttackCombo(alpha, 0,10);
        }

        if (Input.GetMouseButtonDown(1))
        {
            FM._doShield();
        }
        if (Input.GetMouseButtonUp(1))
        {
            FM._stopShield();
        }
    }
}
