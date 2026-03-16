using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Level : MonoBehaviour {

    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    [SerializeField] Text levelDisplayText;
    [SerializeField] Text expDisplayText;
    [SerializeField] Button increaseXPButton;
    int experiencePoints = 0;

    public event Action onLevelUpAction;

    void Start()
    {
        UpdateUI();
        /*while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }*/
        increaseXPButton.onClick.AddListener(()=> GainExperience(10));
    }

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        UpdateUI();
        if (GetLevel() > level)
        {
            onLevelUp.Invoke();
            UpdateUI();
            if (onLevelUpAction != null)
            {
                onLevelUpAction();
            }
        }
    }

    private void UpdateUI()
    {
        levelDisplayText.text = $"Level: {GetLevel()}";
        expDisplayText.text = $"Exp: {GetExperience()}";
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}