using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySlot : MonoBehaviour
{
    private KeyManager keyHolder;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        keyHolder = GameObject.FindGameObjectWithTag("Hero").GetComponent<KeyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount <= 0)
        {
            keyHolder.isFull[i] = false;
        }
    }
}
