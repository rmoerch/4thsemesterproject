using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	protected GameManager() { }
	public static GameManager instance = null;

    //use this public field to insert hero prefab
    public GameObject heroPrefab;
    

    //maximum hp value
    public float maxHP = 100;

    //hp value to be updated and displayed in inspector
    public float currentHP;

    //all current ammo value
    public int allAmmo = 6000;

    //rather static but expansiable value to define size of magazine
    public int magSize = 60;

    //holds value of current magazine ammo
    public int magAmmo;




    //call when script instance is loaded
    private void Awake()
    {
        MakeSingleton();
    }

    //use singleton to initialize single instance of game manager
    //which is put in Dont Destroy On Load, thus preserving game object during level loading 
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


	public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}



}