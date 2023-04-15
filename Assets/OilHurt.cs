using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OilHurt : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.GetComponent<Animator>().SetTrigger("Die");
            collision.GetComponent<PlayerMoviment>().enabled=false;
            collision.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            if (collision.GetComponent<oilRise>() != null)
            {
                collision.GetComponent<oilRise>().stop();
            }

            Invoke("restartScene", 1f);
        }
    }

    private void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
