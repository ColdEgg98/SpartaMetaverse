using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Serialize] private GameObject PlayerObject;

    private static bool isInitialized = false;
    private Transform pivotTransform;

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

        PlayerGoPivot();
    }

    void PlayerGoPivot()
    {
        GameObject.FindWithTag("Player").gameObject.transform.position = FindPlayerPivot().position;
    }

    Transform FindPlayerPivot()
    {
        return GameObject.FindWithTag("Pivot").gameObject.transform;
    }
}
