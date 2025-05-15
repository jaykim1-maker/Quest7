using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BaseUI
{
    [SerializeField] private Slider hpSlider;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;

    private void Start()
    {
        UpdateHPSlider(1); // 시작시 체력바 100%
    }

    //체력 슬라이더 값을 퍼센트로 설정
    public void UpdateHPSlider(float percentage)
    {
        hpSlider.value = percentage;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);
        scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
    }

    public void SetUI(int score, int bestScore)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }

    public void SetScore(int score,int bestScore)
    {
        scoreText.text = $"{score}";
        bestScoreText.text = $"{bestScore}";
        Debug.Log(score);
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
}
