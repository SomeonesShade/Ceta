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
    public UpgradeSystem UpS;
    //absolutehell
    [Header("Variables")]
    public float bulletForce;  //stronger gun and reload time essentially
    public float delay;
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

    int damage; //local stats to import to the bullet
    int pierce;
    int bulletSpeed;
    
    private bool wait;
    void Awake() 
    {
        Data_NormalStats DataStats;
        DataStats = GameObject.FindGameObjectWithTag("DATA").GetComponent<Data_NormalStats>();
        Damage = DataStats.Damage;
        Pierce = DataStats.Pierce;
        BulletSpeed = DataStats.BulletSpeed;
        Reload = DataStats.Reload;
    }
    // Start is called before the first frame update
    void Start()
    {
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && wait == false)
        {
            StartCoroutine(Delay(delay));
        }
        StatUpdate();
    }
    void StatUpdate()
    {
        damage = UpS.damage;
        pierce = UpS.pierce;
        bulletSpeed = UpS.bulletSpeed;
    } 

    void Shoot()
    {
        GameObject bullet = Instantiate(     //make bullet
            bulletPrefab,
            firePoint.position,
            firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(
            firePoint.right * bulletForce, //make it move
            ForceMode2D.Impulse
        );
        BulletMechanics bm = bullet.GetComponent<BulletMechanics>();
        bm.damage = Damage[damage]; //set everythinggggg
        bm.delayHit = bulletDelayHit;
        bm.pierce = Pierce[pierce];
        bm.lifetime = bulletLifetime;
        bm.impactForce = bulletImpactForce;
        bm.UpS = UpS;
    }
    IEnumerator Delay(float dy)
    {
        Shoot(); //reload time lel
        wait = true;
        yield return new WaitForSeconds(dy);
        wait = false;
    }
}
