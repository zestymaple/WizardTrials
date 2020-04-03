using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject deathMenuUI;

    private void Start()
    {
        Pause();
    }

    public void Pause()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void Resume()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }
}