using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DressNPCTextOut : MonoBehaviour
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
            _textMeshPro.text = "F�� ������ �ƹ�Ÿ�� �ٲ� �� �ֽ��ϴ�!";
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textMeshPro.text = "";
    }
}
