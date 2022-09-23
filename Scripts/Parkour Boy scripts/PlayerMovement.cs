using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Tehdään pelihahmosta singeltron

    public static PlayerMovement instance;
    //Liikemuuttajat
    [SerializeField] private float moveSpeed; // pelihahmon nopeus x-akselin suunnassa 
    [SerializeField] private float jumpForce; // pelihahmon hyppynopeus

    // Näppäinmuuttajat
    public KeyCode left;  // liikuttaa pelihahmon vasemmalle
    public KeyCode right; // oikealle
    public KeyCode jump;  // hypyttää pelihahmon

    // Efekti
    //public ParticleSystem footsteps;
    //private ParticleSystem.EmissionModule footEmission;

    // Referenssi fysiikkamoottoriin
    private Rigidbody2D rb2d;

    // Referenssi piirtokomponenttiin
    private SpriteRenderer spriteRenderer;

    // Referenssi Animaattoriin
    //private Animator anim;
    public Animator MyAnim { get; set; }

    // voiko pelihahmo liikkua?
    public bool MyCanMove { get; set; }


    // Parempi hyppy
    private float fallMultiplier = 4f; // Mitä suurempi arvo sitä nopeammin tullaan alas
    private float lowJumpMultiplier = 2f; // Mitä suurempi arvo, sitä suurempi hyppy

    // Hyppyyn liittyvät muuttujat
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        // Luodaan yhteys dust-efektin partikkelisysteemiin
        //footEmission = footsteps.emission;
        // Otetaan Singelton käyttöön
        instance = this;
        // Luodaan yhteys pelihahmon fysiikkamoottoriin
        rb2d = GetComponent<Rigidbody2D>();

        // Luodaan yhteys piirtokomponenttiin
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Luodaan yhteys animaattoriin
        //anim = GetComponent<Animator>();
        MyAnim = GetComponent<Animator>();

        // Pelihahmo voi liikkua oletuksena
        MyCanMove = true;


    }

    // Update is called once per frame
    void Update()
    {
        // Voiko Pelihahmo liikkua?
        if (MyCanMove == false)
        {
            // Ei voi eli mennään updatesta pois.
            rb2d.velocity = Vector2.zero;
            return;
        }
        // Tutkitaan onko poika maassa vai ilmassa
        // Ilmassa silloin kun isGround on = false ja maassa on isGround = true
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        // Liikutetaan pelihahmoa
        MovePlayer();
        // Käsittele animaatiot
        HandleAnimation();
    }
    // Käsittelee pojan animaatiot
    private void HandleAnimation()
    {
        // Juoksu animaation kutsu
        MyAnim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); // Mathf.Abs() tarkistaa, että nopeus(x) on aina positiivinen
        // Hyppy animaation kutsu
        MyAnim.SetBool("Grounded", isGround);
    }

    private void MovePlayer()
    {

        // Liikkuuko pelhihahmo vasemmalle?
        if (Input.GetKey(left))
        {

            // Kyllä joten suoritetaan liike
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);

            // Varmistetaan, että pelihahmo katsoo menosuuntaan
            spriteRenderer.flipX = true;

            // Dust efekti päälle
            //footEmission.rateOverTime = 35f;
        }
        // Liikutaanko pelihahmo oikealle?
        else if (Input.GetKey(right))
        {
            // Kyllä, joten suoritetaan liike
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            // Varmistetaan, että pelihahmo katsoo menosuuntaan
            spriteRenderer.flipX = false;

            // Dust-efekti päälle
            //footEmission.rateOverTime = 35f;
        }
        else
        {
            //footEmission.rateOverTime = 0f;
            // Onko vielä ilmassa?
            if (rb2d.velocity.y != 0)
            {
                // Kyllä, joten liike jatkuu
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);

            }
            else
            {
                // Ei, joten liike päättyy
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);

                // Dust-efekti pois päältä
                //footEmission.rateOverTime = 0f;
            }
        }
        // Painettiinko hyppynappiketta?
        if (Input.GetKeyDown(jump) && isGround)
        {
            // Hyppyääni
            AudioManager.instance.Play("Jump");
            // Kyllä, joten pelihahmo hyppää
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

        }

        BetterJump();
    }

    private void BetterJump()
    {
        // Ollaanko tulossa alaspäin
        if (rb2d.velocity.y < 0)
        {
            // näppäintä painetaan --> korkeampi hyppy
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            // dust-efekti pois
            //footEmission.rateOverTime = 0f;
        }
        // Ollaanko ilmassa ja hyppypainiketta ei paineta?
        else if (rb2d.velocity.y > 0 && !Input.GetKey(jump))
        {
            // Kyllä, joten --> matalempi hyppy
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            // Dust-efekti pois
            //footEmission.rateOverTime = 0f;
        }
    }
}


