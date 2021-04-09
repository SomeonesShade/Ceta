using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMechanics : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public float speedMultiplier;
    public float timeToAccelerate;
    private Vector2 currentMultiplier;
    private Vector2 prevMovement;
    private float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prevMovement = movement;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        acceleration = speedMultiplier/timeToAccelerate * Time.deltaTime;
        currentMultiplier += new Vector2 (acceleration,acceleration);
        Check();
        prevMovement = movement;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentMultiplier * Time.fixedDeltaTime);
    }
    void Check()
    {
        if(currentMultiplier.x > speedMultiplier)
        {
            currentMultiplier.x = speedMultiplier;
        }
        if(currentMultiplier.y > speedMultiplier)
        {
            currentMultiplier.y = speedMultiplier;
        }
        if (movement.x != prevMovement.x)
        {
            currentMultiplier.x = 0f;
        }
        if (movement.y != prevMovement.y)
        {
            currentMultiplier.y = 0f;
        }
    }
}
