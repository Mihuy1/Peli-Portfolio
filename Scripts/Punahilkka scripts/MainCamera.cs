using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Kohde, jota kamera seuraa(Pelihahmo)
    Transform target;

    // Kameran n‰kym‰n alueen koordinaatit. Riippuu kameran size-arvosta
    float tLX, tLY, bRX, bRY;

    // Suoritetaan ennen start metodia
    void Awake()
    {
        // Etsi pelihahmon transformi ja sijoita se muuttujaan
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        // Siirt‰‰ kameran samaan paikkaan miss‰ pelihahmo on,
        // sek‰ pit‰‰ kameran SetBound-metodissa m‰‰ritetyll‰ alueella
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, tLX, bRX),
            Mathf.Clamp(target.position.y, bRY, tLY),
            transform.position.z
    );
    }

    /// <summary>
    /// Metodi asettaa kameran n‰kem‰n alueen (map) rajat.
    /// Metodia kutsuu esim. Warp-luokka
    /// </summary>
    /// <param name="map"></param>
    public void SetBound(GameObject map)
    {

        // Hakee parametrin‰ (map) tulleen kartan ja sijoittaa sen config-muuttujaan
        SuperTiled2Unity.SuperMap config = map.GetComponent<SuperTiled2Unity.SuperMap>();

        // Talletetaan ortograafisen kameran leveys muuttujaan
        float cameraSize = Camera.main.orthographicSize;

        // Lasketaan suhdeluku, jolla korjataan x-suuntainen kameraliike
        float aspectRatio = Camera.main.aspect * cameraSize;

        // M‰‰ritet‰‰n kameran n‰kem‰n alueen vasen reuna
        tLX = map.transform.position.x + aspectRatio;
        tLY = map.transform.position.y - cameraSize;

        // M‰‰ritet‰‰n kameran n‰kym‰n alueen oikea reuna
        bRX = map.transform.position.x + config.m_Width - aspectRatio;
        bRY = map.transform.position.y - config.m_Height + cameraSize;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
