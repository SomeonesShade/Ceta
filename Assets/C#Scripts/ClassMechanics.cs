using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMechanics : MonoBehaviour
{
    public GameObject Parent;
    public UpgradeSystem UpS;
    public ShootingMechanics[] SM;    
    // Start is called before the first frame update
    void Awake()
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
