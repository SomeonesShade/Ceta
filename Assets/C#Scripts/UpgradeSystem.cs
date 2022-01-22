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
    public int healthRegeneration,
        maxHealth,
        bodyDamage,
        bulletSpeed,
        pierce,
        damage,
        reload,
        movementSpeed;
    
    public int level;
    public int UpgradePoints;
    public float eXP;
    private float prevEXP;
    public GameObject ProgressBar;
    private ProgressBar pb;
    private int prevLevel;
    private int transmit;
    // Start is called before the first frame update
    void Awake()
    {
        ProgressBar = GameObject.FindGameObjectWithTag("ProgressBar");
        prevEXP = eXP;
        prevLevel = level;
    }
    void Start()
    {
        pb = ProgressBar.GetComponent<ProgressBar>();
    }

    //send the points to the uiupgradedata class
    public int Transmit()
    {
        transmit = UpgradePoints;
        UpgradePoints = 0;
        return transmit;
    }
    void Update()
    {
        if (eXP > prevEXP) //dont worry this is calculated as total exp
        {
            pb.IncrementProgress(eXP - prevEXP);
            prevEXP = eXP;
            level = pb.ReportLevel();
            Point();
        }
    }
    void Point() //Level to Points, if the exp has increased
    {
        for (int i = prevLevel; i < level; i++)
        {
            UpgradePoints += AddPoint[i]; //loop for every new level gained..
        }
        prevLevel = level; //reset
    }
    public int UpgradeStats(int type)
    {//sets the local points we have
        switch (type)
        {
            case 0:
                healthRegeneration++;
            return healthRegeneration;
            case 1:
                maxHealth++;
            return maxHealth;
            case 2:
                bodyDamage++;
            return bodyDamage;
            case 3:
                bulletSpeed++;
            return bulletSpeed;
            case 4:
                pierce++;
            return pierce;
            case 5:
                damage++;
            return damage;
            case 6:
                reload++;
            return reload;
            case 7:
                movementSpeed++;
            return movementSpeed;
            default:
                Debug.Log("ERROR");
            break;
        }
        return 0;
    } 
}
