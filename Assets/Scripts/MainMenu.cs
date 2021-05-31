using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager gM;

    private void Start()
    {
        gM = GameManager.instance;
    }
    //Start the game from main menu
    //Also serves as continue the game
    //Because gamemanager instance is not reset
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //play again from game over scene
    //may 28, index 1 is intro scene which must be started each time before map scene
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Calls game manager method to destroy current instance and instantiate new
    //Serves as starting the new game with default gamemanager
    public void StartNewGame()
    {
        gM.ReLaunch();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Load previously saved progress from a file
    public void LoadGame()
    {
        try
        {
            gM.LoadGame();
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
        if(gM.GetSuccess() == true) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); } else
        {
            Debug.LogError("unsuccesful");
        }
        
    }
    //load main menu
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveGameProgress()
    {
        try
        {
            gM.SaveGame();
        } catch (Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }

    //quit game
    public void QuitGame()
    {
        Application.Quit();
    }
}
