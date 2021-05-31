using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes
    [SerializeField]
    float healthRestore;

    private Transform player;

    private void Start()
    {
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponentInParent<PlayerHP>().GetHP(20);
            Destroy(gameObject);
        }
       
    }
    
}
