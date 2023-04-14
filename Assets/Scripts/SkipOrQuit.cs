using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipOrQuit : MonoBehaviour
{
    [SerializeField]
    bool quitToMenu = false;

    [SerializeField]
    LoadNextScene _loadNextScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitToMenu)
                _loadNextScene.LoadSceneIndex(0);
            else
                _loadNextScene.LoadNextSceneIndex();
        }
            
    }
}
