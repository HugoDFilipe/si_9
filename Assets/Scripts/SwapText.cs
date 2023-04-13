using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwapText : MonoBehaviour
{
    [SerializeField]
    string[] texts;

    [SerializeField]
    float[] textDurationOnScreen;
    float currentDurationOnScreen = 1f;

    [SerializeField]
    LoadNextScene _loadNextScene;

    [SerializeField]
    bool quitToMenu = false;

    int currentTextIndex = 0;

    TextMeshProUGUI _shownText;
    Animator _animator;

    private void Start()
    {
        _shownText = GetComponent<TextMeshProUGUI>();
        _shownText.SetText(texts[currentTextIndex].Replace("\\n", "\n"));

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(currentDurationOnScreen < textDurationOnScreen[currentTextIndex])
        {
            currentDurationOnScreen += Time.deltaTime;
            return;
        }

        currentDurationOnScreen = 0f;

        if (currentTextIndex + 1 < texts.Length)
        {
            StartCoroutine(NextText());
        }
        else
        {
            if (!quitToMenu)
                _loadNextScene.LoadNextSceneIndex();
            else
                _loadNextScene.LoadSceneIndex(0);
        }           
    }

    IEnumerator NextText()
    {
        _animator.SetBool("ShowText", false);

        yield return new WaitForSeconds(1f);

        _shownText.SetText(texts[++currentTextIndex].Replace("\\n", "\n"));

        _animator.SetBool("ShowText", true);

        yield return null;
    }
}
