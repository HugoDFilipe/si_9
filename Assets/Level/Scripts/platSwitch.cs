using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platSwitch : MonoBehaviour
{
    [SerializeField]
    private PlatformMovement[] platforms;
    [SerializeField]
    private bool onSwitch = true, requireKey = false;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private int keyNumber;

    private bool canMove = false, haskey = false;

    private void Start()
    {
        keyManager.KeyGet += checkKey;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canMove)
            {
                foreach (PlatformMovement platform in platforms)
                {
                    platform.moving = onSwitch;
                }
            }
        }
    }

    private void checkKey(int eventKeyNumber)
    {
        Debug.Log(keyNumber);
        if (keyNumber == eventKeyNumber)
        {
            haskey = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (requireKey)
        {
            if (haskey && collision.gameObject.tag == "Player")
            {
                text.SetActive(true);
                canMove = true;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                text.SetActive(true);
                canMove = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(false);
            canMove = false;
        }
    }
}
