using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class BossAIScript : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;

    public Transform targetTransform;
    private Vector3 target;
    public Animator animator;

    [SerializeField]
    public float speed;
    [SerializeField]
    public float nextWaypointDistance;
    //The distance at what enemy will stop, when too close
    [SerializeField]
    private float minimumEnemyProximity;


    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Vector2 direction = Vector2.zero;

    Seeker seeker;
    Vector2 enemyPosition;
    Rigidbody2D enemyRb;

    int attackMode;
    int modeTimer;

    int shootTimer = 0;
    bool modeActionExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        SwitchAttackMode();

        seeker = GetComponent<Seeker>();
        enemyPosition = GetComponent<CircleCollider2D>().bounds.center;
        enemyRb = gameObject.GetComponent<Rigidbody2D>();


        //Invoke function every .5 a second
        InvokeRepeating("UpdatePath", 0f, .2f);
    }

    void FixedUpdate()
    {
        switch (attackMode)
        {
            case 1:
                if (modeTimer <= 0) { SwitchAttackMode(); break; }
                UpdateTarget(1);

                shootTimer++;
                Walk();
                if (shootTimer >= 120)
                {
                    WalkShoot();
                    shootTimer = 0;
                }
                break;

            case 2:
                if (modeTimer <= 0) { SwitchAttackMode(); break; }
                UpdateTarget(2);

                if (!reachedEndOfPath) Walk();
                if (reachedEndOfPath)
                {
                    if (!modeActionExecuted) 
                    { 
                        modeActionExecuted = true;

                        //Make sure the boss is facing down
                        animator.SetFloat("Horizontal", 0);
                        animator.SetFloat("Vertical", (-1));
                        BulletHell(1); 
                    }
                }
                break;

            case 3:
                if (modeTimer <= 0) { SwitchAttackMode(); break; }
                UpdateTarget(2);

                if(!reachedEndOfPath) Walk();
                if (reachedEndOfPath)
                {
                    if (!modeActionExecuted) 
                    {
                        modeActionExecuted = true;

                        //Make sure the boss is facing down
                        animator.SetFloat("Horizontal", 0);
                        animator.SetFloat("Vertical", (-1));
                        BulletHell(2); 
                    }
                }
                break;

            default: break;
        }

        modeTimer--;
    }

    private void UpdateTarget(int i)
    {
        switch (i)
        {
            //Hero
            case 1:
                targetTransform = GameObject.FindGameObjectsWithTag("Hero")[0].transform;

                //The target vector equals vector.y - 1, so the enemy would go to hero legs (legs are actual center of the hero), not center
                target = targetTransform.position;
                target.y -= 1;
                break;

            //Middle
            case 2:
                target = new Vector3(0, 0, 0);
                break;
        }
        
    }

    //Generate a new path function
    private void UpdatePath()
    {
        enemyPosition = GetComponent<CircleCollider2D>().bounds.center;

        //If target is further then the disableEnemyDistance, make sure to check that it hasn't reachedEndOfPath
        if (minimumEnemyProximity < Vector2.Distance(enemyPosition, target))
        {
            reachedEndOfPath = false;
        }

        if (reachedEndOfPath)
        {
            return;
        }
        else
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(enemyPosition, target, OnPathComplete);
            }
        }
    }

    //When Path is generated - execute this
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void SwitchAttackMode()
    {
        //Reset all mode variables
        shootTimer = 0;
        modeActionExecuted = false;

        attackMode = UnityEngine.Random.Range(1, 4);

        modeTimer = UnityEngine.Random.Range(1500, 3000);
    }


    private void WalkShoot()
    {
        //Shoot 5 shots at the same time
        for (int i = (-2); i <= 2; i++)
        {
            Vector2 firePointVector = ((Vector2)targetTransform.position - enemyRb.position).normalized;
            float angleInDegrees = (Mathf.Atan2(firePointVector.y, firePointVector.x) * Mathf.Rad2Deg - 90f);

            //with every shot, rotate the shot by ...
            angleInDegrees += i * 3;

            //An angle in deegrees to target
            Quaternion angle = new Quaternion();
            angle.eulerAngles = new Vector3(0f, 0f, angleInDegrees);

            //Point 0 of bullet instantiation
            Vector3 position = enemyRb.position;

            //Instantiate a bullet, get rigidBody of the bullet and addForce in the angle direction
            GameObject bullet = Instantiate(bulletPrefab, position, angle);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Vector3 firePoint = angle * Vector3.up;

            rb.AddForce(firePoint * 15, ForceMode2D.Impulse);
        }
    }

    private void Walk()
    {
        if (path == null) return;

        Vector2 moveDirection = enemyRb.velocity.normalized;
        //Send information to animator in Unity
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);


        //Stop the enemy from moving if: minimum EnemyProximity has been reached, or the last Waypoint has been reached
        if (minimumEnemyProximity >= Vector2.Distance(enemyPosition, target) || currentWaypoint >= path.vectorPath.Count)
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
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    private void BulletHell(int m)
    {
        switch (m)
        {
            case 1:
                for (int a = 36; a >= 0; a--)
                {
                    StartCoroutine(BulletHellCorutine(a));
                }
                break;

            case 2:
                for (int a = 280; a >= 0; a--)
                {
                    StartCoroutine(BulletHellCorutine2(a));
                }
                break;
        }
    }
    private IEnumerator BulletHellCorutine(int iteration)
    {
        yield return new WaitForSeconds(((float)Math.Abs(iteration) / 2));
        for (int i = 53; i >= 0; i--)
        {
            int angleInDegree = (i * 6) + (iteration * 10) + 195;

            //Point 0 of bullet instantiation
            Vector3 position = (Vector3)gameObject.GetComponent<Rigidbody2D>().position;

            //An angle in deegrees = i * 6
            Quaternion angle = new Quaternion();
            angle.eulerAngles = new Vector3(0f, 0f, angleInDegree);

            //Instantiate a bullet, get rigidBody of the bullet and addForce in the angle direction
            GameObject bullet = Instantiate(bulletPrefab, position, angle);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            //Vector3 firePoint is an Vector3 pointing in the direction of angle
            Vector3 firePoint = angle * Vector3.up;

            rb.AddForce(firePoint * 5, ForceMode2D.Impulse);

            //Finish the mode sequence on the last shot
            if (iteration == 36 && i == 0) { modeTimer = 100; }
        }
    }

    private IEnumerator BulletHellCorutine2(float iteration)
    {
        yield return new WaitForSeconds((Math.Abs(iteration) / 10));

        //Calculate a sinus from the iteration number - makes a nice transition between the rotation direction :)
        float rotation = (float)Math.Sin(iteration * 1.285f / 45f);
        for (int i = 6; i >= 0; i--)
        {
            float angleInDegree = (i * 60) + (rotation * 180) + 195;

            //Point 0 of bullet instantiation
            Vector3 position = (Vector3)gameObject.GetComponent<Rigidbody2D>().position;

            //An angle in deegrees = i * 6
            Quaternion angle = new Quaternion();
            angle.eulerAngles = new Vector3(0f, 0f, angleInDegree);

            //Instantiate a bullet, get rigidBody of the bullet and addForce in the angle direction
            GameObject bullet = Instantiate(bulletPrefab, position, angle);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            //Vector3 firePoint is an Vector3 pointing in the direction of angle
            Vector3 firePoint = angle * Vector3.up;

            rb.AddForce(firePoint * 5, ForceMode2D.Impulse);

            //Finish the mode sequence on the last shot
            if(iteration == 280 && i == 0) { modeTimer = 100; }
        }
    }

}
