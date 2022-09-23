using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyState
{
    idle,
    walk,
    run,
    attack
}
public class EnemyController : MonoBehaviour
{

    // Muuttujat
    [SerializeField]
    private EnemyState currentState;
    public float moveSpeed;
    private Rigidbody2D myRigibody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    [SerializeField]
    private int damageToGive;
    [SerializeField]
    private GameObject projectile2Prefabs;

    // Kuinka usein ammutaan
    float nextFire;
    float fireRate = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Vihollisen tila pelin alussa on idle
        currentState = EnemyState.idle;

        // Referenssi fysiikkamoottoriin
        myRigibody = GetComponent<Rigidbody2D>();

        // Referenssi animaattoriin
        anim = GetComponent<Animator>();

        // Hy�kk�yksen kohde
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // TransformDirection laskee ensin suunnan, jossa kohde on
        // ja piirt�� sitten punaisen viivan vihollisesta kohteeseen (vain Sceness�)
        Vector3 forward = transform.TransformDirection(target.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        // Tarkistetaan onko punahilkka tullut liian l�helle vihollista
        CheckDistance();
    }

    private void CheckDistance()
    {
        // Lasketaan et�isyys vihollisen ja pelihahmon v�lill�
        float distance = Vector3.Distance(target.position, transform.position);

        // Onko punahilkka havaintoalueella?
        if (distance <= chaseRadius && distance > attackRadius)
        {
            // Kyll� on. Tarkistetaan onko vihollisen tila idle?
            if (currentState == EnemyState.idle || currentState == EnemyState.run)
            {
                // Kyll� on, joten liikutaan vihollisen kohti pelihahmoa
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigibody.MovePosition(temp);

                // Vaihda vihollisen tila juoksuun
                ChangeState(EnemyState.run);

                // Animoidaan liike eli kutsutaan Blend Tree tilaa
                anim.SetBool("Running", true);
            }
        }

        // Onko punahilkka havaintoalueen ulkopuolella
        else if (distance > chaseRadius)
        {

            // kutsutaan WakeUp tiala
            anim.SetBool("Running", false);
            // Nykyinen tila vaihdetaan idle
            ChangeState(EnemyState.idle);
        }

        // Onko punahilkka hy�kk�ysalueella?
        else if (distance < attackRadius)
        {

            // Voidaanko jo ampua?
            if (Time.deltaTime > nextFire)
            {
                // Kyll� voidaan, lasketaan seuraava laukaisu hetki
                nextFire = Time.time + fireRate;

                // Laukaistaan ammoa
                Shoot();

                // Kyll� on, joten vihollinen hy�kk�� ja aiheuttaa vahinkoa
                PlayerHealthManager.instance.HurtPlayer(damageToGive);
            }

        }
    } 

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("MoveX", setVector.x);
        anim.SetFloat("MoveY", setVector.y);
    }

    private void changeAnim(Vector2 direction)
    {
        // Onko pelihahmo vihollisen vasemmalla tai oikealla puolella?
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Onko pelihahmo oikealla puolella
            if (direction.x > 0)
            {
                print("Oikealla");
                // Suoritetaan oikealle menev� animaatio (1,0)
                SetAnimFloat(Vector2.right);
            }

            // Onko pelihahmo vasemmalla puolella?
            else if (direction.y > 0)
            {
                print("Vasemmalla");
                // Suoritetaan vasemmalle menev� animaatio (-1,0)
                SetAnimFloat(Vector2.left);
            }
        }
        // Onko pelihahmo vihollisen ala tai yl� puolella?
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Onko pelihahmo yl�puolella?
            if (direction.y > 0)
            {
                // Suoritetaan yl�s menev� animaatio (0,1)
                SetAnimFloat(Vector2.up);
            }
            // Onko pelihahmo alapuoella
            else if (direction.y < 0)
            {
                // Suoritetaan alas menev� animaatio (0,-1)
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
        Gizmos.DrawWireSphere(transform.position, chaseRadius); // Havaintoalue

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius); // Hy�kk�ysalue
    }

    void Shoot()
    {
        AudioManager.instance.Play("Ampuu_Vihollinen");
        Instantiate(projectile2Prefabs, transform.position, transform.rotation);
    }

}
