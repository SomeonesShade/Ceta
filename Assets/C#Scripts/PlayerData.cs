using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private BodyMechanics BDM;
    private BulletMechanics BTM;
    private MovementMechanics MM;
    private ShootingMechanics SM;
    
    [Range(0,7)] public int Damage;
    [Range(0,7)] public int Pierce;
    [Range(0,7)] public int Health;
    [Range(0,7)] public int MovementSpeed;
    [Range(0,7)] public int BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        BDM = GetComponent<BodyMechanics>();
        BTM = GetComponent<BulletMechanics>();
        MM = GetComponent<MovementMechanics>();
        SM = GetComponent<ShootingMechanics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
