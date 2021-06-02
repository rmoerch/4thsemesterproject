using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    public void Use()
    {
        player.GetComponentInChildren<GunAmmo>().AmmoRestore();
        Destroy(gameObject);
    }

}
