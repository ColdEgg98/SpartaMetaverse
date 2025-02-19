using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdGameManager : MonoBehaviour
{
    static FlappyBirdGameManager gameManager;
    public static FlappyBirdGameManager Instance { get { return gameManager; } }

    private int currentScore = 0;

    UIManager uiManager;

    public UIManager UIManager { get { return uiManager; } }

    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        if (GameManager.Instance.FlappyBirdBestScore < currentScore)
            GameManager.Instance.FlappyBirdBestScore = currentScore;
        uiManager.SetRestart();
    }
    
    public void BackMainScene()
    {
        SceneManager.LoadScene("Main Scece");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"Score : {currentScore}");
        uiManager.UpdateScore(currentScore);
    }
}
