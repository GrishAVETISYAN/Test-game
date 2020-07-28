using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthBleckBar;
    public Text HealtText;
    float HealthTimer=0;
    SpriteRenderer HealthBarRenderer;
    SpriteRenderer HealthBleckBarRenderer;
    float HealthBarLenght;
    int healthMax = 1000;
    public int health = 1000;
    int healthBleck = 1000;





    public GameObject BalanceBar;
    public GameObject BalanceBleckBar;
    public Text BalanceText;
    float BalanceTimer = 0;
    SpriteRenderer BalanceBarRenderer;
    SpriteRenderer BalanceBleckBarRenderer;
    float BalanceBarLenght;
    int BalanceMax = 800;
    public int Balance = 800;
    int BalanceBleck = 800;


    public GameObject ManaBar;
    public GameObject ManaBleckBar;
    public Text ManaText;
    float ManaTimer = 0;
    SpriteRenderer ManaBarRenderer;
    SpriteRenderer ManaBleckBarRenderer;
    float ManaBarLenght;
    int ManaMax = 200;
    public int Mana = 200;
    int ManaBleck = 200;


    public GameObject ManaPointBar;
    public GameObject ManaPointBleckBar;
    
    float ManaPointTimer = 0;
    SpriteRenderer ManaPointBarRenderer;
    SpriteRenderer ManaPointBleckBarRenderer;
    float ManaPointBarLenght;
    int ManaPointMax = 5;
    public int ManaPoint = 5;
    int ManaPointBleck = 5;


    void Start()
    {
        HealthBarRenderer = HealthBar.GetComponent<SpriteRenderer>();
        HealthBleckBarRenderer = HealthBleckBar.GetComponent<SpriteRenderer>();
        HealthBarLenght = HealthBarRenderer.size.x;

        BalanceBarRenderer = BalanceBar.GetComponent<SpriteRenderer>();
        BalanceBleckBarRenderer = BalanceBleckBar.GetComponent<SpriteRenderer>();
        BalanceBarLenght = BalanceBarRenderer.size.x;

        ManaBarRenderer = ManaBar.GetComponent<SpriteRenderer>();
        ManaBleckBarRenderer = ManaBleckBar.GetComponent<SpriteRenderer>();
        ManaBarLenght = ManaBarRenderer.size.x;

        ManaPointBarRenderer = ManaPointBar.GetComponent<SpriteRenderer>();
        ManaPointBleckBarRenderer = ManaPointBleckBar.GetComponent<SpriteRenderer>();
        ManaPointBarLenght = ManaPointBarRenderer.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        HealtText.text = healthMax.ToString() + "/" + health.ToString();
        HealthBarRenderer.size = new Vector2(((float)health / (float)healthMax) * HealthBarLenght, HealthBarRenderer.size.y);
        HealthBleckBarRenderer.size = new Vector2(((float)healthBleck / (float)healthMax) * HealthBarLenght, HealthBarRenderer.size.y);

        if (healthBleck > health)
        {
            HealthTimer += Time.deltaTime;
            if (HealthTimer > 0.05f)
            {
                healthBleck -= 5;
                HealthTimer = 0;
            }
        }
        else if (healthBleck < health)
        {
            healthBleck = health;
            HealthTimer = 0;
        }
        if (health < 0) health = 0;
        if (health > healthMax) health = healthMax;



        BalanceText.text = BalanceMax.ToString() + "/" + Balance.ToString();
        BalanceBarRenderer.size = new Vector2(((float)Balance / (float)BalanceMax) * BalanceBarLenght, BalanceBarRenderer.size.y);
        BalanceBleckBarRenderer.size = new Vector2(((float)BalanceBleck / (float)BalanceMax) * BalanceBarLenght, BalanceBarRenderer.size.y);

        if (BalanceBleck > Balance)
        {
            BalanceTimer += Time.deltaTime;
            if (BalanceTimer > 0.05f)
            {
                BalanceBleck -= 5;
                BalanceTimer = 0;
            }
        }
        else if (BalanceBleck < Balance)
        {
            BalanceBleck = Balance;
            BalanceTimer = 0;
        }
        if (Balance < 0) Balance = 0;
        if (Balance > BalanceMax) Balance = BalanceMax;



        ManaText.text = ManaMax.ToString() + "/" + Mana.ToString();
        ManaBarRenderer.size = new Vector2(((float)Mana / (float)ManaMax) * ManaBarLenght, ManaBarRenderer.size.y);
        ManaBleckBarRenderer.size = new Vector2(((float)ManaBleck / (float)ManaMax) * ManaBarLenght, ManaBarRenderer.size.y);

        if (ManaBleck > Mana)
        {
            ManaTimer += Time.deltaTime;
            if (ManaTimer > 0.05f)
            {
                ManaBleck -= 5;
                ManaTimer = 0;
            }
        }
        else if (ManaBleck < Mana)
        {
            ManaBleck = Mana;
            ManaTimer = 0;
        }
        if (Mana < 0) Mana = 0;
        if (Mana > ManaMax) Mana = ManaMax;




        
        ManaPointBarRenderer.size = new Vector2(((float)ManaPoint / (float)ManaPointMax) * ManaPointBarLenght, ManaPointBarRenderer.size.y);
        ManaPointBleckBarRenderer.size = new Vector2(((float)ManaPointBleck / (float)ManaPointMax) * ManaPointBarLenght, ManaPointBarRenderer.size.y);

        if (ManaPointBleck > ManaPoint)
        {
            ManaPointTimer += Time.deltaTime;
            if (ManaPointTimer > 0.3f)
            {
                ManaPointBleck -= 1;
                ManaPointTimer = 0;
            }
        }
        else if (ManaPointBleck < ManaPoint)
        {
            ManaPointBleck = ManaPoint;
            ManaPointTimer = 0;
        }
        if (ManaPoint < 0) ManaPoint = 0;
        if (ManaPoint > ManaPointMax) ManaPoint = ManaPointMax;
    }



    
}
