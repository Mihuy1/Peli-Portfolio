using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Ääni
    public string playAudioClip;
    // Millä ammutaan
    public GameObject projectilePrefabs;

    // Vähentää manaa 
    public int damageToGive;

    // Ammuksen laukaisu
    private float nextFire;
    private float FireRate = 1f;
    // Start is called before the first frame update
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire &&
            PlayerHealthManager.instance.GetCurrentMP() != 0)
        {
            // Ääni
            AudioManager.instance.Play(playAudioClip);
            // Kyllä voidaan, joten lasketaan seuraava laukaisu hetki
            nextFire = Time.time + FireRate;
            // Voidaanko ampua eli onko pelihahmolla manapisteitä tarpeeksi
            if (PlayerHealthManager.instance.GetCurrentMP() <=
                PlayerHealthManager.instance.GetMaxMP())
            {
                // Kyllä voidaan ampua, joten laukaistaan 8 ammusta 45 asteen kulmassa
                for (int i = 0; i < 8; i++) 
                {
                    Instantiate(projectilePrefabs, transform.position +
                    new Vector3(0, 0, 1), transform.rotation *
                    Quaternion.Euler(new Vector3(0, 0, 45 * i)));
                }
            }

            // Nollataan pelihahmon mana
            PlayerHealthManager.instance.HurtPlayerMana(damageToGive);
            //PlayerHealthManager.instance.HurtPlayerMana(15);
        }
    }
}
