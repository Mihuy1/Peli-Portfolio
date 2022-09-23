using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour
{

    [SerializeField] private GameObject virtualCamera1;
    [SerializeField] private GameObject virtualCamera2;

    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    // Start is called before the first frame update
    void Start()
    {
        // Virtuaalikamera 1 aktiivinen
        virtualCamera1.SetActive(true);
        // Virtuaalikamera 2 pois käytöstä
        virtualCamera2.SetActive(false);
        // Virtuaalikamera 3 pois käytöstä
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Kyllä, joten virtuaalikamera 2 aktivoituu
            virtualCamera1.SetActive(false);
            virtualCamera2.SetActive(true);

            // Samalla vaihdetaan taustakuva
            Background1.SetActive(false);
            Background2.SetActive(true);

           
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
