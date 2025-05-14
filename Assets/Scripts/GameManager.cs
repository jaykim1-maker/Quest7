using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public UIManager uimanager;
    private Player player;
    private UIManager uiManager;
    public static bool isFirstLoading = true;

    public int score = 0;
    public int HP = 100;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        score = 0;
        uiManager.SetPlayGame();
    }
    #region UIManager
    public void UpdateUI()
    {
        uimanager.UpdateUI();
    }

    public void UptateScoreText()
    {
        uimanager.UpdateScore();
    }

    #endregion  

    public void RestartGame()
    {
        score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//게임이 재시작되면 시간을 초기화하고 처음화면을 불러온다
    }

    public void LoadMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main"); // 메인 메뉴 씬 이름에 맞게 수정
    }

    public void AddCoin()
    {
        score++;
        HP += 5;
        if (HP >= 100)
            { HP = 100; }
        Debug.Log(score);
    }
}