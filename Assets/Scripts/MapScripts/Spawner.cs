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
    public GameObject[] enemyPrefab;
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
    public List<BoundsInt> spawner;
    public List<BoundsInt> availableRooms;
    public HashSet<BoundsInt> randomFloorTilesList1;

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

    //Spawn our player in the center of a random room.
    public void PlayerSpawn()
    {
        var vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0].GetComponent<CinemachineVirtualCamera>();
        DestroyObjects();

        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();
       
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

    //Spawns a portal prefab in the middle of a single room.
    public void PortalSpawn()
    {
        int i = Random.Range(0, availableRooms.Count);
        var portalSpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(portal, portalSpawnPoint.center, Quaternion.identity);

    }

    //Spawns a key prefab in the middle of a single room.
    public void KeySpawn()
    {
        int i = Random.Range(0, availableRooms.Count);
        var keySpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(key, keySpawnPoint.center, Quaternion.identity);

    }

    //Spawns a cell prefab in the middle of a single room.
    public void CellSpawn()
    {
        int i = Random.Range(0, availableRooms.Count);
        var cellSpawnPoint = availableRooms[i];
        var npcSpawnPoint = availableRooms[i];
        availableRooms.RemoveAt(i);
        Instantiate(cell, cellSpawnPoint.center, Quaternion.identity);
        Instantiate(npc, npcSpawnPoint.center, Quaternion.identity);
        
    }

    //Spawns a potion prefab on random tiles.
    public void PotionSpawn()
    {
        foreach (var room in availableRooms)
        {
            var spawnpoint = room;
            Instantiate(potion, spawnpoint.center, Quaternion.identity);
        }
    }

    //Spawns a chest prefab on random tiles.
    public void ChestSpawn()
    {
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var floorTile in randomFloorTilesList)
        {
            if (Random.Range(0, 200) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                Instantiate(chest, new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }

    //Spawns decorative prefabs from an array on random tiles.
    public void DecorationsSpawn()
    {
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var floorTile in randomFloorTilesList)
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

    //Spawns decorative prefabs from an array on random tiles.
    public void TorchesSpawn()
    {
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var floorTile in randomFloorTilesList)
        {
            if (Random.Range(0, 150) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                int randomIndex = Random.Range(0, torches.Length);
                Instantiate(torches[randomIndex], new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
    }

    //Spawns a trap prefab on a random tile.
    public void TrapSpawn()
    {
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var floorTile in randomFloorTilesList)
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
    
    //Spawn an enemy prefab in the center of a random room.
    public void EnemySpawnCenter()
    {
        foreach (var room in availableRooms)
        {
            var spawnpoint = room;
            int randomIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randomIndex], spawnpoint.center, Quaternion.identity);
        }

    }

    //Spawns an enemy prefab from an array on a random tile.
    public void EnemySpawnRandom()
    {
        List<Vector2Int> randomFloorTilesList = dungeonGenerator.globalFloorList.ToList();
        foreach (var floorTile in randomFloorTilesList)    
        {
            if (Random.Range(0, 80) == 1)
            {
                int i = Random.Range(0, randomFloorTilesList.Count);
                Vector2Int spawnpoint = randomFloorTilesList[i];
                int randomIndex = Random.Range(0, enemyPrefab.Length);
                Instantiate(enemyPrefab[randomIndex], new Vector3(spawnpoint.x, spawnpoint.y, 0), Quaternion.identity);
            }
        }
        
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
