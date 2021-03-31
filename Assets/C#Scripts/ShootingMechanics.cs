﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanics : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce;
    public float delay;
    
    public int bulletDamage;
    public float bulletDelayHit;
    public int bulletPierce;
    public float bulletLifetime;
    
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
            ForceMode2D.Impulse);
        BulletMechanics bm = bullet.GetComponent<BulletMechanics>();
        bm.damage = bulletDamage;
        bm.delayHit = bulletDelayHit;
        bm.pierce = bulletPierce;
        bm.lifetime = bulletLifetime;
    }
    IEnumerator Delay(float dy)
    {
        Shoot();
        wait = true;
        yield return new WaitForSeconds(dy);
        wait = false;
        
    }
}
