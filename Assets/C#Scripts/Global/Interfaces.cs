using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Interfaces
{
    public interface IHealth
    {
        float Health{set; get;}
        void Heal(float amount);
        void Damage(float amount);
    }
    public interface IRegeneration : IHealth
    {
        float RegenAmount{get; set;}
        float RegenCooldown{get; set;}
        void RegenCheck();
        void Regenerate();
    }
    public interface ICollision
    {
        float CollisionDamage{get; set;}
        void CollideCheck(GameObject gameObject);
    }
}
