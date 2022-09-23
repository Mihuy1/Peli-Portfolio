using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire2") && Items.instance.applevalue1 >= 5)
        {
            Shoot();
              Items.instance.appleCalculation(5);

        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }


}
