using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Window"))
        {
            WindowHealthManager.instance.HurtEnemy(2);
            NeighborSpawn.instance.Chance();
        } else if (collision.CompareTag("Enemy"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            EnemyHealthManager.instance.HurtEnemy(25);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
}
