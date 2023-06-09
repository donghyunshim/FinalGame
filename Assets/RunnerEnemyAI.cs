using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
//using UnityEditor.PackageManager;

public class RunnerEnemyAI : MonoBehaviour
{
    //target to move to
    public Transform target;
    //speed to move
    public float speed = 340f;
    //the distance to stop between it and target
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    //child script
    //public EnemyAim child;
    public Player player;

    //layers used for enemy sight
    private int PlayerLayer, ObstacleLayer;
 
    public float EnemyHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Playertag");
        target = go.transform;
        player = go.GetComponent<Player>();
        //state = State.Normal;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = true;
        InvokeRepeating("UpdatePath", 0f, .5f);
        //seeker.StartPath(rb.position, target.position, OnPathComplete);

        PlayerLayer = LayerMask.NameToLayer("Player");
        ObstacleLayer = LayerMask.NameToLayer("obstacles");

 

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;

        }
        else
        {
            reachedEndOfPath = false;
        }


        Vector3 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        //transform.position += direction * speed * Time.deltaTime;
        //rb.velocity = direction;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        //float distancetoplayer = Vector3.Distance(rb.position, player.rb.position);
 }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBullet")
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
