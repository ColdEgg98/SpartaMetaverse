using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer instance { get; private set; }
    public string CharaName { get; set; } = "Bob";
    [SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }

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
            Debug.Log("MainPlayer : �ߺ� �߰� ����!");
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

    // ��ư Ŭ���� ��������Ʈ ����
    public void ChangePlayerSprite(string name)
    {
        Animator.SetBool(IsMoving, true);
        Sprite newSprite = Resources.Load<Sprite>($"CharaSprite/{name}/_{name}_run_16x16_2");
        if (newSprite != null)
        {
            SpriteRenderer.sprite = newSprite;
            onSpriteChange?.Invoke(newSprite); // �̺�Ʈ ó��
        }
    }
}
