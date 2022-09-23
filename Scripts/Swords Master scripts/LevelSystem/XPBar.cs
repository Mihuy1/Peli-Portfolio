using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public TextMeshProUGUI levelText;

    public LevelSystem levelSystem;

    private void Awake()
    {
        //SetExperienceBarSize(50);
        //SetLevelNumber(7);
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        slider.value = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.text = "LEVEL: " + (levelNumber + 1);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        // Set the levelSystem object.
        this.levelSystem = levelSystem;

        // Update the starting values.
        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

        // Subscribe to changed events.
        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;

    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        // level change, update text.
        SetLevelNumber(levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        // experience change, update slider value.
        SetExperienceBarSize(levelSystem.GetExperienceNormalized());

    }

}
