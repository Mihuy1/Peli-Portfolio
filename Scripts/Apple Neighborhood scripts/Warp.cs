using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public GameObject targetMap;

    public GameObject target;


    void Awake()
    {
        GetComponent <SpriteRenderer>().enabled = false;

        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = target.transform.GetChild(0).transform.position;

            Camera.main.GetComponent<MainCamera>().SetBound(targetMap);
        }
    }
}
