using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthPresenter:MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image healthBar;

    void Start()
    {
        health.onHealthChanged += UpdateUI;
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.fillAmount = health.GetHealth() / health.GetMaxHealth();
    }
}
