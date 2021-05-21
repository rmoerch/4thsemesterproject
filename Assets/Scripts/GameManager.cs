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

    //hp value to be updated and displayed in game ui
    public float currentHP;

    public int allAmmo = 6000;

    public int magSize = 60;

    public int magAmmo;





    private void Awake()
    {
        MakeSingleton();
    }

    //use singleton to initialize single instance of game manager
    //which is put in Dont Destroy On Load, which passes this object through game w/o destroying it
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