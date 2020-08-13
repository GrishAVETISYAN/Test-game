using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charHealthBarManager : MonoBehaviour
{
    

    int HealthVar;
    int BalanceVar;
    int HealthMaxVar;
    int BalanceMaxVar;

    float MaxHealthSize;
    float MaxBalanceSize;

    GameObject healthBarObj;
    GameObject healthObj;
    GameObject BalanceObj;

    
    Sprite bar;
    Sprite health;
    Sprite balance;

    SpriteRenderer barSR;
    SpriteRenderer healthSR;
    SpriteRenderer balanceSR;

    charHealth CH;


    void Start()
    {
        CH = gameObject.GetComponent<charHealth>();
        refreshMaxVar();
        dataBaseSprites Base = Camera.main.GetComponent<dataBaseSprites>();

        bar = Base.spriteArray[17];
        health = Base.spriteArray[18];
        balance = Base.spriteArray[19];

        healthBarObj = new GameObject();
        healthObj = new GameObject();
        BalanceObj = new GameObject();

        healthBarObj.name = "HealthBar";
        healthObj.name = "Health";
        BalanceObj.name = "Balance";

        barSR = healthBarObj.AddComponent<SpriteRenderer>();
        healthSR = healthObj.AddComponent<SpriteRenderer>();
        balanceSR = BalanceObj.AddComponent<SpriteRenderer>();

        barSR.sprite = bar;
        healthSR.sprite = health;
        balanceSR.sprite = balance;

        healthSR.drawMode = SpriteDrawMode.Tiled;
        balanceSR.drawMode = SpriteDrawMode.Tiled;

        healthSR.sortingOrder = 2;
        balanceSR.sortingOrder = 2;


        healthBarObj.transform.parent = transform;
        healthObj.transform.parent = healthBarObj.transform;
        BalanceObj.transform.parent = healthBarObj.transform;


        healthBarObj.transform.localPosition = new Vector3(0, 1.3f, 0);
        healthObj.transform.localPosition = new Vector3(0, 1/96f*1.5f, 0);
        BalanceObj.transform.localPosition = new Vector3(0, -1 / 96f * 1.5f, 0);


        MaxHealthSize = healthSR.size.x;
        MaxBalanceSize = balanceSR.size.x;


        //ZorderScript ZS = healthBarObj.AddComponent<ZorderScript>();
        //ZS.plus = 101;

    }

    void refreshMaxVar()
    {
        HealthMaxVar = CH._getHealthMax();
        BalanceMaxVar = CH._getBalancehMax();

        
    }

    // Update is called once per frame
    void Update()
    {
        HealthVar = CH._getHealth();
        BalanceVar = CH._getBalance();

        healthSR.size = new Vector2(MaxHealthSize * HealthVar/HealthMaxVar , healthSR.size.y);
        balanceSR.size = new Vector2(MaxBalanceSize * BalanceVar/BalanceMaxVar , balanceSR.size.y);

    }

    
}
