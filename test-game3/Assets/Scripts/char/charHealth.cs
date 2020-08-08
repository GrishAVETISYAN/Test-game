using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charHealth : MonoBehaviour
{
    public int HealthMax = 100;
    public int Health = 100;

    public int BalanceMax = 100;
    public int Balance = 100;

    public int ManaMax = 100;
    public int Mana = 100;

    

    public void _getAttack(int health ,int balance=0, int mana=0)
    {

        //----------------------------Health
        if (health >= Health)
        {
            //ste satkuma
            Health = 0;
        }
        else
        {
            Health -= health;
        }

        //--------------------------------Balance
        if (balance >= Balance)
        {
            Balance = 0;
        }
        else
        {
            Balance -= balance;
        }

        //-------------------------------Mana

        if (mana >= Mana)
        {
            Mana = 0;
        }
        else
        {
            Mana -= mana;
        }
    }
}
