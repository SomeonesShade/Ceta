using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    const float smallForce = 0.0001f;
    void BrownianMotion()
    {
        rb.AddForce(new Vector2(Random.Range(-smallForce,smallForce),Random.Range(-smallForce,smallForce)));
    }

    void Rampage()
    {
        
    }
}
