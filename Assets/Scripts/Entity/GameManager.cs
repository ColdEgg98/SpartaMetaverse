using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject PlayerObject;
    public SpriteRenderer test_SpriteRenderer;
    public Sprite test_Sprite;

    // 플래피버드 미니게임 최고 점수 기록
    public int FlappyBirdBestScore = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);

        if (MainPlayer.instance == null)
        {
            InitPlayerObject();
        }
    }

    private void Start()
    {
        if (MainPlayer.instance != null)
        {
            Debug.Log("GameManager : instance 확인");
            test_SpriteRenderer = GetComponent<SpriteRenderer>();
            test_Sprite = GetComponent<Sprite>();
            test_SpriteRenderer.sprite = MainPlayer.instance.SpriteRenderer.sprite;
            test_Sprite = test_SpriteRenderer.sprite;
        }
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
