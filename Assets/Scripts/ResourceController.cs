using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private BaseController baseController;
    private StatHandler statHandler;
    private Coroutine damageCoroutine;

    private float timeSinceLastChange = float.MaxValue;
    public UIManager uiManager;

    public float CurrentHealth { get; set; }
    public float MaxHealth => statHandler.Health;
    private bool isDead = false;

    private void Awake()
    {
        statHandler = GetComponent<StatHandler>();
        baseController = GetComponent<BaseController>();
        if (uiManager == null)
            uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        CurrentHealth = statHandler.Health;
    }

    // 체력 변경 피해 또는 회복
    public bool ChangeHealth(float change)
    {
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (uiManager != null)
            uiManager.ChangePlayerHP(CurrentHealth, MaxHealth);
        else
            Debug.LogWarning("[체력] UIManager 연결 안 됨");

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }

    private IEnumerator ApplyContinuousDamage(float damagePerSecond)
    {
        while (CurrentHealth > 0)
        {
            ChangeHealth(-damagePerSecond * Time.deltaTime);
            yield return null;
        }
    }

    public void StartContinuousDamage()
    {
        if (damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(ApplyContinuousDamage(5f));
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;

        baseController.Death();
        StartCoroutine(ShowGameOverDelayed());
    }

    private IEnumerator ShowGameOverDelayed()
    {
        yield return new WaitForSeconds(1f); // 1초 대기
        if (uiManager != null)
            uiManager.SetGameOver();
        else
            Debug.LogWarning("[체력] UIManager 연결 안 됨 (GameOver)");
    }
    public void SetCurrentHealth(float value)
    {
        CurrentHealth = Mathf.Clamp(value, 0, MaxHealth);

        if (uiManager != null)
        {
            uiManager.ChangePlayerHP(CurrentHealth, MaxHealth); // 슬라이더 갱신
        }
        else
        {
            Debug.LogWarning("UIManager가 연결되어 있지 않습니다.");
        }
    }

}