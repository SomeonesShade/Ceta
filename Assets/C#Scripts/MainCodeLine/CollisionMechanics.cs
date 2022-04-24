using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMechanics : MonoBehaviour
{
    float colDmg;
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        CollideCheck(other);
    }
    void OnCollisionStay2D(Collision2D other) 
    {
        CollideCheck(other);
    }
    void CollideCheck(Collision2D other)
    {
        GameObject otherg = other.gameObject;
        if (otherg.tag != "Wall")
        {
            if (otherg.tag != "Bullet" && otherg.tag != "Barrel")
            {//if its a squishy
                if(otherg.tag == "Hurtable" || otherg.tag == "Player")
                {
                    if (this.gameObject.tag != otherg.tag || this.gameObject.tag == "Player")
                    {
                        otherg.GetComponent<BodyMechanics>().DamageCall(colDmg);
                    }
                }
            }
        }
    }
}
