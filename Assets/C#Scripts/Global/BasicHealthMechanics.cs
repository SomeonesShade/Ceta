using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicHealthMechanics : MonoBehaviour
{
    virtual public float Health
        {get{return health;} set{health = (value < MaxHealth)? value : MaxHealth;}}
    virtual public float MaxHealth
        {get{return maxHealth;} set{maxHealth = value;}}

    [SerializeField] protected float health;
    [SerializeField] protected float maxHealth;
    virtual public void OnValidate()
    {
        Health = health;
        MaxHealth = maxHealth;
    }

    virtual public void Heal(float amount)
    {
        Health += amount;
    }
    virtual public void Damage(float amount)
    {
        Health -= amount;
    }
}
