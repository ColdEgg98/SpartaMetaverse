using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool isInitialized = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (isInitialized)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        isInitialized = true;
    }
}
