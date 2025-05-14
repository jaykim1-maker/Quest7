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
        else Debug.LogError("HomeUI°¡ ¾À¿¡ ¾ø½À´Ï´Ù!");

        gameUI = GetComponentInChildren<GameUI>(true);
        if (gameUI != null) gameUI.Init(this);
        else Debug.LogError("GameUI°¡ ¾À¿¡ ¾ø½À´Ï´Ù!");

        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        if (gameOverUI != null) gameOverUI.Init(this);
        else Debug.LogError("GameOverUI°¡ ¾À¿¡ ¾ø½À´Ï´Ù!");

        ChangeState(UIState.Home);
    }

    void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        else
            Debug.LogError("gameOverPanelÀÌ ¿¬°áµÇ¾î ÀÖÁö ¾Ê½À´Ï´Ù!");

        Time.timeScale = 0f;

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("restartButtonÀÌ ¿¬°áµÇ¾î ÀÖÁö ¾Ê½À´Ï´Ù!");
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
            Debug.LogError("gameUI°¡ nullÀÔ´Ï´Ù!");
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 9ab3efa (ì ìˆ˜ì¶”ê°€)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)

        isGameOver = true;
        gameOverPanel.SetActive(true);
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        if (scoreText != null)
            scoreText.text = $"Score : {scoreValue}";
        if (bestScoreText != null)
            bestScoreText.text = $"Best : {bestScore}";
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of 9ab3efa (ì ìˆ˜ì¶”ê°€)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
        scoreText.text = $"Score : {score}";
        bestScoreText.text = $"Best : {bestScore}";
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
    }

    public void UpdateUI()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void UpdateScore()
    {
        // ±¸Çö ÇÊ¿ä½Ã ÀÛ¼º
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        // ÇÊ¿ä½Ã ±¸Çö
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
 
>>>>>>> parent of 9ab3efa (ì ìˆ˜ì¶”ê°€)
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
 
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
