using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text bestScoreText;
    public GameManager gameManager;
    public Button restartButton;

    public TextMeshProUGUI score;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

    }

    public void CheckPlayerHP(int hp)
    {
        if (hp <= 0)
        {
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);

        int score = gameManager.score;
        int bestScore = PlayerPrefs.GetInt(BestScore, 0);

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }


    }

    public void UpdateUI()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void UpdateScore()
    {

    }

     void Update()
    {
 
    }



    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
