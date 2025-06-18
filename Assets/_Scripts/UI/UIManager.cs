using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    UpgradeManager upgradeManager;
    public GameObject pausePanel;
    public GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        upgradeManager = GetComponent<UpgradeManager>();

        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }
    private void Start()
    {
        EventManager.Instance.OnLevelUp += ShowUpgradeOption;
    }
    public void ShowPauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void ShowGameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void ShowRestartGame()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void ShowUpgradeOption()
    {
        upgradeManager.ShowRandomUpgrades();
    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
