using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    private static ObserverManager instance = null;

    public static ObserverManager Instance
    {
        get
        {
            if (instance == null) instance = new ObserverManager();
            return instance;
        }
    }

    private List<Subject> subjects = null;

    public void RegisterSubject(Subject subject)
    {
        if (subjects == null) subjects = new List<Subject>();
        subjects.Add(subject);
    }
}

public enum NotificationType
{
    FinishLevel1,
    FinishLevel2,
    FinishLevel3,
    PickUpUpgrade
}
