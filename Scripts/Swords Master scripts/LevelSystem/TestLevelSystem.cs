using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevelSystem : MonoBehaviour
{
    [SerializeField] private XPBar xpBar;

    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        xpBar.SetLevelSystem(levelSystem);
    }
}
