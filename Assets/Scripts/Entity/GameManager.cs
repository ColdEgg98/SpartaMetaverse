using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerObject;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);

        if (MainPlayer.instance == null)
            InitPlayerObject();
    }

    void InitPlayerObject()
    {
        Instantiate(PlayerObject, FindPlayerPivot());
    }

    Transform FindPlayerPivot()
    {
        return GameObject.FindWithTag("Pivot").gameObject.transform;
    }
}
