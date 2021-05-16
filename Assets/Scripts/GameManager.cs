using UnityEngine;
using System.Collections;

// Game States
public enum GameState { NullStage, MainMenu, Game, Boss, GameOver }

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
	protected GameManager() { }
	public static GameManager instance = null;
	public event OnStateChangeHandler OnStateChange;
	public GameState gameState { get; private set; }

    public GameObject heroPrefab;

    //public static GameManager Instance
    //{
    //	get
    //	{
    //		if (GameManager.instance == null)
    //		{
    //			GameManager.instance = new GameManager();
    //			DontDestroyOnLoad(GameManager.instance);
    //		}
    //		return GameManager.instance;
    //	}

    //}


    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //public void SetGameState(GameState state)
	//{
	//	this.gameState = state;
	//	OnStateChange();
	//}

	public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

}