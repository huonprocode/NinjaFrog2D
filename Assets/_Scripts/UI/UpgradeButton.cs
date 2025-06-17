using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image iconImage;
    private UpgradeOption option;
    private UpgradeManager manager;

    public void Setup(UpgradeOption upgrade, UpgradeManager upgradeManager)
    {
        option = upgrade;
        manager = upgradeManager;

        nameText.text = upgrade.upgradeName;
        descriptionText.text = upgrade.description;
        iconImage.sprite = upgrade.icon;
    }

    public void OnClick()
    {
        manager.ApplyUpgrade(option);
    }
}
