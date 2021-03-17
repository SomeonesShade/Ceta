using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMechanics : MonoBehaviour
{
    public int maxHealth;
    public int health;
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(int dmg)
    {
        health -= dmg;
    }
    public void Heal(int hl)
    {
        health += hl;
    }
}
