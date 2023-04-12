using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class keyManager : MonoBehaviour
{
    [SerializeField]
    private int keyNumber = 0;

    [SerializeField]
    private AudioClip keySound;


    public delegate void numberSender(int keyNumber);
    public static event numberSender KeyGet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KeyGet(keyNumber);
            collision.gameObject.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
