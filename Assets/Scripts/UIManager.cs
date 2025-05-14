using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum UIState
{
    Home,
    Game,
    GameOver,
}

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameManager gameManager;
    public Button restartButton;

    public TextMeshProUGUI score;

    private bool isGameOver = false;

    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        ChangeState(UIState.Home);
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 0f;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);

        ResourceController playerResource = FindObjectOfType<ResourceController>();
        if (playerResource != null)
        {
            playerResource.StartContinuousDamage();
        }

        Time.timeScale = 1f;
    }

    public void SetGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        ChangeState(UIState.GameOver);
        ShowGameOver();
        Time.timeScale = 0f;
    }

    public void ChangePlayerHP(float currentHP, float maxHP)
    {
        gameUI.UpdateHPSlider(currentHP / maxHP);
    }

    public void CheckPlayerHP(int hp)
    {
        if (hp <= 0 && !isGameOver)
        {
            SetGameOver();
        }
    }

    public void UpdateScoreUI(int score)
    {
        gameUI.SetScore(score);
    }

    public void ShowGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        gameOverPanel.SetActive(true);

        int score = gameManager.score;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // 저장을 즉시 반영
        }

        gameOverUI.SetUI(score, bestScore);
    }


    public void UpdateUI()
    {
        gameOverPanel.SetActive(false);        
    }

    public void UpdateScore()
    {

    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }

    void Update()
    {
        gameUI.SetScore(gameManager.score);
    }



    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
