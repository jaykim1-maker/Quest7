using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static ResourceController _resourceController;


    [SerializeField] public UIManager uimanager;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] public FollowCamera followCamera;
=======
    private Player player;
=======
>>>>>>> main
=======
    [SerializeField] public FollowCamera followCamera;
=======
>>>>>>> speed,LevelDifficulty
=======

    [SerializeField] public FollowCamera followCamera;

>>>>>>> speed,LevelDifficulty
=======
>>>>>>> main
    private UIManager uiManager;
    public static bool isFirstLoading = true;

    public int score = 0;
    public int coinCount = 0; // ���� ���� ���� �߰�

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
<<<<<<< HEAD
        }
<<<<<<< HEAD
=======
        uiManager = FindObjectOfType<UIManager>();
=======
>>>>>>> main

        uiManager = FindObjectOfType<UIManager>();
        if (_resourceController == null)
            _resourceController = FindObjectOfType<ResourceController>();

>>>>>>> main
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
        Time.timeScale = 1f;
        uiManager.SetPlayGame();
    }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> main
=======

>>>>>>> speed,LevelDifficulty
=======
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
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
}
>>>>>>> main
=======

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
>>>>>>> main
