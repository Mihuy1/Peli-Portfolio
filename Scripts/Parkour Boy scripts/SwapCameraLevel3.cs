using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameraLevel3 : MonoBehaviour
{

    [SerializeField] private GameObject virtualCamera2;
    [SerializeField] private GameObject virtualCamera3;

    [SerializeField] private GameObject Background2;
    [SerializeField] private GameObject Background3;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("Player"))
            {
                // Kyllä joten virtuaalikamera 3 menee päälle ja toinen menee pois päältä
                virtualCamera2.SetActive(false);
                virtualCamera3.SetActive(true);

                // Sammalla myös taustakuva
                Background2.SetActive(false);
                Background3.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
