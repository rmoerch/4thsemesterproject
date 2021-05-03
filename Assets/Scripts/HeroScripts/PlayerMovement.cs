using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public Rigidbody2D playerRb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {

    }
    void Update()
    {
        //Read the movement keys (WSAD) / Arrows
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Read the mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 normLookDir = (mousePos - playerRb.position).normalized;
        animator.SetFloat("Horizontal", normLookDir.x);
        animator.SetFloat("Vertical", normLookDir.y);
    }


    void FixedUpdate()
    {
        //If the move is diagonal, lower the movement so the walking speed would stay the same.
        if (movement.x == 1 && movement.y == 1) { movement.x = 0.707f; movement.y = 0.707f; }
        else if (movement.x == 1 && movement.y == -1) { movement.x = 0.707f; movement.y = -0.707f; }
        else if (movement.x == -1 && movement.y == 1) { movement.x = -0.707f; movement.y = 0.707f; }
        else if (movement.x == -1 && movement.y == -1) { movement.x = -0.707f; movement.y = -0.707f; }

        //Move the rigid body
        playerRb.position = playerRb.position + movement * moveSpeed * Time.fixedDeltaTime;

        //Vector3 lookDir = new Vector3(transform.position.x - mousePos.x, transform.position.y - mousePos.y, 0);
        //rb.transform.LookAt(lookDir);
    }
}
