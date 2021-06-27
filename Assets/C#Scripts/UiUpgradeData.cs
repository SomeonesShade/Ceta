﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiUpgradeData : MonoBehaviour
{
    public GameObject Player; //theplayer
    private bool Enable;
    public GameObject[] Button; //buttons affected
    public GameObject[] ButtonUI;
    private UpgradeSystem UpS;
    public int localPoints;
    private bool prevEnb;
    public Color actiColor;
    public Color deactiColor;
    private Color useColor;
    private int prevPoints;
    // Start is called before the first frame update
    void Start()
    {
        UpS = Player.GetComponent<UpgradeSystem>();
        Enable = false;
        prevEnb = true;
        useColor = deactiColor;
        prevPoints = localPoints;
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) //hey im not dead
        {
            localPoints += UpS.Transmit();
        }
        if (prevPoints != localPoints) //if there is a change
        {
            Check();
            prevPoints = localPoints;
        }
    }
    public void Damage()
    {
        if (Player != null && localPoints != 0)
        {
            UiUpdater(0, UpS.UpgradeStats(1));
            localPoints -= 1;
        }
        Check();
    }
    public void UiUpdater(int type, int size)
    {//first which upgardetype, and the updater updates
        ButtonUI[type].GetComponent<StatCounter>().Updater(size);
    }
    void Check()
    {
        if (localPoints <= 0) //we ran out of point?
        {
            Enable = false;
        }
        else
        {
            Enable = true;
        }
        if (Enable) //we are activated?
        {
            useColor = actiColor;
        }
        else
        {
            useColor = deactiColor;
        }
        if (prevEnb != Enable) //there was a recent change?
        {
            for (int i = 0; i < Button.Length; i++)
            {
                Button[i].GetComponent<Button>().enabled = Enable;
                Button[i].GetComponent<Image>().color = useColor;
            }
        }
        prevEnb = Enable;
        
    }
    public void Reset(GameObject player) //soulstuff reseting
    {
        Player = player;
        UpS = Player.GetComponent<UpgradeSystem>();
        localPoints = 0;
    }

}