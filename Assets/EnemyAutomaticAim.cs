using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class EnemyAutomaticAim : MonoBehaviour
{
    //target to aim at
    public Transform Target;
    public Rigidbody2D rb;
    Vector2 movement;
    //enemy move speed
    public float moveSpeed = 4f;

    //firing location
    public Transform FirePoint;
    public GameObject bulletPrefab;

    //speed of bullet
    public float bulletforce = 4.4f;
    public float nextUpdate = 0;
    public float newupdatebul = 0.5f;

    //parent child objects
    public GameObject MyWeapon;
    public GameObject Parent;
    //private int layerNumber = 9;

    //layer mask is for circleray basically only targets the layermask
    public LayerMask layerMask;
    //layers used for enemy sight
    private int PlayerLayer, ObstacleLayer;

    public RaycastHit2D hitInfo;
    //pull in parent class to edit
    public EnemyAI parent;

    public int clip = 12;


    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Playertag");
        Target = go.transform;
        parent = Parent.GetComponent<EnemyAI>();
        //layerMask = 1 << layerNumber;
        PlayerLayer = LayerMask.NameToLayer("Player");
        ObstacleLayer = LayerMask.NameToLayer("obstacles");


    }
    // Update is called once per frame
    void Update()
    {
 
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Time.time + newupdatebul;
            if (hitInfo.transform.gameObject.layer == PlayerLayer)
            {
                if (clip > 0)
                {
                    clip--;
                    Shoot();
                }
                else
                {
                    nextUpdate = Time.time + 1.5f;
                    clip = 12;
                }
            }
        }
        {
            
        }
        
        Vector2 Targetvec = new Vector2(Target.position.x, Target.position.y);
        Vector2 LookDir = Targetvec - rb.position;
        hitInfo = Physics2D.CircleCast(FirePoint.position, 0.12f, LookDir, 50, layerMask);

        if (hitInfo.transform.gameObject.layer == PlayerLayer)
        {
            //Debug.Log(hitInfo.transform.name);
            parent.nextWaypointDistance = 6;

        }
        else
        {
            //Debug.Log("Obstacle HIt" + hitInfo.transform.name);
            parent.nextWaypointDistance = 1;
        }

    }
    void FixedUpdate()
    {
        Vector2 Targetvec = new Vector2(Target.position.x, Target.position.y);
        Vector2 LookDir = Targetvec - rb.position;
        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        rb.rotation = angle;
    }

    void Shoot()
    {
       
        audioManager.PlaySFXq(audioManager.automaticsound);
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(FirePoint.up * bulletforce, ForceMode2D.Impulse);
    }
}
