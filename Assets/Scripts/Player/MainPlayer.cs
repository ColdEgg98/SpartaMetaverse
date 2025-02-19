using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer instance { get; private set; }
    [SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    public Animator Animator { get; private set; }
    public Animation Animation { get; private set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            Debug.Log("MainPlayer : 중복 발견 삭제!");
            return;
        }

        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();
        Animation = GetComponentInChildren<Animation>();

        DontDestroyOnLoad(gameObject);
    }

    public Sprite ReturnSprite()
    {
        return instance.SpriteRenderer.sprite;
    }
}
