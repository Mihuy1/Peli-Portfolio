using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int nowork = 100;
    // ƒ‰ni
    public string playAudioClip;
    public string playDeathClip;
    // Singelton
    public static PlayerHealthManager instance;

    // Pelihahmon, taso, kokemuspisteet, terveyspisteet ja manapisteet
    public string charName;
    public int playerLevel = 1;
    public float currentHP;
    [SerializeField]
    private float maxHP = 100;
    public float currentMP = 0;
    [SerializeField]
    private float maxMP = 100;

    public float currentCake;


    // EXP
    public float currentEXP;
    public float maxEXP = 0;

    public Image EXPbar;
    public Text EXPText;
    public Text playerLevelText;

    // Sliderit
    public Image playerHealthBar;
    public Text HPText;
    public Image playerManabar;
    public Text MPText;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // Singelton asetettu
        instance = this;
        // MP ja HP pelin alussa
        currentHP = maxHP;
        currentMP = maxMP;

        // Exp pelin alussa
        maxEXP = Mathf.Floor(100 * playerLevel * Mathf.Pow(playerLevel, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        // Tarkista pelihahmon tila ja toimi sen mukaan
        CheckPlayerStatus();
    }

    private void CheckPlayerStatus() 
    {
        if (currentHP != playerHealthBar.fillAmount)
        {
            // Kyll‰ on, joten p‰ivitet‰‰n tilapalkki (terveys/HP)
            playerHealthBar.fillAmount = Mathf.Lerp(playerHealthBar.fillAmount,
                currentHP / maxHP, Time.deltaTime * lerpSpeed);

            // P‰ivitet‰‰n terveyspisteet (pyˆristettyn‰ kokonaislukuun) myˆs tekstilaatikkoon
            HPText.text = "HP: " + Mathf.Round(playerHealthBar.fillAmount * 100) + " / " + maxHP;

            if (currentEXP != EXPbar.fillAmount)
            {
                // Kyll‰ on, joten p‰ivitet‰‰n tilapalkki (EXP)
                EXPbar.fillAmount = Mathf.Lerp(EXPbar.fillAmount, currentEXP / maxEXP, Time.deltaTime * lerpSpeed);

                // P‰ivitet‰‰n EXP-pisteet (pyˆristys) myˆs tekstilaatikkoon
                //EXPText.text = "EXP: " + Mathf.Round(EXPbar.fillAmount * 100) + " / ";
                EXPText.text = "EXP: " + currentEXP + " / " + maxEXP;

                if (currentEXP >= maxEXP)
                {
                    // Kyll‰ nousi joten:

                    // Siiryt‰‰n seuraavalle tasolle
                    playerLevel += 1;
                    //P‰ivitet‰‰n taso potrettiin
                    playerLevelText.text = playerLevel.ToString();
                    // Lasketaankokemus pisteet, jotka pit‰‰ saavuttaa seuraavaan tasoon
                    maxEXP = Mathf.Floor(100 * playerLevel * Mathf.Pow(playerLevel, 0.5f));
                    // Nollataan kokemuspisteet
                    currentEXP = 0;

                    // Testi: Ilmoitus konsoliin
                    print("JEE LEVELUP!");
                }
            }
        }

        if (currentMP != playerManabar.fillAmount)
        {
            // Kyll‰ on, joten p‰ivitet‰‰n tilapalkki (Mana)
            playerManabar.fillAmount = Mathf.Lerp(playerManabar.fillAmount, currentMP / maxMP, Time.deltaTime * lerpSpeed);
            // P‰ivitet‰‰n manapisteet (pyˆristys) myˆs tekstilaatikkoon
            MPText.text = "MP: " + Mathf.Round(playerManabar.fillAmount * 100) + " / " + maxMP; 
        }
    }

    public void AddPlayerEXP(int EXPammount)
    {
        currentEXP += EXPammount;
    }

    public void AddPlayerHealth(int healthammount)
    {
        currentHP += healthammount;

        // Jos HP menee yli maksimia estet‰‰n se
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void HurtPlayer(int damageTogive)
    {
        AudioManager.instance.Play(playAudioClip);
        currentHP -= damageTogive;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }


    private void Die()
    {
        AudioManager.instance.Play(playDeathClip);
        print(charName + " kuoli");
    }

    public void AddPlayerMana(int manaAmmount)
    {
        currentMP += manaAmmount;
            if (currentMP > maxMP)
        {
            currentMP = maxMP;
        }
    }

    public void HurtPlayerMana(int damageToGive)
    {
        currentMP -= damageToGive;

        // Jos mana menee alle nollaan, se estet‰‰n
        if (currentMP <= 0)
        {
            currentMP = 0;
        }
    }

    public void SetMaxHP()
    {
        currentHP = maxHP;
    }

    public void SetMaxMP()
    {
        currentMP = maxMP;
    }

    public float GetMaxMP()
    {
        return maxHP;
    }

    public float GetCurrentMP()
    {
        return currentMP;
    }

    
}
