using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    // Ääni
    public string playAudioClip;

    // Tehtävänumero
    public int questNumber;

    // Referenssi QuestManageriin
    private QuestManager questManager;

    // Esineen nimi
    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        // Luodaan yhteys QuestManageriin, jotta voidaan käyttää sen metodeja
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Osuiko pelihahmo esineeseen?
        if (collision.CompareTag("Player"))
        {
            // Pickup ääni
            AudioManager.instance.Play(playAudioClip);

            // Kyllä, joten tarkistetaan ettei tehtävää ole vielä tehty?
            if (!questManager.questCompleted[questNumber] &&
                questManager.quests[questNumber].gameObject.activeSelf)
            {
                // Ei ole, joten kerrotaan QuestManagerille esineen nimi
                questManager.itemCollected = itemName;

                // Deaktivoidaan esine
                gameObject.SetActive(false);

                // Ansaitut kullat tai EXP-pisteet koodataan tähän

                // Tehdäänkö esineelle jotain? Ehkä siirto invertoriin, tai otetaan se käyttöön, vai mitä??

                // Myös ääniefekti koodataan tähän
            }
        }
    }

} // QuestItem.cs päättyy tähän
