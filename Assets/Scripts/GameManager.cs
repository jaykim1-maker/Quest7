using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public UIManager uimanager;
    [SerializeField] public FollowCamera followCamera;

    public int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
}
