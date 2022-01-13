using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: UpgradeSystem, and ShootingMechanics
//Handles Information between the Barrel and the Main Body
//Ups, all Barells' Shooting Mechanics, and Specifically on What to Upgrade Next
//Personalized for every Class
public class ClassMechanics : MonoBehaviour
{
    public GameObject Parent;
    public UpgradeSystem UpS;
    public ShootingMechanics[] SM;
    public GameObject[] nextUpgrades;    
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start() 
    {
        UpS = Parent.GetComponent<UpgradeSystem>(); //sets the barrels to this player
        for (int i = 0; i < SM.Length; i++)
        {
            SM[i].UpS = UpS;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
