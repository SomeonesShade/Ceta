using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanics : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public UpgradeSystem UpS;
    //absolutehell
    [Header("Variables")]
    public float bulletForce;
    public float delay;
    [Header("BulletProperties")]
    public float bulletDelayHit;
    public float bulletLifetime;
    public float bulletImpactForce;
    public float bulletDamage;
    public float bulletPierce;
    [Header("Upgrades")]
    public float[] Damage;
    public float[] Pierce;
    public float[] BulletSpeed;

    private int damage;
    private int pierce;
    private int bulletSpeed;
    
    private bool wait;
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
        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(
            firePoint.right * bulletForce,
            ForceMode2D.Impulse
        );
        BulletMechanics bm = bullet.GetComponent<BulletMechanics>();
        bm.damage = Damage[damage];
        bm.delayHit = bulletDelayHit;
        bm.pierce = Pierce[pierce];
        bm.lifetime = bulletLifetime;
        bm.impactForce = bulletImpactForce;
        bm.UpS = UpS;
    }
    IEnumerator Delay(float dy)
    {
        Shoot();
        wait = true;
        yield return new WaitForSeconds(dy);
        wait = false;
    }
}
