using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }
    public AnimSO CurrentAnimData;

    private void Awake()
    {
        // Ensure only one instance of AnimationManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This keeps the GameObject persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public void SetAnimData(AnimSO data)
    {
        CurrentAnimData = data;
    }
}

