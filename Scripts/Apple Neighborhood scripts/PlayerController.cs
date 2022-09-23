using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject playerObj = null;

    // Pelihahmon nopeus
    [SerializeField] private float speed = 4f;

    // Referenssi pelihahmon fysiikkamoottoriin
    private Rigidbody2D rb;

    // Objekti
    [SerializeField] private GameObject initialMap;

    // Referenssi liikevektoriin
    private Vector2 move;
    private Vector2 mousepos;

    public GameObject initalMap;

    // Vain yksi esiintymä pelihahmosta sallitaan
    public static PlayerController instance;

    // Lippu, joka ilmoittaa voiko pelihahmo liikkua
    public bool canMove;

    // Referenssi animaattoriin
    private Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
            // Onko pelihahmo olemassa
        if (instance == null) 
        {
            //Ei ole. Kiinnitetään pelihahmo
            instance = this;

            //Pelihahmo voi liikkua pelin alussa
            canMove = true;

            // Otetaan pelihahmon fysiikkamoottori käyttöön
            rb = GetComponent<Rigidbody2D>();

            // Asetetaan kameran näkemä aloitus alue. Alue asetetaan metodissa SetBound()
            Camera.main.GetComponent<MainCamera>().SetBound(initialMap);

            // Otetaan  pelihahmon animaattori käyttöön
            anim = GetComponent<Animator>();

        }

        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Animations();
    }

    private void Movements()
    {
        // Otetaan pelihhamon suuntavektori talteen
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void Animations()
    {
        // Voiko pelihahmo liikkua?
        if (canMove && move.magnitude != 0)
        {
            // Kyllä, joten animoidaan liike
            anim.SetFloat("MoveX", move.x);
            anim.SetFloat("MoveY", move.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            // Ei voi, joten pysäytetään liikeqnimaatio
            anim.SetBool("Walking", false);
        }
    }

    private void FixedUpdate()
    {
        if (canMove && move.magnitude != 0)
        {
            rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        }
    }
}


    //public void SavePlayer ()
    //{
       // SaveSystem.SavePlayer(this);
    //}

    //public void LoadPlayer ()
    //{
        //PlayerData data = SaveSystem.LoadPlayer();
        
       // Vector3 position;
       // position.x = data.position[0];
        //position.y = data.position[1];
       // position.z = data.position[2];
       // transform.position = position;
    //}


