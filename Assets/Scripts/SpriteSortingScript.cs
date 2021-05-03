using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteSortingScript : MonoBehaviour
{
    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    public float offset = 0;
    [SerializeField]
    private bool staticObject = true;

    private Renderer myRenderer;
    void Start()
    {
        myRenderer = gameObject.GetComponent<Renderer>();
        UpdateSorting();

        if(staticObject == false) { InvokeRepeating("UpdateSorting", 0f, .1f); }
    }

    private void UpdateSorting()
    {
        //Sets the sorting order to sortingOrderBase - position of the the sprite(*10 so the offset could be more precise) - offset
        //Check if the object is a tileMap
        //Tilemap object must have the center on the bottom
        if (gameObject.CompareTag("TileMapObject"))
        {
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y*10 - offset);
        }
        else
        {
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y*10 - offset);
        }
        
        
    }
}
