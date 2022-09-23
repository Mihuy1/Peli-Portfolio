using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRecepie : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    
    //<summary>
    // Jos pelihahmo törmäsi respetiin, kasvatetaan laskuria ja tuhotaan resepti lopuksi.
    // ScoreManager huolehtii pisteiden kasvattamisesta
    //</summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.Play("PickupRecepie");
            scoreManager.AddRecepie();
            Destroy(gameObject);
        }
    }
}
