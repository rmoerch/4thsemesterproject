using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot1 : MonoBehaviour
{
    private Inventory1 inventory1;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        inventory1 = GameObject.FindGameObjectWithTag("Hero").GetComponent<Inventory1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory1.isFull[i] = false;
        }
    }
}
