using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }

    public PlayerCombat playerCombat;

    public GameObject shopMenu;

    public GameObject crosshair;

    private bool _shopToggled;

    private void Start()
    {
        _shopToggled = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TurnOffShop();
            crosshair.SetActive(true);
        }

        if (_shopToggled == true)
        {
            playerCombat.source.Pause();
        }
    }

    public void TurnOnShop()
    {
        shopMenu.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void TurnOffShop()
    {
        shopMenu.SetActive(false);

        Time.timeScale = 1;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerCombat.source.Play();
        _shopToggled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _shopToggled = true;
            TurnOnShop();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _shopToggled = false;
            TurnOffShop();
        }
    }
}
