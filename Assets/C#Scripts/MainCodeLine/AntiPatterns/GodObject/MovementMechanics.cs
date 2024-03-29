﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: Self Contained
//Handles How the PlayerMoves At All w/ Accel, Speed, Inertia etc.
//This Should Not be SelfContained, we Need the UPS and DATA for how to change Speed
public class MovementMechanics : MonoBehaviour
{
    public SO_Data_ClassStatUpdater Stats;
    Rigidbody2D rb;
    Vector2 movement;
    public float speedMultiplier;
    public float timeToAccelerate;
    public float[] MovementSpeed;
    SO_Data_NormalStats CurrentStats;
    UpgradeSystem UpS;
    int movementspeed;
    Vector2 currentMultiplier;
    Vector2 prevMovement;
    float acceleration;
    // Start is called before the first frame update
    void Awake()
    {
        CurrentStats = Stats.ClassStats[Stats.currentClass];
        MovementSpeed = CurrentStats.MovementSpeed;
        UpS = GetComponent<UpgradeSystem>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        prevMovement = movement;
    }
    void StatUpdate()
    {
        movementspeed = UpS.playerStats.movementSpeed;
        speedMultiplier = MovementSpeed[movementspeed];
    }
    void Update()
    {
        StatUpdate();
        movement.x = Input.GetAxisRaw("Horizontal");    //get the inputs
        movement.y = Input.GetAxisRaw("Vertical");
        acceleration = speedMultiplier/timeToAccelerate * Time.deltaTime;   //accel to maxspeed
        currentMultiplier += new Vector2 (acceleration,acceleration); //add the accel to the multiplier
        Check();
        prevMovement = movement;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentMultiplier * Time.fixedDeltaTime);//then we movin
    }
    void Check()
    {
        if(currentMultiplier.x > speedMultiplier)   //if the multiplier is above maxspeed
        {
            currentMultiplier.x = speedMultiplier;
        }
        if(currentMultiplier.y > speedMultiplier)
        {
            currentMultiplier.y = speedMultiplier;
        }
        //i should not slow it down immediately, maybe *= 0.1f, or -= 1 idk;
        if (movement.x != prevMovement.x) //did we change direction?
        {
            currentMultiplier.x = 0f; //if so STOP lel
        }
        if (movement.y != prevMovement.y)
        {
            currentMultiplier.y = 0f;
        }
    }
}
