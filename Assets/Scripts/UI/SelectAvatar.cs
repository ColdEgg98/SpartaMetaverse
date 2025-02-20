using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectAvatar : MonoBehaviour
{
    public GameObject CharacterChangeUI;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ButtonClick(button));
    }

    public void ButtonClick(Button clickButton)
    {
        CharacterChangeUI.SetActive(false);

        string btnName = (clickButton.name).Replace(" Image", null);

        if (MainPlayer.instance != null)
        {
            MainPlayer.instance.CharaName = btnName;
            Debug.Log($"메인 캐릭 이름 : [{MainPlayer.instance.CharaName}]");
            MainPlayer.instance.ChangePlayerSprite(btnName);

            int index = 0;

            switch (btnName)
            {
                case "Bob":
                    index = 0;
                    break;
                case "Adam":
                    index = 1;
                    break;
                case "Amelia":
                    index = 2;
                    break;
                case "Alex":
                    index = 3;
                    break;
            }

            MainPlayer.instance.ChangePlayerAnimator(index);
        }
        else
            Debug.LogWarning("There is no instance");
    }
}
