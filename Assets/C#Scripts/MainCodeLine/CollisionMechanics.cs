using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMechanics : MonoBehaviour, Interfaces.ICollision
{   
    public float CollisionDamage
        {get{return collisionDamage;} set{collisionDamage = value;}}
    [SerializeField] float collisionDamage;
    //Updates if a value is changed in the inspector or loading in
    void OnValidate()
    {
        CollisionDamage = collisionDamage;
    }
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        CollideCheck(other.gameObject);
    }
    void OnCollisionStay2D(Collision2D other) 
    {
        CollideCheck(other.gameObject);
    }
    public void CollideCheck(GameObject gameObject)
    {
        GameObject otherg = gameObject;
        if (otherg.tag != "Wall")
        {
            if (otherg.tag != "Bullet" && otherg.tag != "Barrel")
            {//if its a squishy
                if(otherg.tag == "Hurtable" || otherg.tag == "Player")
                {
                    if (this.gameObject.tag != otherg.tag || this.gameObject.tag == "Player")
                    {
                        otherg.GetComponent<BodyMechanics>().Damage(CollisionDamage);
                    }
                }
            }
        }
    }
}
