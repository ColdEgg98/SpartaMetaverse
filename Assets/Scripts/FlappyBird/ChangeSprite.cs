using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            Debug.Log("GameManager instance�� ������.");
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = GameManager.Instance._SaveSpriteRenderer.sprite;
        }
    }
}