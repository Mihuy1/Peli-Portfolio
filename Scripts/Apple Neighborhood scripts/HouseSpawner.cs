using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public static HouseSpawner instance;
    public Transform firePoint;
    public GameObject bulletPrefab;

    void Start()
    {
        instance = this;
        Shoot();
    }

    // Update is called once per frame
    public void Chance()
    {
            Shoot();
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    }
}
