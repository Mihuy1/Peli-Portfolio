using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{

    [SerializeField]
    private string enemyName;
    [SerializeField]
    private float EnemyMaxHP = 100f;
    [SerializeField]
    private float enemyCurrentHP;

    //Slideri
    public Image enemyHealthbar;
    public float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHP = EnemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            HurtEnemy(5);
        }

        CheckEnemyStatus();
    }

    private void CheckEnemyStatus() 
    {
        // Onko hp muuttunut
        if (enemyCurrentHP != enemyHealthbar.fillAmount)
        {
            // kyll‰ on joten p‰ivitet‰‰n tilapalkin terveys
            enemyHealthbar.fillAmount = Mathf.Lerp(enemyHealthbar.fillAmount,
                enemyCurrentHP / EnemyMaxHP, Time.deltaTime * lerpSpeed);
        }

    }

    public void HurtEnemy(int damageToTake)
    {
        // V‰hennet‰‰n terveytt‰
        enemyCurrentHP -= damageToTake;

        // Kuolikovihollinen
        if (enemyCurrentHP <= 0)
        {
            // Kyll‰ kuoli, joten asetetaan nykyinen terveys nollaanm
            //ja suoritetaan vihollisen kuolintotoimonnot
            enemyCurrentHP = 0;
            Die();
        }
    }

    private void Die()
    {
        AudioManager.instance.Play("Vihollinen_Kuolee");
        // Tulosta konsoliin ett‰ vihollinen jonka nimi on enemyName kuoli!
        print(enemyName + " kuoli");

        // Odotetaan puoli sekunttia ja tuhotaan vihollinen
        Destroy(gameObject, 0.5f);
    }
}
