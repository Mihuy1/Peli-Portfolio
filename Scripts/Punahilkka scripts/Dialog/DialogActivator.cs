using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

public class DialogActivator : MonoBehaviour
{
    // Dialogin teksti tallenetaan taulukkoon
    public string[] lines;

    // Lippu, joka kertoo onko pelihahmo NPC-hahmon alueella
    private bool canActivate; // true = on alueella

    // Lippu, joka kertoo onko NPC-hahmolla nimi eli onko kyseess‰ hahmo vai esim. kyltti
    public bool isPerson = false; // false = NPC hahmolla on nimi;

    // Lippu, joka kertoo onko dialogi aloitettu
    private bool dialogActive;

    // Lippu, joka kertoo onko kyseess‰ QuestTrigger
    public bool isQuest;
    // Referenssi QuestManageriin
    private QuestManager questManager;
    // Teht‰v‰numero
    public int questNumber;

    // Fungus-dialogi
    public Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        // Luodaan yhteys QuestManageriin
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // Tutkitaan onko Flowchart-objekti olemassa

        if (flowchart == null)

        {
            // Ei ole
            return;
        
        }

        // Tutkitaan onko Fungus-dialogi jo p‰‰ttynyt

        if (flowchart.GetBooleanVariable("DialogStop"))

        {
            // Kyll‰ on joten vapautetaan pelihahmo
            GameManager.instance.dialogActive = false; ;

            // Deaktivoidaan dialogi
            flowchart.gameObject.SetActive(false);

        }
        // Onko pelihahmo dialogi alueella (canActivate = true) ja
        // onko hiiren vasenta korvaa napautettu ja dialogia ei ole viel‰ aloitettu?
        if (canActivate && Input.GetButtonDown("Fire1") && !dialogActive)
        {
            // Kyll‰ on, joten pyydet‰‰n DialogManageria n‰ytt‰m‰‰n dialogi ikkunassa eka repliikki
            // DialogManager.instance.showDialog(lines, isPerson);

            // Informoidaan GameManageria, ett‰ dialogi on k‰ynniss‰ --- Pelihahmo ei liiku
            GameManager.instance.dialogActive = true;

            // Aktivoidaan dialogi --> dialogi k‰ynnistyy automaattisesti
            flowchart.gameObject.SetActive(true);

            // Nostetaan lippu merkiksi, ett‰ dialogi k‰ynnistetty 
            dialogActive = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Onko pelihahmo alueella?
        if (collision.CompareTag("Player"))
        {
            // On joten nostetaan merkkilippu.
            canActivate = true; // Update funktiota varten
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            // Kyll‰ tuli joten lasketaan merkkilippu
            canActivate = false; // Update funktiota varten


            // Oliko kyseeess‰ teht‰v‰?
            if (isQuest)
            {
                // Aloittaa teht‰v‰n ja n‰ytt‰‰ aloitustekstin
                StartQuest();
            }
            // Onko dialogi varmasti aloitettu
            if (dialogActive)
            {
                // On aloitettu joten kohde katoaa
                gameObject.SetActive(false);
            }
        }
    }

    public void StartQuest()
    {
        // Pyyt‰‰ QuestManageria aktivoimaan teht‰v‰n ja n‰ytt‰m‰‰n aloitustekstit
        questManager.quests[questNumber].gameObject.SetActive(true);
        questManager.quests[questNumber].StartQuest();

        // Poistaa DialogActivatorin
        gameObject.SetActive(false);
    }
}
