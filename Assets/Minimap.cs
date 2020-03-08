using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform MainCamera;

    private void LateUpdate()
    {
        Vector3 newPosition = MainCamera.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
