using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Items : MonoBehaviour
{

    public static Items instance;

    public int Hinta1 = 100;

    public int Hinta2 = 10;

    public int Hinta3 = 10;

    public int applevalue1;

    private int maxApple = 5;

    public int item1 = 1;

    public int item3 = 0;

    public int item4 = 0;

    public int Reset2;

    public Text Hinta1Text;

    public Text Hinta2Text;

    public Text Hinta3Text;

    public Text ApplesText;

    public Text ResetText;

    void Start()
    {
        instance = this;
        StartCoroutine(time());
        Hinta1Text.text = "" + Hinta1;
        Hinta3Text.text = "" + Hinta3;
    }
    void Update()
    {
        ApplesText.text = "" + applevalue1;
        ResetText.text = "" + Reset2;
        Hinta1Text.text = "" + Hinta1;
        Hinta2Text.text = "" + Hinta2;
        Hinta3Text.text = "" + Hinta3;
    }
    public void UpdateApples(int apples)
    {
        item1 = item1 += item4;
        applevalue1 = applevalue1 + 1 * item1;
        apples = applevalue1;
    }
    public void TaskOnClick1()
    {
        if (applevalue1 >= Hinta1)
        {
            applevalue1 -= Hinta1;
            item1++;
            Hinta1 = Hinta1 * 3;
        }
        else
        {
            Debug.Log("Et ostanut mit‰‰n");
        }
    }
    public void TaskOnClick3()
    {
        if (applevalue1 >= Hinta2)
        {
            applevalue1 -= Hinta2;
            PlayerHealthManager.instance.currentHP += 5;
        }
        else
        {
            Debug.Log("Et ostanut mit‰‰n");
        }
    }
    public void TaskOnClick2()
    {
        if (applevalue1 >= Hinta3)
        {
            applevalue1 -= Hinta3;
            item3++;
            Hinta3 = Hinta3 * 3;
        }
        else
        {
            Debug.Log("Et ostanut mit‰‰n");
        }
    }

    public int currentApples()
    {
        return applevalue1;
    }

    public int maxApples()
    {
        return maxApple;
    }

    public void appleCalculation(int appleToTake)
    {
        applevalue1 -= appleToTake;

        // Jos omenoiden m‰‰r‰ menee alle nollaan, se estet‰‰n
        if (applevalue1 < 1)
        {
            applevalue1 = 0;
        }
    }

    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }
    void timeCount()
    {
        applevalue1 += item3;
    }
}
