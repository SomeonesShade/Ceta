using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: ShootingMechanics, UpgradeSystem, and BodyMechanics
//Dictates Bullet Behavior and Properties
//ShootingMechanics Instantiates the Bullet and there is no local assign
//Assigns which Ups for the affected Body Mechanics to give EXP
public class BulletMechanics : MonoBehaviour
{
    public float delayHit, lifetime, impactForce, damage, pierce, speed;
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
    void OnTriggerEnter2D(Collider2D other) 
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

    Vector2 mouseLocation, relPos;
    float angle;
    const float radiusOfRest = 0.5f, acceleration = 1.1f;
    void Homing()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);//locate the mouse
        relPos = mouseLocation - new Vector2(tr.position.x, tr.position.y); //relative distance from the mousetoplayer
        angle = Mathf.Atan2(relPos.y, relPos.x) * Mathf.Rad2Deg;            //no idea, just converts the vector into an angle
        tr.rotation = Quaternion.Euler(0,0,angle);                          //then converts it into a quaternion and sets the rotation!
        if(relPos.magnitude > radiusOfRest)
        {
            if(rb.velocity.magnitude < speed)
            {
                rb.velocity *= acceleration;
            }
            if(rb.velocity.magnitude >= speed)
            {
                rb.velocity = tr.right * speed;
            }
        }
    }
}
