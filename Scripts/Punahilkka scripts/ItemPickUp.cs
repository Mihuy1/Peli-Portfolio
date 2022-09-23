using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // ��ni
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
        // T�rm�sik� Punahilkka t�h�n collaideriin
        if (collision.CompareTag("Player"))
        {

            // ��ni
            AudioManager.instance.Play(playAudioClip);

            // Vaikuttaako ker�tt�v� objekti terveyspisteisiin
            if (gameObject.CompareTag("HP"))
            {
                // Kyll� vaikuttaaa, joten pyydet��n PlayerHealthManageria lis��m��n terveytt�
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
            
            // Vaikuttaako ker�tt�v� objekti manapisteisiin

            if (gameObject.CompareTag("fullMana"))
            {
                // Kyll� vaikuttaa, joten pyydet��n PlayerHealthManageria  lis��m��n manaa
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
