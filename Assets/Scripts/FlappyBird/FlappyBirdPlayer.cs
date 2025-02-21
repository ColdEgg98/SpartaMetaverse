using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FlappyBirdPlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;
    SpriteRenderer _spriteRenderer;

    [Header("Value")]
    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    float deathCooldown = 0f;

    bool isFlap = false;

    [Header("Test")]
    public bool godMode = false;
    public bool isDead = false;

    FlappyBirdGameManager gameManager;

    MainPlayer player { get { return MainPlayer.instance; } }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FlappyBirdGameManager.Instance;

        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponentInChildren<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (animator == null)
            Debug.LogError("Not Founded Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Founded Rigidbody2D");

        if (_spriteRenderer == null)
            Debug.LogError("Not Founded SpriteRenderer");

        MainPlayer.onSpriteChange += updateSprite;
    }

    private void updateSprite(Sprite newSprite)
    {
        _spriteRenderer.sprite = newSprite;
    }

    private void OnDestroy()
    {
        MainPlayer.onSpriteChange -= updateSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0f)
            {
                // 게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
                // 메인 씬으로 돌아가기
                else if (!(Input.GetKeyDown(KeyCode.Space)) && !(Input.GetMouseButtonDown(0)))
                {
                    gameManager.BackMainScene();
                }
            }
            else
                deathCooldown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                isFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
