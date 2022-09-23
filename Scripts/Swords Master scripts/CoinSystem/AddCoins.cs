using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCoins : MonoBehaviour
{
    public static AddCoins Instance { get; set;}

    [SerializeField] private EnemyController enemyController;

    [SerializeField] private TextMeshProUGUI coinAmountText;

    

    public void AddingCoins()
    {
        GameManager.Instance.coins += GameManager.Instance.rewardAmount;
        GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
    }

    public void CustomAmountOfCoins(int coins)
    {
        GameManager.Instance.coins += coins;
        GameManager.Instance.coinAmountText.text = "" + GameManager.Instance.coins;
    }

}
