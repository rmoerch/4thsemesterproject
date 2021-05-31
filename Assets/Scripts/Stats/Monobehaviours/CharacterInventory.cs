using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    #region Variable Declarations
    public static CharacterInventory instance;


    #endregion

    #region Initializations
    private void Start()
    {
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
        }
>>>>>>> Stashed changes:Assets/WIP/Fuck/Spikes.cs
    }
    #endregion

    
}
