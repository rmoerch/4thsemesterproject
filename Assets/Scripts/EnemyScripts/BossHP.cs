using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    int maxHP = 100;
    [SerializeField]
    HealthBarScript healthBar;
    int hP;
    public GameObject portal;

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
        if (hP <= 0) 
        {
            Instantiate(portal, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject.Destroy(gameObject); 
        }
    }
}
