using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMechanics : MonoBehaviour
{
    public bool isPlayer;
    public float maxHealth;
    public float health;
    public float eXP;
    public UpgradeSystem UpS;
    public HealthBar HB;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth; //set the health to max..
    }

    // Update is called once per frame
    void Update()
    {
        HB.SetHealth(health,maxHealth); //set the health bar the correct values
        if(health <= 0)                 //ran out of lifepoints?
        {
            Destroy(gameObject);//die
        }
    }
    public void Damage(float dmg)
    {
        health -= dmg;
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
