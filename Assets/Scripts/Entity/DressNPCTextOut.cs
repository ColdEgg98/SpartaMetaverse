using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DressNPCTextOut : MonoBehaviour
{
    [SerializeField] private TextMeshPro _textMeshPro;
    public GameObject CharacterChangeUI;
    private bool isPlayerInTrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        _textMeshPro.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _textMeshPro.text = "F를 누르면 아바타를 바꿀 수 있습니다!";
        isPlayerInTrigger = true;
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CharacterChangeUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _textMeshPro.text = "";
        CharacterChangeUI.SetActive(false);
        isPlayerInTrigger = false;
    }
}
