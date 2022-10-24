using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMechanics : BasicHealthMechanics
{
    override public float MaxHealth
        {get{return maxHealth;} set{MaxHealthSet(value);}}
    public HealthMechanics()
    {
        VariableReset();
    }
    public HealthMechanics(int inHealth, int inMaxHealth)
    {
        Health = inHealth;
        MaxHealth = inMaxHealth;
    }
    public HealthMechanics(int inMaxHealth)
    {
        MaxHealth = inMaxHealth;
        Health = inMaxHealth;
    }
    void VariableReset()
    {
        Health = 1;
        MaxHealth = 1;
    }
    /*
    public override void Heal(float am)
    {
        Health = (Health + am > MaxHealth - 0.01f)? MaxHealth : Health + am;
    }
    public override void Damage(float am)
    {
        Health = Health - am;
    }
    public void HealthSet(float newHealth)
    {
        Health = (newHealth > MaxHealth - 0.01f)? MaxHealth : newHealth;
    }
    */
    public void MaxHealthSet(float newMaxHealth)
    {
        float proportion = (MaxHealth > 0.001f)? Health/MaxHealth : 0;
        maxHealth = newMaxHealth;
        Health = proportion * newMaxHealth;
    }
}
