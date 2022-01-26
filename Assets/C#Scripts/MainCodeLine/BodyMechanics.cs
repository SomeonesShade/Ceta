using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: UI<HealthBar>, DATA, and UpgradeSystem
//Handles All Player and Object Health Systems
//Needs information on the Upgrade System's current stat for Health, and from DATA for specfic stat changes
public class BodyMechanics : MonoBehaviour
{
    public bool isPlayer;
    public float maxHealth, health, eXP, colDmg, regenTimer, regenSpeed;
    public UpgradeSystem UpS;
    public HealthBar HB;
    public float[] MaxHealth, HealthCooldown, RegenSpeed, BodyDamage;
    UpgradeSystem myUps;
    bool isHurt, isRecentlyHurt, isRegenerating;
    float regenCooldown;
    // Start is called before the first frame update
    void Awake()
    {
        if (isPlayer)
        {
            MaxHealth = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>().MaxHealth;
            HealthCooldown = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>().RegenerationCooldown;
            RegenSpeed = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>().RegenerationSpeed;
            BodyDamage = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>().CollisionDamage;
            myUps = this.gameObject.GetComponent<UpgradeSystem>();
            maxHealth = MaxHealth[myUps.playerStats.maxHealth];
            regenTimer = HealthCooldown[myUps.playerStats.healthRegeneration];
            regenSpeed = RegenSpeed[myUps.playerStats.healthRegeneration];
            colDmg = BodyDamage[myUps.playerStats.bodyDamage];
        }
        health = maxHealth; //set the health to max...
        isRecentlyHurt = false;
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        CollideCheck(other);
    }
    void OnCollisionStay2D(Collision2D other) 
    {
        CollideCheck(other);
    }
    void CollideCheck(Collision2D other)
    {
        GameObject otherg = other.gameObject;
        if (otherg.tag != "Wall")
        {
            if (otherg.tag != "Bullet" && otherg.tag != "Barrel")
            {//if its a squishy
                if(otherg.tag == "Hurtable" || otherg.tag == "Player")
                {
                    if (this.gameObject.tag != otherg.tag || this.gameObject.tag == "Player")
                    {
                        otherg.GetComponent<BodyMechanics>().Damage(colDmg);
                        otherg.GetComponent<BodyMechanics>().UpS = myUps;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Regenerate();
        if (isPlayer)
        {
            float healthpercent = health/maxHealth;
            StatUpdate();
            health = healthpercent * maxHealth;
            if(regenCooldown > regenTimer + 0.1f)
            {
                regenCooldown = regenTimer;
            }
        }
        HB.SetHealth(health,maxHealth); //set the health bar the correct values
        if(health <= 0)                 //ran out of lifepoints?
        {
            Destroy(gameObject);//die
        }
    }
    void StatUpdate()
    {
        maxHealth = MaxHealth[myUps.playerStats.maxHealth];
        regenTimer = HealthCooldown[myUps.playerStats.healthRegeneration];
        regenSpeed = RegenSpeed[myUps.playerStats.healthRegeneration];
        colDmg = BodyDamage[myUps.playerStats.bodyDamage];
    }
    void Regenerate()
    {
        if(maxHealth - 0.1f > health)
        {
            isHurt = true;
        }
        if (isHurt)
        {
            if (isRecentlyHurt)
            {
                isRecentlyHurt = false;
                regenCooldown = regenTimer;
            }
            regenCooldown = (health < maxHealth) ? regenCooldown - Time.deltaTime : 0;
            if (regenCooldown < 0.1f)
            {
                Heal(regenSpeed * Time.deltaTime);
            }
        }
        if (maxHealth <= health)
        {
            isHurt = false;
            isRecentlyHurt = false;
        }
        if (maxHealth < health)
        {
            health = maxHealth;
        }
    }
    public void Damage(float dmg)
    {
        health -= dmg;
        HB.StartCoroutine(HB.Activate(health,maxHealth,isPlayer));
        isHurt = true;
        isRecentlyHurt = true;
    }
    public void Heal(float hl)
    {
        health += hl;
    }
    void OnDestroy()
    {
        if(UpS != null) //ok gives out the exp to whoever killed this
        {
            UpS.eXP += eXP;
        }
    }
}
