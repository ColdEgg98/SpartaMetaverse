using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject PlayerObject;

    public event System.Action SpriteChanged;

    public SpriteRenderer _SaveSpriteRenderer;
    public SpriteRenderer SpriteRenderer { get => MainPlayer.instance._SpriteRenderer;
        set
        {
            if (MainPlayer.instance._SpriteRenderer != value)
            {
                _SaveSpriteRenderer = value;
                SpriteChanged?.Invoke();
                Debug.Log("이벤트가 발생했습니다");
            }
        }
    }


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

        SpriteRenderer = GetComponent<SpriteRenderer>();
        _SaveSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SpriteChanged += updateSprite;
    }

    private void updateSprite()
    {
        _SaveSpriteRenderer.sprite = MainPlayer.instance._SpriteRenderer.sprite;
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
