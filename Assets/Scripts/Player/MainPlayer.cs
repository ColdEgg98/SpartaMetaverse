using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer instance { get; private set; }
    public string CharaName { get; set; } = "Bob";

    public SpriteRenderer _SpriteRenderer;
    public SpriteRenderer SpriteRender
    {
        get => _SpriteRenderer;
        set
        {   // 스프라이트 변화를 감지하고 이벤트 발생
            if (_SpriteRenderer.sprite != value.sprite)
            {
                Debug.Log("이벤트 발생!");
                _SpriteRenderer.sprite = value.sprite;  
                onSpriteChange.Invoke(value.sprite);
            }
        }
    }


    public Animator Animator;
    public AnimatorOverrideController[] AniController;

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    public delegate void OnSpriteChange(Sprite newSprite);
    public static event OnSpriteChange onSpriteChange;

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

        _SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Animator = GetComponentInChildren<Animator>();

        DontDestroyOnLoad(gameObject);
    }

    public void ChangePlayerAnimator(int index)
    {
        if (index < 0 || index >= AniController.Length)
            return;
        Animator.runtimeAnimatorController = AniController[index];
    }

    // 버튼 클릭시 스프라이트 변경
    public void ChangePlayerSprite(string name)
    {
        Animator.SetBool(IsMoving, true);
        Sprite newSprite = Resources.Load<Sprite>($"CharaSprite/{name}/_{name}_run_16x16_2");
        if (newSprite != null)
        {
            _SpriteRenderer.sprite = newSprite;
        }
    }
}
