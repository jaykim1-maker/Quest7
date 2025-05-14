using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public UIManager uimanager;
    private UIManager uiManager;
    public static bool isFirstLoading = true;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//������ ����۵Ǹ� �ð��� �ʱ�ȭ�ϰ� ó��ȭ���� �ҷ��´�
    }

    public void LoadMain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main"); // ���� �޴� �� �̸��� �°� ����
    }
}