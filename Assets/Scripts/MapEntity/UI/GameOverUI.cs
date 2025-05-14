using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button exitButton;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
    }


    public void SetUI(int score, int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    //현재 씬을 다시 로드 재시작
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //게임 종료
    public void OnClickExitButton()
    {
        Application.Quit();
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }
}
