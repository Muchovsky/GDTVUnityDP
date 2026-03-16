using System;
using System.Collections;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;

    float currentHealth = 0;

    public event Action onHealthChanged;


    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    private void OnEnable()
    {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return fullHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        if (onHealthChanged != null) onHealthChanged.Invoke();
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            if (onHealthChanged != null) onHealthChanged.Invoke();
            yield return new WaitForSeconds(1);
        }
    }
}