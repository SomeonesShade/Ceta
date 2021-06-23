using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    //Unused ATM, maybe later after dealing with the exp 
    public float[] Damage;
    public float[] Pierce;
    public float[] Health;
    public float[] MovementSpeed;
    public float[] BulletSpeed;
    public int[] AddPoint;

    public int damage;
    public int pierce;
    public int health;
    public int movementSpeed;
    public int bulletSpeed;
    
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
        prevEXP = eXP;
        prevLevel = level;
        
    }
    void Start()
    {
        pb = ProgressBar.GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    public int Transmit()
    {
        transmit = UpgradePoints;
        UpgradePoints = 0;
        return transmit;
    }
    void Update()
    {
        if (eXP > prevEXP)
        {
            pb.IncrementProgress(eXP - prevEXP);
            prevEXP = eXP;
            level = pb.ReportLevel();
            Point();
        }
    }
    void Point()
    {
        for (int i = prevLevel; i < level; i++)
        {
            UpgradePoints += AddPoint[i];
        }
        prevLevel = level;
    }
    public int UpgradeStats(int type)
    {
        switch (type)
        {
            case 1:
                damage++;
            return damage;
            case 2:
                pierce++;
            return pierce;
            case 3:
                health++;
            return health;
            case 4:
                movementSpeed++;
            return movementSpeed;
            case 5:
                bulletSpeed++;
            return bulletSpeed;
            default:
                Debug.Log("ERROR");
            break;
        }
        return 0;
    } 
}
