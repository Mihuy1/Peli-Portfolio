using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public AudioClip attackSound;

    public LayerMask enemyLayers;
    public EnemyController enemyController;
    public GameObject enemy;
    public GameObject Sword;
    public Transform player;
    public AudioSource source;

    public float attackRate = 2f;
    public float attackRange = 2f;
    public float distance;

    public int lifeSteal;

    float nextAttackTime = 0f;


     void Start()
    {
        player = GetComponent<Transform>();
        animator = Sword.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
                source.PlayOneShot(attackSound);
                nextAttackTime = Time.time + 1f / attackRate;

                if (distance <= attackRange)
                {
                    nextAttackTime = Time.time + 1f / attackRate;

                }
            }
        }
    }
}
