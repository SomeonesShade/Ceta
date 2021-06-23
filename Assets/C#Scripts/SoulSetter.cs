﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSetter : MonoBehaviour
{
    public GameObject Ghost;
    
    private Transform Player;
    private Transform gTM;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Transform>();
        gTM = Ghost.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gTM.position = Player.position;
    }
    void OnDestroy()
    {
        if(Ghost != null)
        {
            Ghost.GetComponent<SoulSystem>().isDestroyed = true;
        }
    }
}
