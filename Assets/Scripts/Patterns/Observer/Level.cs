using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    /*public delegate void CallbackType();
    public event CallbackType OnLevelUpAction;*/

    public event Action OnLevelUpAction;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        int currentLevel = GetLevel();
        experiencePoints += points;

        if (GetLevel() > currentLevel)
        {
            onLevelUp.Invoke();
            if (OnLevelUpAction != null)
            {
                OnLevelUpAction();
            }
        }
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