using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Spawner : MonoBehaviour
{
    public RoomFirstDungeonGenerator dungeonGenerator;
    public GameObject heroPrefab;
    //public List<GameObject> objectsToSpawn;
    

    void Start()
    {
        PlayerSpawn();
    }

    public void PlayerSpawn()
    {
        var vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0].GetComponent<CinemachineVirtualCamera>();
        DestroyObjects();

        dungeonGenerator.GetComponent<RoomFirstDungeonGenerator>();

        //Spawn a hero in the center of a random room.
        List<BoundsInt> availableRooms = new List<BoundsInt>();
        foreach (var room in dungeonGenerator.roomsList)
        {
            availableRooms.Add(room);
        }
        Debug.Log("Rooms: " + availableRooms.Count);
        int i = Random.Range(0, availableRooms.Count);
        var spawnPoint = availableRooms[i];

        GameObject heroClone = Instantiate(heroPrefab, spawnPoint.center, Quaternion.identity);
        vCam.Follow = heroClone.transform;
        
    }


    private void DestroyObjects()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Hero"))
        {
            Destroy(o);
        }
    }

}
