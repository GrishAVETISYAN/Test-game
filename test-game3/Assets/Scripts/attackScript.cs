﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    [SerializeField]List<charHealth> CHs;
    float time = 1f;
    float timer = 1f;

    int[] oneDamage = new int[3] {10,0,0};//Healt, Balance, Mana
    int[] moreDamage = new int[3] {5,0,0};

    int team = 0;
    void Awake()
    {
        CHs = new List<charHealth>();
        transform.tag = "Spikes";
    }

    private void Update()
    {
        
        if (CHs.Count >0) {
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                foreach (charHealth CH in CHs)
                {
                    CH._getAttack(moreDamage[0], moreDamage[1], moreDamage[2]);
                }
                    
                timer = time;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Char" || collision.tag == "Player")
        {
            
            charHealth CH = collision.transform.GetComponentInParent<charHealth>();

            if (CH._getTeam() != team)
            {
                CHs.Add(CH);
                CH._getAttack(oneDamage[0], oneDamage[1], oneDamage[2]);

                
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Char" || collision.tag == "Player")
        {
            charHealth CH = collision.transform.GetComponentInParent<charHealth>();
            if (CH._getTeam() != team)
            {
                CHs.Remove(CH);
            }

        }
    }

    public void _changgeDamage(int _team, float _time = 0, int HealthOneDamage=0, int HealthMoreDamage = 0,int BalanceOneDamage=0,int BalanceMoreDamage = 0,int ManaOneDamage = 0,int ManaMoreDamage = 0)
    {
        team = _team;
        time = _time;
        oneDamage[0] = HealthOneDamage;
        oneDamage[1] = BalanceOneDamage;
        oneDamage[2] = ManaOneDamage;

        moreDamage[0] = HealthMoreDamage;
        moreDamage[1] = BalanceMoreDamage;
        moreDamage[2] = ManaMoreDamage;
        

    }

    







}
