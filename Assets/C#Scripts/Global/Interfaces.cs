using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Interfaces
{
    public interface IHealth
    {
        void Heal(float amount);
        void Damage(float amount);
    }
    public interface IRegeneration : IHealth
    {
        float regenAmount{get; set;}
        float regenCooldown{get; set;}
        void RegenCheck();
        void Regenerate();
    }
    public interface ICollision : IHealth
    {
        float collisionDamage{get; set;}
        void CollideCheck();
    }
}
