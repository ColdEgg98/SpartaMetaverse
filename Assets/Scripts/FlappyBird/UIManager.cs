using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.Log("restartText is null");

        if (scoreText == null)
            Debug.Log("scoreText is null");

        restartText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.text = $"Game Over!\r\nHigh score : {GameManager.Instance.FlappyBirdBestScore}\r\nFress Space to Restart";
        restartText.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"{score}";
    } 
}
