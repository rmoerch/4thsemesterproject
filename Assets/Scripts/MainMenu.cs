using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameManager gM;

    //call instance of game manager
    //set current stage to mainmenu
    private void Awake()
    {
        gM = GameManager.instance;
        gM.OnStateChange += HandleOnStateChange;
        Debug.Log("Current game state when Awakes: " + gM.gameState);
    }

    //test current game state
    private void Start()
    {
        Debug.Log("Current game state when Starts: " + gM.gameState);
        gM.SetGameState(GameState.MainMenu);
    }

    //set the OnStateChange event, when changing scenes
    public void HandleOnStateChange()
    {
        Debug.Log("Handling state change to: " + gM.gameState);
    }



    //Above new code for checking game states, doesnt seem to work atm
    //-------------------------------------------
    //Below is original main menu code
    //These things dont conflict and dont break the game so i guess it is ok



    //Load game scene, start the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //hardcoded load game method
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //load main menu
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
