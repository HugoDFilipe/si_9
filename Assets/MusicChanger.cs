using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField]
    private int keyNumber;
    [SerializeField]
    private AudioClip actionSound;

    private AudioSource audioSource;

    private bool hasChanged = false;

    void Awake()
    {
        keyManager.KeyGet += checkKey;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame


    void checkKey(int eventKeyNumber)
    {
        if (keyNumber <= eventKeyNumber && !hasChanged)
        {
            audioSource.clip=actionSound;
            audioSource.Play();
            hasChanged = true;
        }
    }
}
