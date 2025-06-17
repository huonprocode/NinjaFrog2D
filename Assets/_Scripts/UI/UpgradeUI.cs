using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject panel;
    public List<UpgradeButton> buttons;

    public void ShowOptions(List<UpgradeOption> options, UpgradeManager manager)
    {
        if (panel == null)
        {
            Debug.LogWarning("Upgrade Panel is missing!");
            return;
        }
        panel.SetActive(true);
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].Setup(options[i], manager);
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
