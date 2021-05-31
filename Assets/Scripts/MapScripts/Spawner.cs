using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq;

public class Spawner : MonoBehaviour
{
    public RoomFirstDungeonGenerator dungeonGenerator;
    public GameObject heroPrefab;
    private GameManager gM;
    public GameObject enemyPrefab;
    public List<BoundsInt> spawner;
    public List<BoundsInt> availableRooms;
    public HashSet<BoundsInt> randomFloorTilesList1;
    
    Collision collision;
    public GameObject portal;
    private GameObject heroClone;
    public GameObject potion;
    public GameObject chest;
    public GameObject npc;
    public GameObject cell;
    public GameObject key;
    public GameObject[] decorations;
    public GameObject[] torches;
    public GameObject[] traps;
    //public List<GameObject> objectsToSpawn;


    void Start()
    {
        gM = GameManager.instance;
        PlayerSpawn();
        //EnemySpawnCenter();
        EnemySpawnRandom();
        PortalSpawn();
        //PotionSpawn();
        ChestSpawn();
        CellSpawn();
        KeySpawn();
        DecorationsSpawn();
        TorchesSpawn();
        TrapSpawn();

        //Update the AI Map after 1sec when everything is generated
        Invoke("UpdateAIMap", 1);
    }

    public GameObject GetHero()
    {
        return heroClone;
    }

    public void PlayerSpawn()
    {
        var vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0].GetComponent<CinemachineVirtualCamera>();
        DestroyObjects();

        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        //Spawn a hero in the center of a random room.
        availableRooms = new List<BoundsInt>();
        foreach (var room in dungeonGenerator.roomsList)
        {
            availableRooms.Add(room);
        }
        int i = Random.Range(0, availableRooms.Count);
        var spawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        heroClone = Instantiate(gM.HeroPrefab, spawnPoint.center, Quaternion.identity);
        vCam.Follow = heroClone.transform;
        heroClone.GetComponent<PlayerMovement>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        heroClone.GetComponentInChildren<BlasterRotation>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    public void PortalSpawn()
    {

        var hero = GameObject.FindGameObjectsWithTag("Player");

        //dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        //availableRooms = new List<BoundsInt>();

        foreach (var room in availableRooms)
        {
            var spawnpoint = room;

        }
        int i = Random.Range(0, availableRooms.Count);
        var portalSpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(portal, portalSpawnPoint.center, Quaternion.identity);

    }

    public void KeySpawn()
    {
        foreach (var room in availableRooms)
        {
            var spawnpoint = room;

        }
        int i = Random.Range(0, availableRooms.Count);
        var keySpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(key, keySpawnPoint.center, Quaternion.identity);

    }

    public void CellSpawn()
    {
        foreach (var room in availableRooms)
        {
            var spawnpoint = room;
            
        }
        int i = Random.Range(0, availableRooms.Count);
        var cellSpawnPoint = availableRooms[i];
        var npcSpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(cell, cellSpawnPoint.center, Quaternion.identity);
        Instantiate(npc, npcSpawnPoint.center, Quaternion.identity);
        
    }

    public void PotionSpawn()
    {
        foreach (var room in availableRooms)
        {
            var spawnpoint = room;
            Instantiate(potion, spawnpoint.center, Quaternion.identity);
        }
    }

    public void ChestSpawn()
    {
        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        List<BoundsInt> randomFloorTilesList1 = dungeonGenerator.roomsList;
        HashSet<Vector2Int> globalFloor = dungeonGenerator.globalFloorList;
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var room in randomFloorTilesList)
        {
            if (Random.Range(0, 200) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                Instantiate(chest, new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }
    public void DecorationsSpawn()
    {
        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        List<BoundsInt> randomFloorTilesList1 = dungeonGenerator.roomsList;
        HashSet<Vector2Int> globalFloor = dungeonGenerator.globalFloorList;
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var room in randomFloorTilesList)
        {
            if (Random.Range(0, 20) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                int randomIndex = Random.Range(0, decorations.Length);
                Instantiate(decorations[randomIndex], new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }

    public void TorchesSpawn()
    {
        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        List<BoundsInt> randomFloorTilesList1 = dungeonGenerator.roomsList;
        HashSet<Vector2Int> globalFloor = dungeonGenerator.globalFloorList;
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var room in randomFloorTilesList)
        {
            if (Random.Range(0, 100) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                int randomIndex = Random.Range(0, torches.Length);
                Instantiate(torches[randomIndex], new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }

    public void TrapSpawn()
    {
        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        List<BoundsInt> randomFloorTilesList1 = dungeonGenerator.roomsList;
        HashSet<Vector2Int> globalFloor = dungeonGenerator.globalFloorList;
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var room in randomFloorTilesList)
        {
            if (Random.Range(0, 50) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                int randomIndex = Random.Range(0, traps.Length);
                Instantiate(traps[randomIndex], new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }

    public void EnemySpawnCenter()
    {
        //Spawn a hero in the center of a random room.

        foreach (var room in availableRooms)
        {
            var spawnpoint = room;
            Instantiate(enemyPrefab, spawnpoint.center, Quaternion.identity);
        }

    }

    public void EnemySpawnRandom()
    {
        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
        //List<BoundsInt> roomsForEnemySpawn = dungeonGenerator.roomsList;
        HashSet<Vector2Int> globalFloor = dungeonGenerator.globalFloorList;

        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var room in randomFloorTilesList)    
        {
            if (Random.Range(0, 200) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                Instantiate(enemyPrefab, new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
            //int i = Random.Range(0, randomFloorTilesList.Count);
            //Vector2Int spawnpoint = randomFloorTilesList[i];
            //Instantiate(enemyPrefab, new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
        }


        //if (!collision.gameObject.CompareTag("wall"))
        //{
        //    Instantiate(enemyPrefab, new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
        //}
        //Instantiate(enemyPrefab, new Vector3(spawnPoint.x, spawnPoint.y,0) ,  Quaternion.identity);
        //Spawn a enemySpawner in the center of a random room.

        //foreach (var room in availablerooms)
        //{
        //    var spawnpoint = room.getcomponent(list<vector2int>(dungeongenerator.floor));
        //    int i = random.range(0, floortiles.count);

        //    var spawnpoint = floortiles[i];
        //    instantiate(enemyprefab, spawnpoint.center, quaternion.identity);
        //}

        //int i = Random.Range(0, availableRooms.Count);
        //var spawnPoint = availableRooms[i];
        //Instantiate(enemyPrefab, spawnPoint.center, Quaternion.identity);
    }

    private void UpdateAIMap()
    {
        AstarPath.active.Scan();
    }

    private void DestroyObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Hero"))
        {
            Destroy(o);
        }

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(i);
        }
    }

}
