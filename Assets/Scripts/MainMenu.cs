using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play loads scene of game, thus starting game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Quit game
    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
