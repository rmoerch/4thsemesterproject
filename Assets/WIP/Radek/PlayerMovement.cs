using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;
    public float direction = 0f; // 0 - down, 1 - left, 2 - up, 3 - right

    // Update is called once per frame
    void Update()
    {
        //Read movement keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Save last known walking direction (needed for idle positioning)
        if(movement.y > 0 && movement.x == 0) { direction = 2f; }
        else if(movement.y < 0 && movement.x == 0) { direction = 0f; }
        else if(movement.x > 0) { direction = 3f; }
        else if(movement.x < 0) { direction = 1f; }

        //Send information to animator in Unity
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Direction", direction);
    }

    void FixedUpdate()
    {
        //If the move is diagonal, lower the movement so the walking speed would stay the same.
        if(movement.x == 1 && movement.y == 1) { movement.x = 0.707f; movement.y = 0.707f; }
        else if (movement.x == 1 && movement.y == -1) { movement.x = 0.707f; movement.y = -0.707f; }
        else if (movement.x == -1 && movement.y == 1) { movement.x = -0.707f; movement.y = 0.707f; }
        else if (movement.x == -1 && movement.y == -1) { movement.x = -0.707f; movement.y = -0.707f; }

        //Move the rigid body
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
