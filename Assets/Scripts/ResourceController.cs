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

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler.Health;

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
        baseController.Death();
    }
}