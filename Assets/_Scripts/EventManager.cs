using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Intance { get; private set; }

    public event Action<int, int> OnHealthChanged;
    public event Action<int, int, int> OnEXPChanged;
    public event Action OnLevelUp;
    public event Action OnDie;

    private void Awake()
    {
        if (Intance != null && Intance != this)
        {
            Destroy(gameObject);
            return;
        }
        Intance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void HealthChanged(int current, int max) => OnHealthChanged?.Invoke(current, max);
    public void LevelUp() => OnLevelUp?.Invoke();
    public void PlayerDie() => OnDie?.Invoke();
    public void EXPChanged(int current, int nextEXP, int level) => OnEXPChanged?.Invoke(current, nextEXP, level);

}
