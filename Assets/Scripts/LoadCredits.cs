using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCredits : MonoBehaviour
{
    [SerializeField]
    int creditsSceneIndex = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(creditsSceneIndex);
    }
}
