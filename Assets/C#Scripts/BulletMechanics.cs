using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public float delayHit;
    public float lifetime;
    public float impactForce;
    public float damage;
    public float pierce;
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
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag != "Wall")
        {
            if (other.tag != "Bullet" && other.tag != "Player" && other.tag != "Barrel")
            {
                if(other.tag == "Hurtable")
                {
                    BM = other.GetComponent<BodyMechanics>();
                    BM.UpS = UpS;
                    BM.Damage(damage);
                }
                rb = other.GetComponent<Rigidbody2D>();
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
