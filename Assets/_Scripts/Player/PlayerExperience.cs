using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour
{
    public int currentEXP = 0;
    public int level = 1;
    public int expNextLevel = 100;
    private void Start()
    {
        EventManager.Intance.EXPChanged(currentEXP, expNextLevel, level);
    }
    public void GainEXP(int amount)
    {
        currentEXP += amount;
        EventManager.Intance.EXPChanged(currentEXP, expNextLevel, level);
        if (currentEXP >= expNextLevel)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        level++;
        currentEXP -= expNextLevel;
        expNextLevel += 50;

        EventManager.Intance.LevelUp();
        EventManager.Intance.EXPChanged(currentEXP, expNextLevel, level);
    }
}
