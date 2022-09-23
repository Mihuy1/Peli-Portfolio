using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float mana;
    public float exp;
    public float[] position;


    public PlayerData (PlayerController player)
    {
        position = new float[2];
        position[0] = player.transform.position.x;
        position[1]= player.transform.position.y;
    }

}
