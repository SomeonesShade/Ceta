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
    public int level;
    public float eXP;
    private float prevEXP;
    public GameObject ProgressBar;
    private ProgressBar pb;
    // Start is called before the first frame update
    void Awake()
    {
        prevEXP = eXP;
        pb = ProgressBar.GetComponent<ProgressBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (0 < eXP - prevEXP)
        {
            pb.IncrementProgress(eXP - prevEXP);
            prevEXP = eXP;
            level = pb.ReportLevel();
        }
    }
}
