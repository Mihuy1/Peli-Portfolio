using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Warp : MonoBehaviour
{
    // Musiikkiin liittyv‰t
    public string playAudioClip;
    public string stopPlayAudio;

    // Alue  (Tiled-kartta), jonne kamera ja pelihahmo siirret‰‰n.
    public GameObject targetMap;

    // Piste alueella (Warp/Exit) jolle pelihahmo ja kamera siirtyy.
    public GameObject target;

    // Aluetekstiin liittyv‰t muuttujat
    public bool needText;
    public string placeName;
    public GameObject text;
    public TextMeshProUGUI placeText;

    void Awake()
    {
        // Piilotetaan Warpit n‰kyvist‰.
        // Haetaan Warp-objektin SpriteRenderer ja piilotetaan se
        GetComponent<SpriteRenderer>().enabled = false;
        // Haetaan Warp/Exit-objektin SpriteRenderer ja piilotetaan se
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        // Onko tˆrm‰‰j‰ pelihahmo?
        if (other.CompareTag("Player"))
        {
            // Piilotetaan pelhihamo
            other.gameObject.SetActive(false);

            // Etsit‰‰n Screen Fader GameObjekti
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            // Pyydet‰‰n ScreenFader -luokkaa aloittamaan pimennys-alirutiini (coroutine)
            yield return StartCoroutine(sf.FadeToBlack());

            // Kyll‰ on, joten siirret‰‰n pelihahmo toiselle alueelle kohtaan Warp/Exit
            other.transform.position = target.transform.GetChild(0).transform.position;

            // Pyydet‰‰n MainCamera-luokkaa sirt‰‰ myˆs kamera kohdealueelle.
            Camera.main.GetComponent<MainCamera>().SetBound(targetMap);

            AudioManager.instance.StopPlay(stopPlayAudio);
            AudioManager.instance.Play(playAudioClip);

            // N‰ytet‰‰n pelihahmo
            //other.gameObject.SetActive(true);

            // Pyydet‰‰n ScreenFader -luokkaa aloittamaan valaistus-alirutiini (coroutine)
            //yield return StartCoroutine(sf.FadeToClear());

            // Pit‰‰kˆ alueteksti n‰ytt‰‰?
            if (needText)
            {
                // Kyll‰ pit‰‰, joten aloitetaan aluetekstin n‰ytt‰minen alurutiinissa (coroutine)
                StartCoroutine(placeNameCo());
            }

            // N‰ytet‰‰n pelihahmo.
            other.gameObject.SetActive(true);

            // Pyydet‰‰n ScreenFader -luokkaa aloittamaan valaistus-alirutiini (coroutine)
            yield return StartCoroutine(sf.FadeToClear());
        }
    }



    IEnumerator placeNameCo() 
    {
        // N‰ytet‰‰n uuden aluen nimi
        text.SetActive(true);
        placeText.text = placeName;

        // Odotetan 4 sek.
        yield return new WaitForSeconds(4f);

        // Ja piilotetaan aluenimi, kun 4 sek on kulunutos 
        text.SetActive(false);
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
