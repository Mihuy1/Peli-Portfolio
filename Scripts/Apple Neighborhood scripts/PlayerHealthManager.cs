using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

    //Singleton
    public static PlayerHealthManager instance;

    public string charName;


    public float currentHP = 0;
    [SerializeField]
    private float maxHP = 100;

    //Sliderit
    public Image playerHealthbar;
    public Text HPtext;
    public float lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            HurtPlayer(5);
        }
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus()
    {
        if (currentHP != playerHealthbar.fillAmount)
        {
            // Kyll‰ on joten p‰ivitet‰‰n tila palkki
            playerHealthbar.fillAmount = Mathf.Lerp(playerHealthbar.fillAmount,
                currentHP / maxHP, Time.deltaTime * lerpSpeed);
            // P‰ivitet‰‰n terveyspisteet
            HPtext.text = "HP: " + Mathf.Round(playerHealthbar.fillAmount * 100) + " / " + maxHP;
        }
    }

    public void HurtPlayer(int damageToGive) 
    {
        currentHP -= damageToGive;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    private void Die()
    {
        print("Kuolit!");
        Destroy(gameObject, 0.5f);
        DeathScreen.instance.Pause();
        //SceneManager.LoadScene("MainMenu");
        
    }
}
