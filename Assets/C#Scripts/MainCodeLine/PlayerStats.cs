using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class PlayerStats : MonoBehaviour
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
                IntToStat(a) = this.maxCapacity;
            }
            IntToStat(a) = i;
            a++;
        }
    }
    public void AddValue(int type, int amount)
    {
        IntToStat(type) += amount;
        if(IntToStat(type) >= maxCapacity)
        {
            IntToStat(type) = maxCapacity;
        }
    }

    public ref int IntToStat(int type)
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
    
}
