using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMechanics : MonoBehaviour
{
    HealthMechanics()
    {
        VariableReset();
    }
    HealthMechanics(int inHealth, int inMaxHealth)
    {
        health = inHealth;
        maxHealth = inMaxHealth;
    }
    HealthMechanics(int inMaxHealth)
    {
        maxHealth = inMaxHealth;
        health = inMaxHealth;
    }
    public float health{get;private set;}
    public float maxHealth{get;private set;}
    void VariableReset()
    {
        health = 1;
        maxHealth = 1;
    }
    public void Heal(float am)
    {
        health = (health + am > maxHealth - 0.01f)? maxHealth : health + am;
    }
    public void Damage(float am)
    {
        health = health - am;
    }
    public void MaxHealthSet(float newMaxHealth)
    {
        float proportion = (maxHealth > 0.001f)? health/maxHealth : 0;
        maxHealth = newMaxHealth;
        health = proportion * maxHealth;
    }
    //You can change your mind on if this should be a class or an interface
    interface IRegeneration
    {
        void Regenerate(float regenAmount, float waitTimer);
        void RegenFunction(float parameter);//Gets Refered by Regenerate, how the regen behavior works
    }
    interface ICollision
    {
        void CollideCheck();
    }
}
