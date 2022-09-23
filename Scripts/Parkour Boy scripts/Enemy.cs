using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject GameOverPanel;

    public LayerMask whatIsGround;
    public float speed = 1;

    private Rigidbody2D myBody;
    private Transform myTrans;
    private float myWidth;

    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        myTrans = transform;
        myBody = GetComponent<Rigidbody2D>();
        myWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            GameOverPanel.SetActive(true);
            SceneManager.LoadScene(0);
        }
    }
    void FixedUpdate()
    {
        // Vihollinen tarkistaa, onko edessä maata (isGrounded = true), ennen kuin liikkuu eteenpäin
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, whatIsGround);

        // Jos edessä ei ole maata, (isGrounded = false), vihollinen kääntyy ympäri
        if (!isGrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        // Vihollinen menee aina eteenpäin
        Vector2 myVel = myBody.velocity;
        myVel.x = -myTrans.right.x * speed;
        myBody.velocity = myVel;

    }


}