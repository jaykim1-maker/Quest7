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
    public Text scoreText;
    public Text bestScoreText;
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
        if (homeUI != null) homeUI.Init(this);
        else Debug.LogError("HomeUI가 씬에 없습니다!");

        gameUI = GetComponentInChildren<GameUI>(true);
        if (gameUI != null) gameUI.Init(this);
        else Debug.LogError("GameUI가 씬에 없습니다!");

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        if (gameOverUI != null) gameOverUI.Init(this);
        else Debug.LogError("GameOverUI가 씬에 없습니다!");

        ChangeState(UIState.Home);
    }

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        else
            Debug.LogError("gameOverPanel이 연결되어 있지 않습니다!");

        Time.timeScale = 0f;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("restartButton이 연결되어 있지 않습니다!");
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
        if (gameUI != null)
            gameUI.UpdateHPSlider(currentHP / maxHP);
        else
            Debug.LogError("gameUI가 null입니다!");
    }

    public void CheckPlayerHP(int hp)
    {
        if (hp <= 0 && !isGameOver)
        {
            SetGameOver();
        }
    }

    public void ShowGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        int scoreValue = gameManager != null ? gameManager.score : 0;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (scoreValue > bestScore)
        {
            bestScore = scoreValue;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
        if (scoreText != null)
            scoreText.text = $"Score : {scoreValue}";
        if (bestScoreText != null)
            bestScoreText.text = $"Best : {bestScore}";
    }

    public void UpdateUI()
    {
<<<<<<< HEAD
        gameOverPanel.SetActive(false);        
=======
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        Time.timeScale = 0f;
>>>>>>> speed,LevelDifficulty
    }

    public void UpdateScore()
    {
        // 구현 필요시 작성
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        if (homeUI != null) homeUI.SetActive(currentState);
        if (gameUI != null) gameUI.SetActive(currentState);
        if (gameOverUI != null) gameOverUI.SetActive(currentState);
    }

    void Update()
    {
        // 필요시 구현
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
