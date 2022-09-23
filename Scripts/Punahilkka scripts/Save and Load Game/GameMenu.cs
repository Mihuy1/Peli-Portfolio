using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class GameMenu : MonoBehaviour
{
    //private PlayerController player;


    public void SaveGame()
    {
        SaveBySerialization();
    }

    public void LoadGame()
    {
        LoadByDeSerialization();
    }

    private SaveGame createSaveGameObject()
    {
        SaveGame savegame = new SaveGame();

        savegame.health = PlayerHealthManager.instance.currentHP;
        savegame.mana = PlayerHealthManager.instance.currentMP;
        savegame.exp = PlayerHealthManager.instance.currentEXP;

        savegame.PlayerPositionX = PlayerHealthManager.instance.transform.position.x;
        savegame.PlayerPositionY = PlayerHealthManager.instance.transform.position.y;

        

        return savegame;
    }

    public void SaveBySerialization()
    {
        SaveGame savegame = createSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();

        FileStream filestream = File.Create(Application.persistentDataPath + "/Data.text");

        bf.Serialize(filestream, savegame);

        filestream.Close();
    }

    public void LoadByDeSerialization()
    {
        if(File.Exists(Application.persistentDataPath + "/Data.text"))
        {
            // Lataa peli
            BinaryFormatter bf = new BinaryFormatter();

            FileStream filestream = File.Open(Application.persistentDataPath + "/Data.text", FileMode.Open);

            SaveGame savegame = bf.Deserialize(filestream) as SaveGame;
            filestream.Close();

            PlayerHealthManager.instance.currentHP = savegame.health;
            PlayerHealthManager.instance.currentMP = savegame.mana;
            PlayerHealthManager.instance.currentEXP = savegame.exp;

            PlayerHealthManager.instance.transform.position = new Vector2(savegame.PlayerPositionX, savegame.PlayerPositionY);
        } else
        {
            // Ei onnistunut tuli errori
            Debug.Log("EI LÖYTÄNYT KANSIOTA!");
        }
    }
}
