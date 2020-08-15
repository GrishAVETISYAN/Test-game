using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charHealth : MonoBehaviour
{
    [SerializeField] int HealthMax = 100;
    [SerializeField] int Health = 100;

    [SerializeField] int BalanceMax = 100;
    [SerializeField] int Balance = 100;

    [SerializeField] int ManaMax = 100;
    [SerializeField] int Mana = 100;

    

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

    public int _getHealth()
    {
        return (Health);
    }
    public int _getHealthMax()
    {
        return (HealthMax);
    }
    public int _getBalance()
    {
        return (Balance);
    }
    public int _getBalancehMax()
    {
        return (BalanceMax);
    }
    public int _getMana()
    {
        return (Mana);
    }
    public int _getManaMax()
    {
        return (ManaMax);
    }
}
