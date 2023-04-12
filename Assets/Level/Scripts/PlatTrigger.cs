using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTrigger : MonoBehaviour
{
    [SerializeField]
    private PlatformMovement[] platforms;
    [SerializeField]
    private bool moveInput = false;
    [SerializeField]
    private GameObject text;

    private bool canMove = false;

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
        if (collision.gameObject.tag == "Player")
        {
            text.SetActive(true);
            canMove = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
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
