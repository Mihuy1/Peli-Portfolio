using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyScript : MonoBehaviour
{
    PlayerCombat playerCombat;
    PlayerController playerController;

    public bool[] booleans;

    private int damageCost;
    private int damageAmount;

    private int damageCost2;
    private int damageAmount2;

    public int lifeStealCost;
    public int lifeStealAmount;


    void Start()
    {
        damageCost = 10;
        damageAmount = 5;

        damageCost2 = 30;
        damageAmount2 = 10;

        lifeStealCost = 50;
        //lifeStealAmount = 15; Declared by DifficultySelector.cs
    }

    public void GiveDamage()
    {
        if (GameManager.Instance.coins >= damageCost && booleans[0] != true)
        {
            GameManager.Instance.coins -= damageCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.attackDamage += damageAmount;

            booleans[0] = true;
            Debug.Log("Damage Upgrade went through!"  + GameManager.Instance.attackDamage);
        } else if (booleans[0] != true)
        {
            Debug.Log("Not enough coins");
            
        } else if (booleans[0] == true)
        {
            Debug.Log("You have already bought damage upgrade before!");
        }
    }
    
    public void LifeSteal()
    {
        if (GameManager.Instance.coins >= lifeStealCost && booleans[1] != true)
        {
            GameManager.Instance.coins -= lifeStealCost;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.deathLifeSteal += lifeStealAmount;

            booleans[1] = true;
            Debug.Log("Life Steal is now: " + GameManager.Instance.deathLifeSteal);
        } else if (booleans[1] != true)
        {
            Debug.Log("Not enough coins!");
        } else if (booleans[1] == true)
        {
            Debug.Log("You have already bought lifesteal upgrade before!");
        }
    }
    public void GiveDamage2()
    {
        if (GameManager.Instance.coins >= damageCost2 && booleans[2] != true)
        {
            GameManager.Instance.coins -= damageCost2;
            GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
            GameManager.Instance.attackDamage += damageAmount2;

            booleans[2] = true;
            Debug.Log("Damage2 Upgrade went through!" + GameManager.Instance.attackDamage);
        }
        else if (booleans[2] != true)
        {
            Debug.Log("Not enough coins");

        }
        else if (booleans[2] == true)
        {
            Debug.Log("You have already bought damage upgrade before!");
        }
    }
}
