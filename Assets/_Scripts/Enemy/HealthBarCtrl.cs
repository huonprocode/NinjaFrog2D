using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarCtrl : MonoBehaviour
{
    public Slider slider;
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        slider.value = (float)currentHealth / maxHealth;
    }
}
