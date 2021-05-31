using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    [SerializeField]
    int ammoRestore;
    
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    public void Use()
    {
        //gameObject.GetComponentInParent<GunAmmo>().PickUpAmmo(ammoRestore);
        Destroy(gameObject);
    }

}
