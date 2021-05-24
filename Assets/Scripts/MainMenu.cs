using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //Load game scene, start the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //load in the game scene, hard coded
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //load main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
