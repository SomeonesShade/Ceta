using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanics : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(
            movement.x*speedMultiplier,
            movement.y*speedMultiplier);
    }
}
