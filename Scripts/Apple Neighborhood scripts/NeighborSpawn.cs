using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborSpawn : MonoBehaviour
{
    public static NeighborSpawn instance;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject Enemy;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Chance()
    {
        if (Random.value > 0.8)
        {
            Shoot();
        }
    }


    void Shoot()
    {
      
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
    }
}
