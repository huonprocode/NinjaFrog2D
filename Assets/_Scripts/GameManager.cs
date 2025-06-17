using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Intance;

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
    private void Start()
    {
        EventManager.Intance.OnDie += GameOver;
    }
    private void OnDisable()
    {
        EventManager.Intance.OnDie -= GameOver;
    }

    public void GameOver()
    {
        UIManager.Intance.ShowGameOver();
    }
    public void RestartGame()
    {
        UIManager.Intance.ShowRestartGame();
       
    }
}
