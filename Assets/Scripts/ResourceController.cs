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
    }

    private void Start()
    {
        CurrentHealth = statHandler.Health;
    }

    // ü�� ���� ���� �Ǵ� ȸ��
    public bool ChangeHealth(float change)
    {
        // ü�� ����
        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        FindObjectOfType<UIManager>().ChangePlayerHP(CurrentHealth, MaxHealth);

        if (uiManager != null)
            uiManager.ChangePlayerHP(CurrentHealth, MaxHealth);
        else
            Debug.LogWarning("[ü��] UIManager ���� �� ��");

        // ü���� 0 ���ϰ� �Ǹ� ��� ó��
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
