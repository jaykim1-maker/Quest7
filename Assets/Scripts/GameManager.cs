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
    public int coinCount = 0; // ���� ���� ���� �߰�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        uiManager = FindObjectOfType<UIManager>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> parent of 9ab3efa (점수추가)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)
=======
>>>>>>> parent of bfe9841 (Merge pull request #25 from jaykim1-maker/UI)

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
        coinCount += 1;
        Debug.Log("Coin: " + coinCount);
        // �ʿ��ϴٸ� UI ���� �� �߰� �۾�
        UpdateUI();
    }
}