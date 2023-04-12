using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 leftPos = new Vector2(5, 5), rightPos = new Vector2(5, 0), initPosition;
    [SerializeField]
    private float speed = 1;

    public bool reverseMovement = false;

    public bool moving = false;

    private float speedDivider = 1000;

    [SerializeField]
    private List<Vector2> posNumbers = new List<Vector2>();

    private int curpos = 1, nextpos = 2;

    private void Start()
    {
        speed = Mathf.Abs(speed);
        initPosition = transform.position;
        posNumbers.Add(leftPos + initPosition);
        posNumbers.Add(initPosition);
        posNumbers.Add(rightPos + initPosition);

        if (reverseMovement)
        {
            curpos = 1;
            nextpos = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving)
        {
            move();
        }
    }

    private void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, posNumbers[nextpos], speed/speedDivider);

        if(transform.position == (Vector3)posNumbers[nextpos])
        {
            if(curpos==0 && nextpos == 1)
            {
                curpos = 1;
                nextpos = 2;
            }
            else if(curpos == 1 && nextpos == 2)
            {
                curpos = 2;
                nextpos = 1;
            }
            else if (curpos == 2 && nextpos == 1)
            {
                curpos = 1;
                nextpos = 0;
            }
            else if (curpos == 1 && nextpos == 0)
            {
                curpos = 0;
                nextpos = 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (initPosition == new Vector2(0,0))
        {
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + rightPos.x, transform.position.y + rightPos.y, 0));
            Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + leftPos.x, transform.position.y + leftPos.y, 0));
        }
        else
        {
            Gizmos.DrawLine(initPosition, new Vector3(initPosition.x + rightPos.x, initPosition.y + rightPos.y, 0));
            Gizmos.DrawLine(initPosition, new Vector3(initPosition.x + leftPos.x, initPosition.y + leftPos.y, 0));
        }
    }
}
