using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour
{

    public float speed;

    public GameObject player;
    private Rigidbody2D rb2d;

    public Vector3 target, dir;

    [SerializeField]
    private int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Otetaan yhteys ammuksen fysiikkamoottoriin
        rb2d = GetComponent<Rigidbody2D>();

        // Onko pelihahmo olemassa
        if (player != null)
        {
            // Kyllä on, joten otetaan pelihahmon sijainti talteen
            target = player.transform.position;
            // Lasketaan kohteen (tässä pelihahmo) ja ammuksen välinen normalisoitu suuntavektori
            dir = (target - transform.position).normalized;
        }
    }

    private void FixedUpdate()
    {
        // Onko kohde olemassa
        if (target != Vector3.zero)
        {
            // Kyllä on, joten laukaistaan ammus (liikuttaa ammuksen rigibodya)
            rb2d.MovePosition(transform.position + dir * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Törmäsikö ammus pelihahmoon tai toiseen ammukseen?

        if (collision.CompareTag("Player"))
        {
            // Kyllä törmättiin, joten aiheutetaan vahinkoa pelihahmolle
            PlayerHealthManager playerHealthManager = collision.GetComponent<PlayerHealthManager>();
            if (playerHealthManager != null)
                playerHealthManager.HurtPlayer(damageToGive);

            // Kyllä tuhotaan ammus
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
