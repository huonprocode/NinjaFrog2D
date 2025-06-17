using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "ScriptableObject/Upgrade/Increase Health")]
public class IncreaseHealthUpgrade : UpgradeOption
{
    public int healthIncrease = 20;
    public override void Apply(PlayerStats playerStats)
    {
        playerStats.maxHealth += healthIncrease;
        playerStats.currentHealth += healthIncrease;
    }
}
