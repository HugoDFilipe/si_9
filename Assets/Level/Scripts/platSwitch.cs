using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platSwitch : MonoBehaviour
{
    [SerializeField]
    private PlatformMovement[] platforms;
    [SerializeField]
    private bool onSwitch=true;
    [SerializeField]
    private GameObject text;

    private bool canMove = false;

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
            canMove = false;
        }
    }
}
