using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    // ��ni
    public string playAudioClip;

    // Teht�v�numero
    public int questNumber;

    // Referenssi QuestManageriin
    private QuestManager questManager;

    // Esineen nimi
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        // Luodaan yhteys QuestManageriin, jotta voidaan k�ytt�� sen metodeja
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Osuiko pelihahmo esineeseen?
        if (collision.CompareTag("Player"))
        {
            // Pickup ��ni
            AudioManager.instance.Play(playAudioClip);

            // Kyll�, joten tarkistetaan ettei teht�v�� ole viel� tehty?
            if (!questManager.questCompleted[questNumber] &&
                questManager.quests[questNumber].gameObject.activeSelf)
            {
                // Ei ole, joten kerrotaan QuestManagerille esineen nimi
                questManager.itemCollected = itemName;

                // Deaktivoidaan esine
                gameObject.SetActive(false);

                // Ansaitut kullat tai EXP-pisteet koodataan t�h�n

                // Tehd��nk� esineelle jotain? Ehk� siirto invertoriin, tai otetaan se k�ytt��n, vai mit�??

                // My�s ��niefekti koodataan t�h�n
            }
        }
    }

} // QuestItem.cs p��ttyy t�h�n
