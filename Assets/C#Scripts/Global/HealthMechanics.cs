using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMechanics : MonoBehaviour
{
    public HealthMechanics()
    {
        VariableReset();
    }
    public HealthMechanics(int inHealth, int inMaxHealth)
    {
        health = inHealth;
        maxHealth = inMaxHealth;
    }
    public HealthMechanics(int inMaxHealth)
    {
        maxHealth = inMaxHealth;
        health = inMaxHealth;
    }
    public float health;
    public float maxHealth;
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
    public void HealthSet(float newHealth)
    {
        health = (newHealth > maxHealth - 0.01f)? maxHealth : newHealth;
    }
    public void MaxHealthSet(float newMaxHealth)
    {
        float proportion = (maxHealth > 0.001f)? health/maxHealth : 0;
        maxHealth = newMaxHealth;
        health = proportion * maxHealth;
    }
    //You can change your mind on if this should be a class or an interface
    public interface IRegeneration
    {
        void Regenerate();
    }
    public interface ICollision
    {
        void CollideCheck();
    }
}
