using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroRoomSpawner : MonoBehaviour
{
    private GameManager gM;
    private GameObject heroClone;
    public GameObject introPortal;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameManager.instance;
        PlayerSpawn();
        IntroPortalSpawn();
    }

    public void PlayerSpawn()
    {
        var vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0].GetComponent<CinemachineVirtualCamera>();
        DestroyObjects();
        heroClone = Instantiate(gM.heroPrefab, new Vector3(-1, 1, 0), Quaternion.identity);
        vCam.Follow = heroClone.transform;
        heroClone.GetComponent<PlayerMovement>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        heroClone.GetComponentInChildren<BlasterRotation>().cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void IntroPortalSpawn()
    {
        Instantiate(introPortal, new Vector3(0.5f, 3, 0), Quaternion.identity);
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
