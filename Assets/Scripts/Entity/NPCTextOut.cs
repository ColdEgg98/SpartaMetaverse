using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NPCTextOut : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _textMeshPro.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _textMeshPro.text = "F를 누르면 미니게임을 시작합니다!";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textMeshPro.text = "";
    }
}
