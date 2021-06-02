using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIScript : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 target;
    public Animator animator;

    [SerializeField]
    public float speed;
    //The distance at what enemy will stop, when too close / too far
    [SerializeField]
    private float minimumEnemyProximity;
    [SerializeField]
    private float maximumEnemyProximity;


    Path path;
    float nextWaypointDistance = 1;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Vector2 direction = Vector2.zero;

    Seeker seeker;
    Vector2 enemyPosition;
    Rigidbody2D enemyRb;



    private void Start()
    {
        UpdateTarget();
        seeker = GetComponent<Seeker>();
        enemyPosition = GetComponent<CircleCollider2D>().bounds.center;
        enemyRb = GetComponent<Rigidbody2D>();
        
        
        //Invoke function every .5 a second
        InvokeRepeating("UpdatePath", 0f, .2f);
    }

    private void UpdateTarget()
    {
        targetTransform = GameObject.FindGameObjectsWithTag("Hero")[0].transform;

        //The target vector equals vector.y - 1, so the enemy would go to hero legs (legs are actual center of the hero), not center
        target = targetTransform.position;
        target.y -= 1;
    }

    //Generate a new path function
    private void UpdatePath()
    {
        UpdateTarget();
        enemyPosition = GetComponent<CircleCollider2D>().bounds.center;

        //If target is further then the disableEnemyDistance, make sure to check that it hasn't reachedEndOfPath
        if (minimumEnemyProximity < Vector2.Distance(enemyPosition, target ) && maximumEnemyProximity > Vector2.Distance(enemyPosition, target))
        {
            reachedEndOfPath = false;
        }

        if (reachedEndOfPath){
            return;
        }
        else {
            if (seeker.IsDone())
            {
                seeker.StartPath(enemyPosition, target, OnPathComplete);
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

        Vector2 moveDirection = enemyRb.velocity.normalized;
        //Send information to animator in Unity
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
        animator.SetFloat("Direction", lastDirection);


        //Stop the enemy from moving if: minimum/maximum EnemyProximity has been reached, or the last Waypoint has been reached
        if (minimumEnemyProximity >= Vector2.Distance(enemyPosition, target) || maximumEnemyProximity <= Vector2.Distance(enemyPosition, target) || currentWaypoint >= path.vectorPath.Count)
        {
            //Stop the movement of enemy rigidBody
            enemyRb.velocity = Vector2.zero;

            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        //Update a Vector2 containg a direction of current move.
        direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyPosition).normalized;

        //Add a force to move a rigidBody
        Vector2 force = direction * speed * Time.deltaTime;
        enemyRb.AddForce(force);

        float distance = Vector2.Distance(enemyPosition, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
