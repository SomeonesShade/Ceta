using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private BodyMechanics BDM;
    private BulletMechanics BTM;
    private MovementMechanics MM;
    private ShootingMechanics SM;
    
    public int Health;
    public float MovementSpeed;
    public int Pierce;
    public int Damage;
    public float BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        BDM = GetComponent<BodyMechanics>();
        MM = GetComponent<MovementMechanics>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Health = BDM.health;
        MovementSpeed = MM.speedMultiplier;
    }
}
