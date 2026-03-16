using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    [SerializeField] float fullHealth = 100f;
    [SerializeField] float drainPerSecond = 2f;
    [SerializeField] Image healthBar;
    float currentHealth = 0;

    private void Awake() {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }
    
    private void OnEnable() {
        GetComponent<Level>().onLevelUpAction += ResetHealth;
    }

    private void OnDisable() {
        GetComponent<Level>().onLevelUpAction -= ResetHealth;
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    void ResetHealth()
    {
        currentHealth = fullHealth;
        UpdateUI();
    }

    private IEnumerator HealthDrain()
    {
        while (currentHealth > 0)
        {
            currentHealth -= drainPerSecond;
            UpdateUI();
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = currentHealth / fullHealth;
    }
}