using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChoiceAvatar : MonoBehaviour
{
    TextMeshPro _textMeshPro;
    string avatarName;

    private void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshPro>();
        avatarName = _textMeshPro.text;
        SetAvatar(avatarName);
    }

    private void SetAvatar(string name)
    {
        switch (name)
        {
            case "��":

                break;
            case "�ƴ�":
                break;
            case "���и���":
                break;
            case "�˷���":
                break;
        }
    }
}
