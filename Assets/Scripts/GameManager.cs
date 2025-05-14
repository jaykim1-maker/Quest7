using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] public UIManager uimanager;

    [SerializeField] public FollowCamera followCamera;

    private UIManager uiManager;
    public static bool isFirstLoading = true;


    public int score = 0;
    public int coinCount = 0; // 코인 개수 변수 추가

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        uiManager = FindObjectOfType<UIManager>();
<<<<<<< HEAD
=======

        if (_resourceController == null)
            _resourceController = FindObjectOfType<ResourceController>();
        _resourceController = new ResourceController();

>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
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

    // 게임 오버 시 카메라 초기화
    public void OnGameOver()
    {
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // 카메라 초기화

        // 게임 오버 처리 추가 (예: UI 표시, 일시정지 등)
        Debug.Log("게임 오버! 카메라 위치 초기화 완료");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // 카메라 초기화

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMain()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // 카메라 초기화

        SceneManager.LoadScene("Main"); // 메인 메뉴 씬 이름에 맞게 수정
    }

    // === 여기에 AddCoin 함수 추가 ===
    public void AddCoin()
    {
        coinCount += 1;
        Debug.Log("Coin: " + coinCount);
        // 필요하다면 UI 갱신 등 추가 작업
        UpdateUI();
    }
}