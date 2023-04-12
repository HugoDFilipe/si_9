using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTrigger : MonoBehaviour
{
    [SerializeField]
    private PlatformMovement[] platforms;
    [SerializeField]
    private bool moveInput = false, requireKey = true;
    [SerializeField]
    private int keyNumber;
    [SerializeField]
    private GameObject text;

    private bool canMove = false, haskey=false;

    private void Start()
    {
        keyManager.KeyGet += checkKey;
    }

    private void checkKey(int eventKeyNumber)
    {
        Debug.Log(keyNumber);
        if (keyNumber == eventKeyNumber)
        {
            haskey = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            moveInput = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            moveInput = false;
        }

        if(canMove)
        {
            foreach (PlatformMovement platform in platforms)
            {
                platform.moving = moveInput;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if(requireKey)
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
        
        if (requireKey)
        {
            if (haskey && collision.gameObject.tag == "Player")
            {
                text.SetActive(false);
                foreach (PlatformMovement platform in platforms)
                {
                    platform.moving = false;
                }
                canMove = false;
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                text.SetActive(false);
                foreach (PlatformMovement platform in platforms)
                {
                    platform.moving = false;
                }
                canMove = false;
            }
        }
    }
}
