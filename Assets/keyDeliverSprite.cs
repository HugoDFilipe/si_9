using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyDeliverSprite : MonoBehaviour
{
    public int keyNumber;
    public Sprite deliveredKey;
    // Start is called before the first frame update
    void Start()
    {
        platSwitch.insertKeyGet += checkKey;
    }

    private void checkKey(int thisKeyNumber)
    {
        if (keyNumber == thisKeyNumber)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = deliveredKey;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
