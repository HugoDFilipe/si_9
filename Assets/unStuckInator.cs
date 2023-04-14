using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unStuckInator : MonoBehaviour
{
    [SerializeField]
    private Vector3 unstuckPosition;
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+unstuckPosition);
        Gizmos.DrawWireCube(transform.position + unstuckPosition, new Vector3(0.1f,0.1f,0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position += unstuckPosition;
    }
}
