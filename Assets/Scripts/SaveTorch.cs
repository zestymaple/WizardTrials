using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTorch : MonoBehaviour
{
    public Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collider Triggered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collider Was Player");
            // Save Player Location
            SaveGame(other.transform.position);
            Anim.SetBool("ON", true);
        }
    }
    
    public void SaveGame(Vector3 position)
    {
        // Player Position
        Debug.Log($"Saving Player Position: {position.x}:{position.y}:{position.z}");
        PlayerPrefs.SetFloat("player.location.x", position.x);
        PlayerPrefs.SetFloat("player.location.y", position.y);
        PlayerPrefs.SetFloat("player.location.z", position.z);
        // Keyboard Settings
        // Controller Settings
        // Player Progress? Boss Fight / Items / Health / Stamina
    }
}
