using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Clicking : MonoBehaviour
{
    public int apples;

    public Items gameplayManager;

    void Awake()
    {
        gameplayManager = GameObject.FindObjectOfType<Items>();
    }


    public static Clicking instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Tree")
            {
                gameplayManager.UpdateApples(apples);
            }
        }
    }
}