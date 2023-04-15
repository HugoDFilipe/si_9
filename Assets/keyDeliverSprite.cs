using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyDeliverSprite : MonoBehaviour
{
    public Sprite deliveredKey, defaultHole;
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = defaultHole;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void keyChange()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = deliveredKey;
    }
}
