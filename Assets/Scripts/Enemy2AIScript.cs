using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy2AIScript : MonoBehaviour
{
    public Transform target;
    public Animator animator;

    public float nextWaypointDistance = 1;
    [SerializeField]
    public float speed;
    //The distance at what enemy will stop, when too close / too far
    [SerializeField]
    public float minimumEnemyProximity;
    [SerializeField]
    public float maximumEnemyProximity;

    [SerializeField]
    private int jumpCooldownTime;
    [SerializeField]
    private float jumpProximity;

    Path path;
    int currentWaypoint = 0;
    int jumpCooldown = 0;
    bool reachedEndOfPath = false;
    Vector2 direction = Vector2.zero;

    Seeker seeker;
    Rigidbody2D rb;



    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        
        //Invoke function every .5 a second
        InvokeRepeating("UpdatePath", 0f, .2f);
    }

    //Generate a new path function
    void UpdatePath()
    {
        //If target is further then the disableEnemyDistance, make sure to check that it hasn't reachedEndOfPath
        if (minimumEnemyProximity < Vector2.Distance(rb.position, target.position ) && maximumEnemyProximity > Vector2.Distance(rb.position, target.position))
        {
            reachedEndOfPath = false;
        }

        if (reachedEndOfPath){
            return;
        }
        else {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }

    //When Path is generated - execute this
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }



    void FixedUpdate()
    {
        if (path == null) return;

        float lastDirection = 0f; // 0 - up, 1 - up-right, 2 - right, 3 - down-right, 4 - down, 5 - down-left, 6 - left, 7 - up-left
        //Save last known walking direction (needed for idle positioning)
        if (direction.y > 0 && direction.x == 0) { lastDirection = 0f; }
        else if (direction.y > 0 && direction.x > 0) { lastDirection = 1f; }
        else if (direction.y == 0 && direction.x > 0) { lastDirection = 2f; }
        else if (direction.y < 0 && direction.x > 0) { lastDirection = 3f; }
        else if (direction.y < 0 && direction.x == 0) { lastDirection = 4f; }
        else if (direction.y < 0 && direction.x < 0) { lastDirection = 5f; }
        else if (direction.y == 0 && direction.x < 0) { lastDirection = 6f; }
        else if (direction.y < 0 && direction.x < 0) { lastDirection = 7f; }

        Vector2 moveDirection = rb.velocity.normalized;
        //Send information to animator in Unity
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        animator.SetFloat("Direction", lastDirection);


        //Stop the enemy from moving if: minimum/maximum EnemyProximity has been reached, or the last Waypoint has been reached
        if (minimumEnemyProximity >= Vector2.Distance(rb.position, target.position) || maximumEnemyProximity <= Vector2.Distance(rb.position, target.position) || currentWaypoint >= path.vectorPath.Count)
        {
            //Stop the movement of enemy rigidBody
            rb.velocity = Vector2.zero;

            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        //Update a Vector2 containg a direction of current move
        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        //Add a force to move a rigidBody
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        //If the target is in jumpProximity and coolDown is off, add a lot of force for a jump
        if (Vector2.Distance(rb.position, target.position) <= jumpProximity && jumpCooldown <= 0)
        {
            jumpCooldown = jumpCooldownTime;
            Vector2 jumpDirection = (Vector2)target.position - rb.position;
            force = jumpDirection * speed * 10 * Time.deltaTime;
            rb.AddForce(force);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if (jumpCooldown > 0) jumpCooldown--;
    }
}
