using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilHurt : MonoBehaviour
{
    void OnTriggerEnter2D(Collision collision)
    {
        if (collision.transform.tag=="Player")
        {

        }
    }
}
