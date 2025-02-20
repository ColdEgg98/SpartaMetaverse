using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLoad : MonoBehaviour
{
    public SceneAsset sceneAsset;

    private bool isPlayerInTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            isPlayerInTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            isPlayerInTrigger = false;
    }

    private void Update()
    {
        if (isPlayerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (sceneAsset != null)
                {
                    string SceneName;
                    SceneName = sceneAsset.name;
                    SceneManager.LoadScene(SceneName);
                }
            }
        }
    }
}