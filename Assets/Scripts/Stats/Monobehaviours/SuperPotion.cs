using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPotion : MonoBehaviour
{
    [SerializeField]
    float invincibilityPeriod;

    private PlayerHP hpManager;

    void Start()
    {
        hpManager = GameObject.FindGameObjectWithTag("Hero").GetComponent<PlayerHP>();
    }

    public void Use()
    {
        StartCoroutine("DisableScript");
        Destroy(gameObject);
    }

    IEnumerator DisableScript()
    {
        GetComponent<PlayerHP>().enabled = false;

        yield return new WaitForSeconds(invincibilityPeriod);

        GetComponent<PlayerHP>().enabled = true;
    }
}
