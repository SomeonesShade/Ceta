using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: ShootingMechanics, UpgradeSystem, and BodyMechanics
//Dictates Bullet Behavior and Properties
//ShootingMechanics Instantiates the Bullet and there is no local assign
//Assigns which Ups for the affected Body Mechanics to give EXP
public class BulletMechanics : MonoBehaviour
{
    public float delayHit, lifetime, impactForce, damage, pierce;
    public UpgradeSystem UpS;

    private BodyMechanics BM;
    private Rigidbody2D rb;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (pierce <= 0) //cant go through anymore?
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag != "Wall")
        {//basically (our)bullet, player, and the barrel
            if (other.tag != "Bullet" && other.tag != "Player" && other.tag != "Barrel")
            {//if its a squishy
                pierce--;
                if(other.tag == "Hurtable")
                {
                    BM = other.GetComponent<BodyMechanics>(); //get that
                    BM.UpS = UpS;                             //set ther ups to the player to give exp
                    BM.Damage(damage);                        //deal damage
                }
                rb = other.GetComponent<Rigidbody2D>();       //to enact push lel
                Push(rb);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Push(Rigidbody2D Rb)
    {
        Rb.AddForce(
            tr.right * impactForce,
            ForceMode2D.Impulse);
    }
}
