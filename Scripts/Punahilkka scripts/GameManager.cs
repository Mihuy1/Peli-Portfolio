using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public bool dialogActive;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // Ei ole, joten luodaan GameManager
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Onko dialogi aktiivinen? Tieto tulee DialogManagerilta
        if (dialogActive)
        {
            // Dialogmanagerin mukaan on, joten estet‰‰n pelihahmon liikkuminen
            PlayerController.instance.canMove = false;
        }

        else
        {
            // Dialogmanagerin mukaan ei, joten sallitaan pelihahmon liikkuminen
            PlayerController.instance.canMove = true;
        }
    }


}
