using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Related: BulletMechanics, ClassMechanics, DATA, and UpgradeSystem
//Determines how the Player Shoots
//Its has a TON of Variables (Please fix) and use DATA
//Assigns Properties to the bullet, and Determines how the Gun works
public class ShootingMechanics : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public ShootingMechanics tortchReceiver;
    public UpgradeSystem UpS;
    public bool isGiveTortch, hasTortch, isOnHold; //If you have a tortch you can SHOOT
    
    [Header("BulletProperties")]
    public float bulletDelayHit; //some of the other statss
    public float bulletLifetime;
    public float bulletImpactForce;

    [Header("Adjustments")]
    public float damageM;
    public float pierceM;
    public float bulletSpeedM;
    public float reloadM;

    
    float[] Damage;      //list of stats that is used for upgrading
    float[] Pierce;      
    float[] BulletSpeed;
    float[] Reload; 

    int damage, pierce, bulletSpeed, reload;
    
    bool isReadyToFire;
    float timer;
    void Awake() 
    {
        Data_NormalStats DataStats;
        DataStats = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>();
        Damage = DataStats.BulletDamage;
        Pierce = DataStats.Pierce;
        BulletSpeed = DataStats.OnFireForce;
        Reload = DataStats.ShootCooldown;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        isOnHold = false;
    }

    // Update is called once per frame
    void Update()
    {
        StatUpdate();
        FireCheck();
    }
    void FireCheck()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isOnHold = !isOnHold;
        }
        
        if(!isReadyToFire && hasTortch)
        {
            Clock();
        }
        if((Input.GetButton("Fire1") || isOnHold) && isReadyToFire)
        {
            Shoot();
            isReadyToFire = false;
            if(isGiveTortch)
            {
                hasTortch = false;
                tortchReceiver.hasTortch = true;
            }
        }
    }
    void Clock()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = reloadM * Reload[reload];
            isReadyToFire = true;
        }
    }
    void StatUpdate()
    {
        reload = UpS.playerStats.reload;
        damage = UpS.playerStats.damage;
        pierce = UpS.playerStats.pierce;
        bulletSpeed = UpS.playerStats.bulletSpeed;
    } 

    void Shoot()
    {
        GameObject bullet = Instantiate(     //make bullet
            bulletPrefab,
            firePoint.position,
            firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(
            firePoint.right * bulletSpeedM * BulletSpeed[bulletSpeed], //make it move
            ForceMode2D.Impulse
        );
        BulletSetup(bullet);
    }
    void BulletSetup(GameObject bullet)
    {
        BulletMechanics bm = bullet.GetComponent<BulletMechanics>();
        bm.damage = damageM * Damage[damage]; //set everythinggggg
        bm.delayHit = bulletDelayHit;
        bm.pierce = pierceM * Pierce[pierce];
        bm.lifetime = bulletLifetime;
        bm.impactForce = bulletImpactForce;
        bm.UpS = UpS;
        bm.speed = BulletSpeed[bulletSpeed];
    }
}
