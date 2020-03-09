using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject pick;
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.gameObject.SetActive(false);
    }
}
