using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class SO_PlayerStats : ScriptableObject
{
    public int healthRegeneration,
        maxHealth,
        bodyDamage,
        bulletSpeed,
        pierce,
        damage,
        reload,
        movementSpeed;
    public int maxCapacity;
    public void SetValue(int[] set)
    {
        int a = 0;
        foreach(int i in set)
        {
            if(i >= this.maxCapacity)
            {
                IntToStatModify(a) = this.maxCapacity;
            }
            IntToStatModify(a) = i;
            a++;
        }
    }
    public void AddValue(int type, int amount)
    {
        if(IntToStatRead(type) < this.maxCapacity)
        {
            IntToStatModify(type) += amount;
        }
    }

    public ref int IntToStatModify(int type)
    {
        switch (type)
        {
            case 0:
                return ref this.healthRegeneration;
            case 1:
                return ref this.maxHealth;
            case 2:
                return ref this.bodyDamage;
            case 3:
                return ref this.bulletSpeed;
            case 4:
                return ref this.pierce;
            case 5:
                return ref this.damage;
            case 6:
                return ref this.reload;
            case 7:
                return ref this.movementSpeed;
            default:
                return ref this.healthRegeneration;
        }
    }
    public int IntToStatRead(int type)
    {
        switch (type)
        {
            case 0:
                return this.healthRegeneration;
            case 1:
                return this.maxHealth;
            case 2:
                return this.bodyDamage;
            case 3:
                return this.bulletSpeed;
            case 4:
                return this.pierce;
            case 5:
                return this.damage;
            case 6:
                return this.reload;
            case 7:
                return this.movementSpeed;
            default:
                return this.healthRegeneration;
        }
    }
}
