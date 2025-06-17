using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "ScriptableObject/Upgrade/Increase Move Speed")]
public class IncreaseMoveSpeed : UpgradeOption
{
    public float moveSpeedIncrease = 0.2f;
    public override void Apply(PlayerStats playerStats)
    {
        playerStats.moveSpeed += moveSpeedIncrease;
    }
}
