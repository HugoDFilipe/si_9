using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    [SerializeField]
    private int keyNumber;
    [SerializeField]
    private AudioClip actionSound, calmSound;

    public AudioSource audioSource;

    private bool hasChanged = false;

    void Awake()
    {
        keyManager.KeyGet += checkKey;
        if (audioSource != null)
        {
            audioSource.clip = calmSound;
            audioSource.Play();
        }
    }

    // Update is called once per frame


    void checkKey(int eventKeyNumber)
    {
        if (keyNumber <= eventKeyNumber && !hasChanged && audioSource!=null)
        {
            audioSource.clip=actionSound;
            audioSource.Play();
            hasChanged = true;
        }
    }
}
