using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomSpawner : MonoBehaviour
{
    private GameManager gM;
    private GameObject heroClone;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
        PlayerSpawn();
    }

    public void PlayerSpawn()
    {
        var vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0].GetComponent<CinemachineVirtualCamera>();
        DestroyObjects();
        heroClone = Instantiate(gM.heroPrefab, new Vector3(0,0,0), Quaternion.identity);
        vCam.Follow = heroClone.transform;
        heroClone.GetComponent<PlayerMovement>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        heroClone.GetComponentInChildren<BlasterRotation>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
