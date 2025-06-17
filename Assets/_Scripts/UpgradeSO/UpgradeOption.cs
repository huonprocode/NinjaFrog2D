using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeOption : ScriptableObject
{
    public string upgradeName;
    public Sprite icon;
    public string description;

    public abstract void Apply(PlayerStats playerStats);
}
