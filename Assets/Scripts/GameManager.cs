using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static ResourceController _resourceController;


    [SerializeField] public UIManager uimanager;

    [SerializeField] public FollowCamera followCamera;

    private UIManager uiManager;
    public static bool isFirstLoading = true;


    public int score = 0;
    public int coinCount = 0; // ���� ���� ���� �߰�

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

    // === ���⿡ AddCoin �Լ� �߰� ===
    public void AddCoin()
    {
        _resourceController.SetCurrentHealth(_resourceController.CurrentHealth + 20f);
        if (_resourceController.CurrentHealth >= _resourceController.MaxHealth)
            _resourceController.SetCurrentHealth(_resourceController.MaxHealth);

        coinCount += 1;
        score += 1;
        Debug.Log("Coin: " + coinCount);
        // �ʿ��ϴٸ� UI ���� �� �߰� �۾�
        uiManager.UpdateScoreUI(score);
    }
}