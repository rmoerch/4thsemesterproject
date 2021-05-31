using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< Updated upstream:Assets/Scripts/CorutineManager.cs
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
=======
<<<<<<< Updated upstream:Assets/Scripts/Stats/Monobehaviours/CharacterInventory.cs
        instance = this;
=======
        if (collision.gameObject.CompareTag("Hero"))
        {
            collision.gameObject.GetComponentInParent<PlayerHP>().LoseHP(10);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<EnemyHP>().LoseHP(10);

            collision.gameObject.GetComponentInParent<PlayerHP>().LoseHP(20);
>>>>>>> Stashed changes:Assets/WIP/Fuck/Spikes.cs
        }
>>>>>>> Stashed changes:Assets/WIP/Fuck/Spikes.cs
    }
}
