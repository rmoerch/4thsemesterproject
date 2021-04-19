using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrackeysMoving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;
    //Vector3 mousePos3;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos3 = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = mousePos - rb.position;
        Vector2 normLookDir = Vector2.ClampMagnitude(lookDir, 1);
        Debug.Log(normLookDir);
        animator.SetFloat("Horizontal", normLookDir.x);
        animator.SetFloat("Vertical", normLookDir.y);
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //Vector3 lookDir = new Vector3(transform.position.x - mousePos.x, transform.position.y - mousePos.y, 0);
        //rb.transform.LookAt(lookDir);
    }
}
