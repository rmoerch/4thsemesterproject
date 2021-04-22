using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointRotation : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Transform parent;

    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

 
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;
    }


    void FixedUpdate()
    {
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //rb.transform.SetParent(parent);
        rb.transform.SetParent(parent.transform);
        rb.transform.localPosition = parent.localPosition * moveSpeed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //float angleRad = Mathf.Atan2(lookDir.y, lookDir.x);
        
        rb.rotation = angle;

        //rb.SetRotation(angle);
        //rb.gameObject.LookAt(new Vector2(lookDir.x, lookDir.y));
    }
}
