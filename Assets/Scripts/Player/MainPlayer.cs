using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer instance { get; private set; }
    public string CharaName { get; set; }
    [SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }

    public Animator Animator;
    public AnimatorOverrideController[] AniController;

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

        DontDestroyOnLoad(gameObject);
    }

    public void ChangePlayerAnimator(int index)
    {
        if (index < 0 || index >= AniController.Length)
            return;
        Animator.runtimeAnimatorController = AniController[index];
    }

    public void ChangePlayerSprite(string name)
    {
        Debug.Log($"path : CharaSprite/{name}/{name}_idle_anim_16x16");
        if (Resources.Load<Sprite>($"CharaSprite/{name}/{name}_idle_anim_16x16") == null)
            Debug.Log("CharaSprite is null");
        else
            SpriteRenderer.sprite = Resources.Load<Sprite>($"CharaSprite/{name}/{name}_idle_anim_16x16_18");
    }
}
