using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;

    public bool[] questCompleted;

    public string itemCollected;
    // Start is called before the first frame update
    void Start()
    {
        // Pelin alussa varataan questCompleted-taulukkoon jokaista teht‰v‰‰ varten oma paikka
        questCompleted = new bool[questCompleted.Length];
    }

    public void ShowQuestText(string questTask)

    {
        // Teht‰v‰n kuvaus (questTask) talletetaan taulukkoon (oneLine)
        string[] oneLine = new string[1];
        oneLine[0] = questTask;

        // Pyydet‰‰n sitten DialogManageria n‰ytt‰m‰‰n teht‰v‰n kuvaus 
        DialogManager.instance.showDialog(oneLine, false); // false = dialogissa ei ole otsikkoa
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
