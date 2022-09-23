using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    EnemyController enemyController;

    public Vector3 moveDirection;

    public const float maxDashTime = 6.0f;
    public float dashDistance = 10;
    public bool dash;

    float currentDashTime;
    float dashSpeed = 6;

    public CharacterController controller;


     void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !dash)
        {
            moveDirection = transform.forward * dashDistance;
            controller.Move(moveDirection * Time.deltaTime * dashSpeed);
            currentDashTime = 0;
            dash = true;
        }

    }
    void FixedUpdate()
    {
        if (currentDashTime < maxDashTime && dash)
        {
            currentDashTime += Time.deltaTime;
        }
        else
        {
            moveDirection = Vector3.zero;
            dash = false;
        }
    }
}

