using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Ääni
    public string playAudioClip;

    //Pick-up
    [SerializeField]
    private int healthammount;
    [SerializeField]
    private int manaAmmount;
    [SerializeField]
    private int damageToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Törmäsikö Punahilkka tähän collaideriin
        if (collision.CompareTag("Player"))
        {

            // Ääni
            AudioManager.instance.Play(playAudioClip);

            // Vaikuttaako kerättävä objekti terveyspisteisiin
            if (gameObject.CompareTag("HP"))
            {
                // Kyllä vaikuttaaa, joten pyydetään PlayerHealthManageria lisäämään terveyttä
                PlayerHealthManager.instance.AddPlayerHealth(healthammount);
            } 

            if (gameObject.CompareTag("MP"))
            {
                PlayerHealthManager.instance.AddPlayerMana(manaAmmount);
            }

            if (gameObject.CompareTag("fullHP"))
            {
                PlayerHealthManager.instance.SetMaxHP();
            }
            
            // Vaikuttaako kerättävä objekti manapisteisiin

            if (gameObject.CompareTag("fullMana"))
            {
                // Kyllä vaikuttaa, joten pyydetään PlayerHealthManageria  lisäämään manaa
                PlayerHealthManager.instance.SetMaxMP();
            }

            if (gameObject.CompareTag("damageHP"))
            {

                PlayerHealthManager.instance.HurtPlayer(damageToGive);
            }

            if (gameObject.CompareTag("damageMP"))
            {
                PlayerHealthManager.instance.HurtPlayerMana(damageToGive);
            }
            
        }

        Destroy(gameObject);
    }
}
