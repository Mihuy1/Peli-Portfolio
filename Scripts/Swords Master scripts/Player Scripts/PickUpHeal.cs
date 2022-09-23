using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHeal : MonoBehaviour
{
    public PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        playerController.currentHealth += GameManager.Instance.healAmount;
        playerController.healthbar.SetHealth(playerController.currentHealth);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
