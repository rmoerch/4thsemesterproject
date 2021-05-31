using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
<<<<<<< Updated upstream
    void OnTriggerEnter2D(Collider2D collision)
=======
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    [SerializeField]
    float healthRestore;

    private Transform player;

    private void Start()
>>>>>>> Stashed changes
    {
        player = GameObject.FindGameObjectWithTag("Hero").transform;
    }

    public void Use()
    {
        gameObject.GetComponentInParent<PlayerHP>().GetHP(healthRestore);
        Destroy(gameObject);
    }

}
