using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public UIManager uimanager;
<<<<<<< HEAD
    [SerializeField] public FollowCamera followCamera;
=======
    private UIManager uiManager;
    public static bool isFirstLoading = true;
>>>>>>> main

    public int score = 0;

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

    // ���� ���� �� ī�޶� �ʱ�ȭ
    public void OnGameOver()
    {
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // ī�޶� �ʱ�ȭ

        // ���� ���� ó�� �߰� (��: UI ǥ��, �Ͻ����� ��)
        Debug.Log("���� ����! ī�޶� ��ġ �ʱ�ȭ �Ϸ�");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // ī�޶� �ʱ�ȭ

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMain()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // ī�޶� �ʱ�ȭ

        SceneManager.LoadScene("Main"); // ���� �޴� �� �̸��� �°� ����
    }
}