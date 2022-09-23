using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{

    // Referenssi animaattoriin
    private Animator anim;
    
    // Lippu, joka kertoo, että animaatio on suoritettu loppuun
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        // Otetaan animaattori käyttöön
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
            yield return null;
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
            yield return null;
    }

    void AnimationComplete()
    {
        isFading = false;
    }
}
