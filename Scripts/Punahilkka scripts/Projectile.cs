using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private int damageToGive;

    [SerializeField]
    private int moveSpeed = 5;

    private int timeToWait = 5;

    [SerializeField]
    private GameObject bloodSplash;
    // Start is called before the first frame update
    void Start()
    {
        // Käynnistetään alirutiini, joka tuhoaa ammuksen
        StartCoroutine(DestroyProjectile());
    }

    // Update is called once per frame
    void Update()
    {
        // Liikutetaan ammus X-akselin suuntaisesti nopeudella moveSpeed
        transform.position += transform.right * Time.deltaTime * moveSpeed;

    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(timeToWait); // odotetaan hetki
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //Ääni
            AudioManager.instance.Play("Hurt_Vihollinen");

            // Näytetään veriroiske
            Instantiate(bloodSplash, transform.position, Quaternion.identity);

            // Osuma ääni
            //AudioManager.instance.Play("Hurt_Vihollinen");
            // Kyllä törmättiin, joten aiheutetaan viholliselle vahinkoa
            EnemyHealthManager enemyHealthManager = collision.GetComponent<EnemyHealthManager>();
            if(enemyHealthManager != null)
                enemyHealthManager.HurtEnemy(damageToGive);

        }
    }
}
