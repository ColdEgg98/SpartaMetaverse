using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameLoad : MonoBehaviour
{
    public SceneAsset sceneAsset;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if ( sceneAsset != null)
                {
                    string SceneName;
                    SceneName = sceneAsset.name;
                    SceneManager.LoadScene(SceneName);
                }
            }
        }
    }
}
