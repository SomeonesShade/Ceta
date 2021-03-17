using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public int damage;
    public float delayHit;
    public int pierce;
    public float lifetime;

    private BodyMechanics BM;
    // Start is called before the first frame update
    void Start()
    {
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
            if(other.tag == "Hurtable")
            {
                BM = other.GetComponent<BodyMechanics>();
                BM.Damage(damage);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
