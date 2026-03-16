using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] Level level;

    [SerializeField] Text levelDisplayText;
    [SerializeField] Text expDisplayText;
    [SerializeField] Button increaseXPButton;

    void Start()
    {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.onExperienceGained += UpdateUI;
        UpdateUI();
    }

    void GainExperience()
    {
        level.GainExperience(10);
    }

    void UpdateUI()
    {
        levelDisplayText.text = $"Level: {level.GetLevel()}";
        expDisplayText.text = $"Exp: {level.GetExperience()}";
    }
}