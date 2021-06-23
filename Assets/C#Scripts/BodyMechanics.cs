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
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        HB.SetHealth(health,maxHealth);
        if(health <= 0)
        {
            Destroy(gameObject);
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
        if(UpS != null)
        {
            UpS.eXP += eXP;
        }
    }
}
