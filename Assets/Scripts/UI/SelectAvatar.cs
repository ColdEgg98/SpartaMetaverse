using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectAvatar : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ButtonClick(button));
    }

    public void ButtonClick(Button clickButton)
    {
        string btnName = clickButton.name;
        btnName = btnName.Replace(" Image", null);
        if (MainPlayer.instance != null)
        {
            MainPlayer.instance.CharaName = btnName;
            Debug.Log($"메인 캐릭 이름 : [{MainPlayer.instance.CharaName}]");
            MainPlayer.instance.ChangePlayerSprite(btnName);
        }
    }
}
