using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowHealthManager : MonoBehaviour
{

    public static WindowHealthManager instance;

    public int Reset1 = 0;

    public Items gameplayManager;
    
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private float EnemyMaxHP = 100;
    [SerializeField]
    private float enemyCurrentHP;

    //Slideri
    public Image enemyHealthbar;
    public float lerpSpeed;


    private void Awake()
    {
        enemyHealthbar = GameObject.FindGameObjectWithTag("HP").GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        // Asetetaan pelin alussa maksimi HP
        enemyCurrentHP = EnemyMaxHP;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // J-painike v‰hent‰‰ terveytt‰
        if (Input.GetKeyDown(KeyCode.J))
        {
            HurtEnemy(5);
        }

        CheckEnemyStatus();
    }

    private void CheckEnemyStatus()
    {
        // Onko HP muuttunut?
        if (enemyCurrentHP != enemyHealthbar.fillAmount)
        {
            // Kyll‰ on, joten p‰ivitet‰‰n tilapalkki(terveys)
            enemyHealthbar.fillAmount = Mathf.Lerp(enemyHealthbar.fillAmount,
            enemyCurrentHP / EnemyMaxHP, Time.deltaTime * lerpSpeed);
        }
    }

    public void HurtEnemy(int damageToTake)
    {
        // V‰hennet‰‰n terveytt‰
        enemyCurrentHP -= damageToTake;
        // Kuoliko pelihahmo?
        if (enemyCurrentHP <= 0)
        {
            // Kyll‰ kuoli, joten aseta nykyinen terveys nollaan
            // ja suoritetaan vihollisen kuolintoiminnot
            enemyCurrentHP = 0;
            Die();
        }
            
    }

    private void Die()
    {
        // Tulosta konsoliin ett‰ vihollinen jonka nimi on enemyName kuoli!
        print(enemyName + " is broken!");
        // Odotetaan 0,5 sekunttia ja tuhotaan vihollinen
        Destroy(gameObject, 0.5f);
        HouseSpawner.instance.Chance();
        Items.instance.applevalue1 = 0;
        Items.instance.Reset2 += 1;
        Items.instance.Hinta1 = 100;
        Items.instance.Hinta2 = 10;
        Items.instance.Hinta3 = 10;
        Items.instance.item1 = 0;
        Items.instance.item3 = 0;
        Items.instance.item4 += 2;
        PlayerHealthManager.instance.currentHP = 100;
        // EnemyHealthManager.Die();
    }

}
