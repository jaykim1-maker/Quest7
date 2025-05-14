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
    public int coinCount = 0; // ÄÚÀÎ °³¼ö º¯¼ö Ãß°¡

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
>>>>>>> parent of 9ab3efa (ì ìˆ˜ì¶”ê°€)
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

    // °ÔÀÓ ¿À¹ö ½Ã Ä«¸Þ¶ó ÃÊ±âÈ­
    public void OnGameOver()
    {
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // Ä«¸Þ¶ó ÃÊ±âÈ­

        // °ÔÀÓ ¿À¹ö Ã³¸® Ãß°¡ (¿¹: UI Ç¥½Ã, ÀÏ½ÃÁ¤Áö µî)
        Debug.Log("°ÔÀÓ ¿À¹ö! Ä«¸Þ¶ó À§Ä¡ ÃÊ±âÈ­ ¿Ï·á");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // Ä«¸Þ¶ó ÃÊ±âÈ­

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMain()
    {
        Time.timeScale = 1f;
        if (followCamera != null)
            followCamera.ResetCameraOnGameOver(); // Ä«¸Þ¶ó ÃÊ±âÈ­

        SceneManager.LoadScene("Main"); // ¸ÞÀÎ ¸Þ´º ¾À ÀÌ¸§¿¡ ¸Â°Ô ¼öÁ¤
    }

    // === ¿©±â¿¡ AddCoin ÇÔ¼ö Ãß°¡ ===
    public void AddCoin()
    {
        coinCount += 1;
        Debug.Log("Coin: " + coinCount);
        // ÇÊ¿äÇÏ´Ù¸é UI °»½Å µî Ãß°¡ ÀÛ¾÷
        UpdateUI();
    }
}