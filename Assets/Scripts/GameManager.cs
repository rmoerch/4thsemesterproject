using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
	protected GameManager() { }
	public static GameManager instance = null;

    //use this public field to insert hero prefab
    [SerializeField]
    private GameObject _heroPrefab;

    public GameObject HeroPrefab
    {
        get
        {
            return _heroPrefab;
        } set
        {
            _heroPrefab = value;
        }
    }


    //maximum hp value
    [SerializeField]
    private float _maxHP = 100f;

    public float MaxHP
    {
        get
        {
            return _maxHP;
        } set
        {
            _maxHP = value;
        }
    }

  
    //hp value to be updated and displayed in inspector
    [SerializeField]
    private float _currentHP;

    public float CurrentHP
    {
        get
        {
            return _currentHP;
        }
        set
        {
            _currentHP = value;
        }
    }

    //all current ammo value
    [SerializeField]
    private int _allAmmo = 450;

    public int AllAmmo
    {
        get
        {
            return _allAmmo;
        } set
        {
            _allAmmo = value;
        }
    }

    //rather static but expansiable value to define size of magazine
    [SerializeField]
    private int _magSize = 30;

    public int MagSize
    {
        get
        {
            return _magSize;
        } set
        {
            _magSize = value;
        }
    }

    //holds value of current magazine ammo
    [SerializeField]
    private int _magAmmo;

    public int MagAmmo
    {
        get
        {
            return _magAmmo;
        } set
        {
            _magAmmo = value;
        }
    }

    //holds value of current ammo restore
    [SerializeField]
    private int _ammoRestore = 100;

    public int AmmoRestore
    {
        get
        {
            return _ammoRestore;
        }
        set
        {
            _ammoRestore = value;
        }
    }

    //cooldown between bullets fired from a gun
    [SerializeField]
    private float _shootCooldownTime = 20f;

    public float ShootCooldownTime
    {
        get
        {
            return _shootCooldownTime;
        } set
        {
            _shootCooldownTime = value;
        }
    }

    //boolean used in LoadGame method to keep track if loading of file was a success
    private bool isLoadedSuccesfully = false;

    //bollean used in SaveGame method to keep track if saving data to file was a success
    private bool isSavedSuccesfully = false;

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

    public void ReLaunch()
    {
        MaxHP = 100;
        AllAmmo = 450;
        MagSize = 30;
        ShootCooldownTime = 20f;
        MagAmmo = 0;
}
	public void OnApplicationQuit()
	{
		GameManager.instance = null;
	}

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Group14GameSaveData.dat");
        SaveData data = new SaveData();
        data.savedMaxHp = MaxHP;
        data.savedAllAmmo = AllAmmo;
        data.savedMagSize = MagSize;
        data.savedCoolDown = ShootCooldownTime;
        data.savedMagAmmo = MagAmmo;
        bf.Serialize(file, data);
        file.Close();
        
        if (File.Exists(Application.persistentDataPath + "/Group14GameSaveData.dat"))
        {
            Debug.Log("data saved!");
            isSavedSuccesfully = true;
        } else
        {
            Debug.Log("data not saved!");
            isSavedSuccesfully = false;
        }
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/Group14GameSaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Group14GameSaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            MaxHP = data.savedMaxHp;
            AllAmmo = data.savedAllAmmo;
            MagSize = data.savedMagSize;
            ShootCooldownTime = data.savedCoolDown;
            MagAmmo = data.savedMagAmmo;
            Debug.Log("data loaded!");
            isLoadedSuccesfully = true;

        } else
        {
            Debug.LogError("Saved data not found!");
            isLoadedSuccesfully = false;
        }
    }

    public bool GetLoadSuccess()
    {
        return isLoadedSuccesfully;
    }

    public bool GetSaveSuccess()
    {
        return isSavedSuccesfully;
    }
}

[Serializable]
class SaveData
{
    public float savedMaxHp;
    public int savedAllAmmo;
    public int savedMagSize;
    public float savedCoolDown;
    public int savedMagAmmo;
}