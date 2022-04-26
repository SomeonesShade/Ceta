using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Related: UpgradeSystem, UI<StatCounter> and SoulSystem
//This is Complicated, it handles how all UI gets Updated when a stat changes
//It controls Every Button to be Active when Available, and Changes the UI on each StatCounter
//Also Changes the Data in UpS Since This Interfaces on How To Upgrade
public class UiUpgradeData : MonoBehaviour
{
    GameObject Player; //theplayer
    bool Enable;
    public GameObject[] Button; //buttons affected
    public GameObject[] ButtonUI;
    public GameObject[] classUpgrades;
    public ClassDisplay CD;
    UpgradeSystem UpS;
    public int localPoints, localClassPoints;
    bool prevEnb, currentlyDisplaying;
    public Color[] actiColors;
    public Color deactiColor;
    int prevPoints;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        UpS = Player.GetComponent<UpgradeSystem>();
        Enable = false;
        prevEnb = true;
        prevPoints = localPoints;
        Check();
        currentlyDisplaying = false;
        CD.UUD =  this.gameObject.GetComponent<UiUpgradeData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null) //hey im not dead
        {
            localPoints += UpS.Transmit();
            localClassPoints += UpS.ClassTransmit();
            classUpgrades = UpS.nextClassUpgrades;
        }
        if (prevPoints != localPoints) //if there is a change
        {
            Check();
            prevPoints = localPoints;
        }
        if (localClassPoints > 0)
        {
            if (!currentlyDisplaying)
            {
                DisplayClass();
                Debug.Log("Sending Display, ShouldDisplay is: " + currentlyDisplaying);
            }
        }
    }
    public void Stat(int type)
    {
        if (Player != null && localPoints != 0)
        {
            if(UpS.playerStats.IntToStatRead(type) < UpS.playerStats.maxCapacity)
            {
                UpS.playerStats.AddValue(type, 1);
                UiUpdater(type, UpS.playerStats.IntToStatRead(type));
                localPoints -= 1;
            }
        }
        Check();
    }
    public void UiUpdater(int type, int size)
    {//first which upgardetype, and the updater updates
        ButtonUI[type].GetComponent<StatCounter>().Updater(size);
    }
    void Check()//Note change this to change the Saturation Instead
    {
        if (localPoints <= 0) //we ran out of point?
        {
            Enable = false;
        }
        else
        {
            Enable = true;
        }
        if (prevEnb != Enable || Enable == true) //there was a recent change?
        {
            for (int i = 0; i < Button.Length; i++)
            {
                if(UpS.playerStats.IntToStatRead(i) >= UpS.playerStats.maxCapacity)
                {
                    Button[i].GetComponent<Button>().enabled = false;
                    Button[i].GetComponent<Image>().color = deactiColor;
                }
                else
                {
                    Button[i].GetComponent<Button>().enabled = Enable;
                    Button[i].GetComponent<Image>().color = Enable? actiColors[i] : deactiColor;
                }
            }
        }
        prevEnb = Enable;
        
    }
    void DisplayClass()
    {
        currentlyDisplaying = true;
        CD.DisplayNow(classUpgrades);
    }
    public void ChangeClass(int classNumber)
    {
        Debug.Log("Change Class");
        UpS.ClassUpdate(classUpgrades[classNumber]);
        localClassPoints--;
        currentlyDisplaying = false;
    }
    public void Reset(GameObject player) //soulstuff reseting
    {
        Player = player;
        UpS = Player.GetComponent<UpgradeSystem>();
        localPoints = 0;
        int a = 0;
        foreach (var item in ButtonUI)
        {
            UiUpdater(a,0);
            a++;
        }
        Check();
    }

}
