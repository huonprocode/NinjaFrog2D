using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Slider healthBarCtrl;
    public TextMeshProUGUI healthText;

    private void Start()
    {
        EventManager.Instance.OnHealthChanged += UpdateHealthUI;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnHealthChanged -= UpdateHealthUI;
    }
    private void UpdateHealthUI(int current, int max)
    {
        healthBarCtrl.value = (float)current / max;
        healthText.text = $"HP: {current}/{max}";
    }

}
