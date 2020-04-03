using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Save current player setting
// Format should be something like: 'settingType.settingTitle.settingSubtitle'
// Ex: 'player.location.x' or 'input.controller.jump'
// Game Settings such as volume and difficulty will be saved from 'Menu' Scene
public class SaveSystem : MonoBehaviour
{
    public Transform Player;

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        if (scene.name == "Swamp_01")
        {
            LoadSave();
        }
    }

    // called when the game is terminated
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SaveGame()
    {
        // Player Position
        var position = Player.position;
        Debug.Log($"Saving Player Position: {position.x}:{position.y}:{position.z}");
        PlayerPrefs.SetFloat("player.location.x", position.x);
        PlayerPrefs.SetFloat("player.location.y", position.y);
        PlayerPrefs.SetFloat("player.location.z", position.z);
        // Keyboard Settings
        // Controller Settings
        // Player Progress? Boss Fight / Items / Health / Stamina
    }

    // Load current player setting
    // Check if setting exists using .Haskey()
    // If key exists use it ELSE set to DEFAULT value
    public void LoadSave()
    {
        // Load Save
        Debug.Log("Loading Save");

        // Player Position
        if (PlayerPrefs.HasKey("player.location.x") && PlayerPrefs.HasKey("player.location.y") &&
            PlayerPrefs.HasKey("player.location.z"))
        {
            float x = PlayerPrefs.GetFloat("player.location.x");
            float y = PlayerPrefs.GetFloat("player.location.y");
            float z = PlayerPrefs.GetFloat("player.location.z");

            Debug.Log($"Loading Player Position: {x}:{y}:{z}");
            Vector3 posVec = new Vector3(x, y, z);
            Player.position = posVec;
        }
        else
        {
            float x = -7.31f;
            float y = 0.78f;
            float z = 0f;

            Debug.Log($"Loading DEFAULT Player Position: {x}:{y}:{z}");
            Vector3 posVec = new Vector3(x, y, z);
            Player.position = posVec;
        }

        // Keyboard & Controller Settings can be directly checked from the player controller
    }
}