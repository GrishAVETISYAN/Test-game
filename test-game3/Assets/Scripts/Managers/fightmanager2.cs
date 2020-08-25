using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fightmanager2 : MonoBehaviour
{
    GameObject attackObject;
    PolygonCollider2D PC;
    attackScript AS;

    createSegmentCircle CSC;
    
    charHealth CH;


    



    [SerializeField] int process = 0;
    [SerializeField] int processClass = 0;

    float[] sweepTimes  = new float[] { 0.5f,   0.6f,     0.1f      };//process 1
    float[] attackTimes = new float[] { 0.4f,   0.2f,   0.1f    };//process 2
    float[] attackRadius= new float[] { 1f,     1.5f,   2f      };
    float[] attackAngles = new float[] { 30f,    60f,    60f     };




    float[] timeDamage = new float[] { 1f, 1f, 0.1f };

    int[] onceHealthDamage = new int[] { 10, 15, 5 };
    int[] onceBalanceDamage = new int[] { 5, 3, 0 };
    int[] onceManaDamage = new int[] { 0, 0, 1 };

    int[] moreHealthDamage = new int[] { 1, 0, 0 };
    int[] moreBalanceDamage = new int[] { 1, 1, 1 };
    int[] moreManaDamage = new int[] { 0, 0, 0 };

    int[] mySelfHealthDamage = new int[] { 0, 0, 0 };
    int[] mySelfBalanceDamage = new int[] { 10, 15, 5 };
    int[] mySelfManaDamage = new int[] { 0, 0, 1 };




    float attackAngle = 0;

    int[] attackKombo = new int[] { 1, 2, 2 };
    int[] attackAnimation = new int[] { 0, 1, 2 };
    int attackCurrsor = 0;
    float komboTime = 0.6f;
    [SerializeField]  bool komboChens = false;
    
    int komboCount = 0;
    
    float parringTime   = 0.5f;                                   //process 3
    
    bool shieldTime = true;

    [SerializeField]  float komboTimer = 0;
    float sweepTimer = 0;
    float attackTimer = 0;
    float parringTimer = 0;
    void Start()
    {
        
        CH = GetComponent<charHealth>();

        attackObject = new GameObject();
        AS = attackObject.AddComponent<attackScript>();


        attackObject.name = "attack";
        attackObject.tag = "Attack";
        attackObject.transform.parent = transform;
        attackObject.transform.localPosition = new Vector2(0, 0);
        PC = attackObject.AddComponent<PolygonCollider2D>();
        PC.isTrigger = true;
        Rigidbody2D RB2 = attackObject.AddComponent<Rigidbody2D>();
        RB2.bodyType = RigidbodyType2D.Kinematic;
        
        CSC = attackObject.AddComponent<createSegmentCircle>();
        CSC._doCreateZero(PC);
    }

    // Update is called once per frame
    void Update()
    {
        processing();
        
    }
    public int _getAnimationProcessAttackClass()
    {
        return (attackAnimation[processClass]);
    }
    public int _getProcess()
    {
        return (process);
    }

    void processing()
    {
        
            if (komboChens)
            {
                komboTimer += Time.deltaTime;
                if (komboTimer > komboTime)
                {
                    komboChens = false;
                }
            }
        

        if (process == 1)
        {
            sweepTimer += Time.deltaTime;
            if(sweepTimer> sweepTimes[processClass])
            {
                doAttackAttack(processClass);
            }
        }
        if (process == 2)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTimes[processClass])
            {
                CSC._doCreateZero(PC);
                
                
                    if (attackKombo[attackCurrsor] != -1 &&( komboCount>0))
                    {
                        doIdle();
                        doAttackSweep(attackKombo[attackCurrsor]);
                        komboCount -= 1;
                    }
                    else
                    {
                        
                        doIdle();
                    }
                
                
            }
        }
        if (process == 3)
        {
            parringTimer += Time.deltaTime;
            if (parringTimer > parringTime)
            {
                doShieldShield();
            }
        }
        if (process == 4)
        {
            if (!shieldTime)
            {
                doIdle();
            }
        }
    }

    public void _doAttack(float alpha = 0,int attackClass=0,bool komboing = false)
    {
        if(process == 0)
        {
            
            if(komboChens && komboing && attackKombo[attackCurrsor]!=-1)
            {
                //komboCount = 1;
                attackAngle = alpha;
                doAttackSweep(attackKombo[attackCurrsor]);
            }
            else
            {
                komboCount = 0;
                attackAngle = alpha;
                doAttackSweep(attackClass);
            }

        }
        if (process == 2)
        {

            if (komboChens && komboing && attackKombo[attackCurrsor] != -1)
            {
                komboCount = 1;
                //attackAngle = alpha;
                //doAttackSweep(attackKombo[attackCurrsor]);
            }
            

        }
    }

    public void _doAttackCombo(float alpha = 0, int attackClass = 0,int count = 0)
    {
        if (process == 0)
        {
            komboCount = count-1;
            
            attackAngle = alpha;
            doAttackSweep(attackClass);

        }
    }


    public void _doShield(bool shieldClass = true)
    {
        if (process == 0 || process == 1)
        {

            komboCount = 0;
            doShieldParring(shieldClass);

        }
    }
    public void _stopShield()
    {
        shieldTime = false;
    }



    void doShieldParring(bool shieldClass)
    {
        process = 3;
        parringTimer = 0;
        shieldTime = shieldClass;
    }
    void doShieldShield()
    {
        process = 4;
    }
    void doAttackSweep(int attackSweepClass)
    {
        process = 1;
        sweepTimer = 0;
        processClass = attackSweepClass;

    }
    void doAttackAttack(int attackAttackClass)
    {
        attackCurrsor = attackAttackClass;
        CH._getAttack(mySelfHealthDamage[attackCurrsor], mySelfBalanceDamage[attackCurrsor], mySelfManaDamage[attackCurrsor]);
        AS._changgeDamage(CH._getTeam(),timeDamage[attackCurrsor],
            onceHealthDamage[attackCurrsor],onceBalanceDamage[attackCurrsor],onceManaDamage[attackCurrsor],
            moreHealthDamage[attackCurrsor],moreBalanceDamage[attackCurrsor],moreManaDamage[attackCurrsor]);
        process = 2;
        attackTimer = 0;
        komboTimer = 0;
        komboChens = true;
        
        attackObject.transform.eulerAngles = new Vector3(0, 0, attackAngle);
        CSC._doCreateColider(PC, attackAngles[attackAttackClass], attackRadius[attackAttackClass]);

    }
    void doIdle()
    {
        process = 0;
        
    }
}
