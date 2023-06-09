using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;
//using UnityEditor.PackageManager;

public class EnemyAutomaticAI : MonoBehaviour
{
    //target to move to
    public Transform target;
    //speed to move
    public float speed = 150f;
    //the distance to stop between it and target
    public float nextWaypointDistance = 6f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    //child script
    public EnemyAutomaticAim child;
    public Player player;

    //layers used for enemy sight
    private int PlayerLayer, ObstacleLayer;

    //states for seeking and dodging after finding
    private State state;
    private enum State
    {
        Normal,
        Dodging
    }

    //dodging stats
    public float Dspeed;
    public float Drange;
    public float DmaxDistance;
    Vector2 dodgewaypoint1;
    Vector2 dodgewaypoint2;

    public float EnemyHealth = 3;

    //avoiding obstacle collision
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Playertag");
        target = go.transform;
        player = go.GetComponent<Player>();
        state = State.Normal;
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
        switch (state)
        {
            case State.Normal:
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
                float distancetoplayer = Vector3.Distance(rb.position, player.rb.position);
                if (nextWaypointDistance == 6 && child.hitInfo.transform.gameObject.layer == PlayerLayer && distancetoplayer < 7)
                {
                    //rb.velocity = Vector3.zero;
                    Debug.Log("Dodging");
                    Dodge();
                    state = State.Dodging;
                }
                break;
            case State.Dodging:

                //transform.position = Vector2.MoveTowards(transform.position, dodgewaypoint, Dspeed * Time.deltaTime);
                Vector3 direction2 = (dodgewaypoint1 - dodgewaypoint2).normalized;
                Vector2 force2 = direction2 * 150 * Time.deltaTime;
                //rb.velocity = direction2;
                rb.AddForce(force2);
                if (Vector2.Distance(dodgewaypoint2, dodgewaypoint1) < Drange)
                {
                    Dodge();
                }
                //add player pos
                float distancetoplayer2 = Vector3.Distance(rb.position, player.rb.position);
                if (child.hitInfo.transform.gameObject.layer != PlayerLayer || distancetoplayer2 > 9)
                {
                    //rb.velocity = Vector3.zero;
                    Debug.Log("NORMAL");
                    state = State.Normal;
                }
                break;
        }


    }

    void Dodge()
    {
        state = State.Dodging;
        dodgewaypoint1 = new Vector2(Random.Range(-DmaxDistance, DmaxDistance), Random.Range(-DmaxDistance, DmaxDistance));
        dodgewaypoint2 = new Vector2(Random.Range(-DmaxDistance, DmaxDistance), Random.Range(-DmaxDistance, DmaxDistance));
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
