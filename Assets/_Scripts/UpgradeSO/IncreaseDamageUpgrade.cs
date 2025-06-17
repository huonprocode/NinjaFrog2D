using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "ScriptableObject/Upgrade/Increase Damage")]

public class IncreaseDamageUpgrade : UpgradeOption
{
    public int damageIncrease = 1;
    public override void Apply(PlayerStats playerStats)
    {
        playerStats.damage += damageIncrease;
    }
}
