using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public UpgradeUI upgradeUI;
    public PlayerStats playerStats;
    public List<UpgradeOption> allUpgrades;

    public void ShowRandomUpgrades()
    {
        Time.timeScale = 0f;
        var randomOptions = PickRandomUpgrades(3);
        upgradeUI.ShowOptions(randomOptions, this);
    }

    public void ApplyUpgrade(UpgradeOption option)
    {
        if (playerStats == null)
        {
            Debug.Log("Player Stats Null !!!");
            FindPlayerStats();
        }
        option.Apply(playerStats);
        upgradeUI.Hide();
        Time.timeScale = 1f;
        EventManager.Instance.HealthChanged(playerStats.currentHealth, playerStats.maxHealth);
    }

    private List<UpgradeOption> PickRandomUpgrades(int count)
    {
        List<UpgradeOption> selected = new List<UpgradeOption>();
        while (selected.Count < count)
        {
            var pick = allUpgrades[Random.Range(0, allUpgrades.Count)];
            if (!selected.Contains(pick)) selected.Add(pick);
        }
        return selected;
    }

    public void FindPlayerStats()
    {
        playerStats = FindAnyObjectByType<PlayerStats>();
    }
}

