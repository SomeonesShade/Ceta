using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DATA : ScriptableObject
{
    public int test;
    [SerializeField]
    public class Data_ClassBranches
    {
        [SerializeField]
        public GameObject[] Prefabsl;
    }
    [SerializeField]
    public class Data_NormalStats
    {
        [Header("Upgrades")]
        [Header("HealthRegeneration")]
        public float[] RegenerationCooldown;
        public float[] RegenerationSpeed;
        public float[] UDelayedDamage;//new Delays the Damage Dealt by spilliting it thus delay;
        [Header("MaxHealth")]
        public float[] MaxHealth;
        public float[] ULastInvincibility;//new Has Now a Secondary Sheild, that once broken gives invulnerability;
        [Header("BodyDamage")]
        public float[] CollisionDamage;
        public float[] UResistance; //new Decreases the Damage Inflicted (percentile and static);
        [Header("BulletSpeed")]
        public float[] OnFireForce;
        public float[] UBulletAcceleration;//new Speeds Up or Changes Direction (depends);
        [Header("Pierce")]
        public float[] Pierce;
        public float[] UBulletInvulnerability;//new Bullets can pass through when damaged;
        [Header("Damage")]
        public float[] BulletDamage;
        public float[] USplashDamage;//new Does Area Damage per hit, it allows to hit the hitted twice;
        [Header("Reload")]
        public float[] ShootCooldown;
        public float[] UBurstSalvo;//new Shots Now Charge up to a Max amount of Bullets;
        [Header("MovementSpeed")]
        public float[] MovementSpeed;
        public float[] UMovementAcceleration;//new Enables To Turn Faster, and Inreases Speed the more Perpendicular;
    }
}   
