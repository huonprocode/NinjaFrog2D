using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        EventManager.Instance.OnDie += GameOver;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnDie -= GameOver;
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
    }
    public void RestartGame()
    {
        UIManager.Instance.ShowRestartGame();
       
    }
}
