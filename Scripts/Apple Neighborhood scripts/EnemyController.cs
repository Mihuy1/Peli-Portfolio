using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public enum EnemyState
    {
        idle,
        walk,
        attack,
        run
    }

    //Muuttujat
    [SerializeField]
    private EnemyState currentState;
    public float movespeed;
    private Rigidbody2D myRigiBody;
    public Transform target;
    public float ChaseRadius;
    public float AttackRadius;
    public Animator anim;
    [SerializeField]
    private int damageToGive;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;

        myRigiBody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
         Vector3 forward = transform.TransformDirection(target.transform.position - transform.position);
         Debug.DrawRay(transform.position, forward, Color.red);

         CheckDistance();


    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // Onko hahmo havaintoalueella?
        if (distance <= ChaseRadius && distance > AttackRadius)
        {
            // Kyllä on, tarkistetaan onko vihollinen idle.
            if (currentState == EnemyState.idle || currentState == EnemyState.run)
            {
                // Liikutetaan vihollista hahmoa päin
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position,
                    movespeed * Time.deltaTime);

                changeAnim(temp - transform.position);

                myRigiBody.MovePosition(temp);

                // Vaihdetaan vihollisen tila kävelyyn
                ChangeState(EnemyState.run);

                 anim.SetBool("Running", true);

            }

        }
        // Ollaan keltaisen viivan ulkopuolella
        else if (distance > ChaseRadius)
        {

            anim.SetBool("Running", false);

            ChangeState(EnemyState.idle);
        }
        // Punaisen viivan sisällä
        else if (distance < AttackRadius)
        {
            PlayerHealthManager.instance.HurtPlayer(1);
        }
    }
    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        // Onko pelihahmo vihollisen vasemmalla puolella
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Onko pelihahmo oikealla puolella
            if (direction.x > 0)
            {
                //print("Oikealla");
                // Suoreitetaan oiealle menevä animaatio
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                //print("Vasemmalla");
                // Suoritetaan vasemmalle menevä animaatio
                SetAnimFloat(Vector2.left);
            }
        }
        // Onko vihollinen pelihahmon ylä/ala puolella?
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Onko pelihahmo yläpuolella
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }

            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
