using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: ShootingMechanics, ClassMechanics, ClassChange, BodyMechanics, BulletMechanics, SoulSystem, and UI<UiUpgradeData, ProgressBar>
//The Most Refrenced Class, Handle with Care
//Handles ALL stat and level data to be used in a lot of Aspects 
public class UpgradeSystem : MonoBehaviour
{
    //Unused ATM, maybe later after dealing with the exp 
    public int[] AddPoint;
    public int[] AddClassPoint;
    public float[] expToLevelUp;
    public PlayerStats playerStats; 
    public int level, upgradePoints, classPoints;
    public float eXP;
    public GameObject ProgressBar;
    public GameObject[] nextClassUpgrades;
    ProgressBar pb;
    int prevLevel, transmit;
    float prevEXP, remainingEXP;
    // Start is called before the first frame update
    void Awake()
    {
        ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar");
        pb = ProgressBar.GetComponent<ProgressBar>();
        prevEXP = eXP;
        prevLevel = level;
    }
    void Start()
    {

    }

    //send the points to the uiupgradedata class
    public int Transmit()
    {
        transmit = upgradePoints;
        upgradePoints = 0;
        return transmit;
    }
    public int ClassTransmit()
    {
        transmit = classPoints;
        classPoints = 0;
        return transmit;
    }
    public void ClassUpdate(GameObject g)
    {
        this.gameObject.GetComponent<ClassChange>().ChangeClass(g);
    }
    void Update()
    {
        if (eXP > prevEXP) //dont worry this is calculated as total exp
        {
            IncrementProgress(eXP - prevEXP);
            prevEXP = eXP;
            Point();
        }
    }
    void Point() //Level to Points, if the exp has increased
    {
        for (int i = prevLevel; i < level; i++)
        {
            upgradePoints += AddPoint[i]; //loop for every new level gained..
            classPoints += AddClassPoint[i];
        }
        prevLevel = level; //reset
    }
    public void IncrementProgress(float newExp)
    {
        //calculate the exp needed to level up (positive means we do)
        remainingEXP += newExp;
        //are above the required exp to levelup?
        for(int a = 0; remainingEXP >= expToLevelUp[level] && a < 1000; a++)
        {//sweet! time to level up
            level += 1;
        }
        pb.ReportVariables(remainingEXP, expToLevelUp[level], level); //calculate target
    }
}
