﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //playervictory screen
        }

    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
