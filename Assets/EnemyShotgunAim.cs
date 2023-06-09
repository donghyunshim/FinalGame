using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyShotgunAim : MonoBehaviour
{
    //target to aim at
    public Transform Target;
    public Rigidbody2D rb;
    Vector2 movement;
    //enemy move speed
    public float moveSpeed = 4f;

    //firing location
    public Transform FirePoint1;
    public Transform FirePoint2;
    public Transform FirePoint3;
    public Transform FirePoint4;
    public Transform FirePoint5;
    public GameObject bulletPrefab;

    //speed of bullet
    public float bulletforce = 4.4f;
    private float nextUpdate = 0;
    public float newupdatebul = 1.5f;

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

    //Audio
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
            //Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + newupdatebul;
            // Call your function
            if (hitInfo.transform.gameObject.layer == PlayerLayer)
            {
                Shoot();
            }
        }
        Vector2 Targetvec = new Vector2(Target.position.x, Target.position.y);
        Vector2 LookDir = Targetvec - rb.position;
        hitInfo = Physics2D.CircleCast(FirePoint1.position, 0.12f, LookDir, 50, layerMask);

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
        audioManager.PlaySFX(audioManager.shotgunsound);
        GameObject bullet1 = Instantiate(bulletPrefab, FirePoint1.position, FirePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, FirePoint2.position, FirePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, FirePoint3.position, FirePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, FirePoint4.position, FirePoint4.rotation);
        GameObject bullet5 = Instantiate(bulletPrefab, FirePoint5.position, FirePoint5.rotation);

        //access bullet and get its rigid body
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();

        //use rigidbody to addforce at firepoint using bulletforce in impulse style
        rb1.AddForce(FirePoint1.up * bulletforce, ForceMode2D.Impulse);
        rb2.AddForce(FirePoint2.up * bulletforce, ForceMode2D.Impulse);
        rb3.AddForce(FirePoint3.up * bulletforce, ForceMode2D.Impulse);
        rb4.AddForce(FirePoint4.up * bulletforce, ForceMode2D.Impulse);
        rb5.AddForce(FirePoint5.up * bulletforce, ForceMode2D.Impulse);
    }
}
