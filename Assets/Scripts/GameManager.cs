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
    private Player player;
    private UIManager uiManager;
    public static bool isFirstLoading = true;
>>>>>>> main

    public int score = 0;
    public int HP = 100;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

<<<<<<< HEAD
=======
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
>>>>>>> main
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
        score = 0;
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
<<<<<<< HEAD
}
=======

    public void AddCoin()
    {
        score++;
        HP += 5;
        if (HP >= 100)
            { HP = 100; }
        Debug.Log(score);
    }
}
>>>>>>> main
