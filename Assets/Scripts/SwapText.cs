using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwapText : MonoBehaviour
{
    [SerializeField]
    string[] texts;

    [SerializeField]
    float textDurationOnScreen = 4f;
    float currentDurationOnScreen = 1f;

    [SerializeField]
    LoadNextScene _loadNextScene;

    int currentTextIndex = 0;

    TextMeshProUGUI _shownText;
    Animator _animator;

    private void Start()
    {
        _shownText = GetComponent<TextMeshProUGUI>();
        _shownText.SetText(texts[currentTextIndex]);

        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(currentDurationOnScreen < textDurationOnScreen)
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
            _loadNextScene.LoadNextSceneIndex();
    }

    IEnumerator NextText()
    {
        _animator.SetBool("ShowText", false);

        yield return new WaitForSeconds(1f);

        _shownText.SetText(texts[++currentTextIndex]);

        _animator.SetBool("ShowText", true);

        yield return null;
    }
}
