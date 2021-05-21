using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    int maxHP = 100;
    [SerializeField]
    HealthBarScript healthBar;
    int hP;

    // Start is called before the first frame update
    void Start()
    {
        hP = maxHP;
        healthBar.StartHealthBar(maxHP, hP);
    }

    public void LoseHP(int damage)
    {
        hP -= damage;
        healthBar.SetHealth(hP);
    }

    private void Update()
    {
        if(hP <= 0) { GameObject.Destroy(gameObject); }
    }
}
