using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    static CoroutineManager instance;
    public static CoroutineManager Instance { get { return instance; } }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
<<<<<<< Updated upstream:Assets/Scripts/CorutineManager.cs
            instance = this;
=======
            collision.gameObject.GetComponentInParent<PlayerHP>().LoseHP(10);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<EnemyHP>().LoseHP(10);
>>>>>>> Stashed changes:Assets/WIP/Fuck/Spikes.cs
        }
    }
}