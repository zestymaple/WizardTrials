using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        ClearSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ClearSave()
    {
        // Player Position
        PlayerPrefs.DeleteKey("player.location.x");
        PlayerPrefs.DeleteKey("player.location.y");
        PlayerPrefs.DeleteKey("player.location.z");
        // Player Stats
    }
    
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}