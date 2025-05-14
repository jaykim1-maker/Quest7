using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static ResourceController _resourceController;


    [SerializeField] public UIManager uimanager;
    private UIManager uiManager;
    public static bool isFirstLoading = true;

    public int score = 0;
    public int coinCount = 0; // 코인 개수 변수 추가

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        uiManager = FindObjectOfType<UIManager>();
        if (_resourceController == null)
            _resourceController = FindObjectOfType<ResourceController>();

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
        Time.timeScale = 1f;
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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//게임이 재시작되면 시간을 초기화하고 처음화면을 불러온다
    }

    public void LoadMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main"); // 메인 메뉴 씬 이름에 맞게 수정
    }

    // === 여기에 AddCoin 함수 추가 ===
    public void AddCoin()
    {
        _resourceController.SetCurrentHealth(_resourceController.CurrentHealth + 20f);
        if (_resourceController.CurrentHealth >= _resourceController.MaxHealth)
            _resourceController.SetCurrentHealth(_resourceController.MaxHealth);

        coinCount += 1;
        score += 1;
        Debug.Log("Coin: " + coinCount);
        // 필요하다면 UI 갱신 등 추가 작업
        uiManager.UpdateScoreUI(score);
    }
}