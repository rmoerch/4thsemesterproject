using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    float healthRestore;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    public void Use()
    {
        gameObject.GetComponentInParent<PlayerHP>().GetHP(healthRestore);
        Destroy(gameObject);
    }

}
