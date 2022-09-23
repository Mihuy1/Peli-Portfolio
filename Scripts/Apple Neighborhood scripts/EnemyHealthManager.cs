using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public static EnemyHealthManager instance;

    [SerializeField]
    private string enemyName;
    [SerializeField]
    private float EnemyMaxHP = 100f;
    [SerializeField]
    private float EnemyCurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        EnemyCurrentHP = EnemyMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            HurtEnemy(5);
        }
    }

    public void HurtEnemy(int damageToTake)
    {
        EnemyCurrentHP -= damageToTake;

        if (EnemyCurrentHP == 0) 
        {
            Die();
        }
    }

    public void Die()
    {
        print(enemyName + " kuoli!");
        Destroy(gameObject);
        // AudioManagerista ‰‰ni t‰h‰n.
    }

}
