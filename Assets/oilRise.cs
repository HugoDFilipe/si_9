using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilRise : MonoBehaviour
{
    [SerializeField]
    private float oilSpeed = 1f;
    public int keyNumber;
    public float keyGetMultiplier=1.5f;

    [SerializeField]
    private bool rising = false;
    // Start is called before the first frame update
    void Start()
    {
        keyManager.KeyGet += checkKey;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rising)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + oilSpeed/1000 , 0);
        }
    }

    void checkKey(int eventKeyNumber)
    {
        if (keyNumber <= eventKeyNumber)
        {
            rising = true;
            oilSpeed += (eventKeyNumber - 2) * keyGetMultiplier;
        }
    }
}
