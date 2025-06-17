using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevelUI : MonoBehaviour
{
    public Slider expBarCtrl;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    private void Start()
    {
        EventManager.Intance.OnEXPChanged += UpdateExp;
    }
    private void OnDisable()
    {
        EventManager.Intance.OnEXPChanged -= UpdateExp;
    }
    public void UpdateExp(int current, int max, int level)
    {
        expBarCtrl.value = (float)current / max;
        expText.text = $"Exp: {current}/{max}";
        levelText.text = "Lv: " + level.ToString();
    }

}
