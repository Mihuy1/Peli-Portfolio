using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    // Teht‰v‰st‰ saatavat kokemuspisteet (EXP)
    [SerializeField]
    private int EXPammount;
    // Teht‰v‰numero
    public int questNumber;

    // Aloitus- ja lopetustekstit
    public string[] lines;

    // Referenssi QuestManager-luokkaan
    public QuestManager questManager;

    // Lippu, joka kertoo onko kyseess‰ ker‰tyteht‰v‰
    public bool isItemQuest;

    // Ker‰tt‰v‰n esineen nimi
    public string targetItem;

    // Ker‰tt‰vien esineiden lukum‰‰r‰
    public int itemCollect;

    // Laskuri, joka laskee ker‰tyt esineet
    public int itemCollectCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ker‰ysteht‰v‰?
        if (isItemQuest)
        {
            // Kyll‰ on, joten tarkistetaan QuestManagerilta onko se tietoinen ker‰yksen kohteesta
            if (questManager.itemCollected == targetItem)
            {
                // Kyll‰ on, joten kasvatetaan esinelaskuria
                questManager.itemCollected = null;
                // Kasvatetaan laskuri
                itemCollectCount++;
            }

            // Onko esineit‰ ker‰tty tarpeeksi
            if (itemCollectCount >= itemCollect)
            {
                // Kyll‰ on, joten teht‰v‰ p‰‰ttyy
                EndQuest();
            }
        }
    }
    public void StartQuest()
    {
        // Pyydet‰‰n QuestManageria n‰ytt‰m‰‰n aloitusteksti
        questManager.ShowQuestText(lines[0]);
    }

    public void EndQuest()
    {
        // Pyydet‰‰n QuestManageria n‰ytt‰m‰‰n lopetusteksti
        questManager.ShowQuestText(lines[1]);

        // Pyydet‰‰n QuestManageria merkkamaan teht‰v‰ valmiiksi
        questManager.questCompleted[questNumber] = true;

        // Pyydet‰‰n PlayerHealthManageria kasvatamaan kokemuspisteit‰ (EXP)
        PlayerHealthManager.instance.AddPlayerEXP(EXPammount);

        // Deaktivoidaan teht‰v‰ kun se on tehty
        gameObject.SetActive(false);


    }
} // QuestObject.cs p‰‰ttyy.
