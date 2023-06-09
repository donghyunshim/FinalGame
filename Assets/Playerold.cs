using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float moveSpeed = 7.5f;
    

    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 movement;
    Vector2 mousePos;
    Vector3 slideDir;
    private float nextUpdate = 0;
    private float newupdatebul = 1f;
    private float slideSpeed;
    public float slideSpeedSlowdown = .95f;

    public Camera cam;

    public State state;
    public enum State
    {
        Normal,
        DodgeRollSliding
    }

    //health

    public int PlayermaxHealth = 6;
    public int PlayercurHealth;

    public HealthBar healthbar;
    void Start()
    {
        state = State.Normal;

        PlayercurHealth = PlayermaxHealth;
        healthbar.SetMaxHealth(PlayermaxHealth);

    }

    //Audio
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // not a good place to do physics because of framerate change

        //input
        switch (state) {
        case State.Normal:
            animator.SetFloat("Roll", 0);
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if (Input.GetButtonDown("Fire2"))
            {
                Roll();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                    TakeDamage(1);
            }
            break;
        case State.DodgeRollSliding:
                animator.SetFloat("Roll", 1);
                HandleDodgeRollSliding();
                break;
            
        }
    }

    void FixedUpdate()
    {
        // Good place to do Physics since its updeated on a fixed timer (50 times a second (Changeable) )

        //Movement
        switch (state)
        {
            case State.Normal:
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                slideDir = new Vector2(movement.x, movement.y).normalized;
                transform.position += slideDir * moveSpeed * Time.fixedDeltaTime;
                break;
            case State.DodgeRollSliding:
                break;
        }

    }

    void Roll()
    {
        audioManager.PlaySFXq(audioManager.dodge);
        state = State.DodgeRollSliding;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        slideDir = new Vector2(movement.x, movement.y).normalized;
        slideSpeed = 12f;

    }

    void HandleDodgeRollSliding()
    {
        transform.position += slideDir * slideSpeed * Time.deltaTime;

        if (slideSpeed > 6f)
        {
            slideSpeed -= slideSpeed * slideSpeedSlowdown * Time.deltaTime;
        }
        else if (3f <= slideSpeed && slideSpeed <= 6f)
        {
            slideSpeed -= slideSpeed * (slideSpeedSlowdown + 2f) * Time.deltaTime;
        }
        else if (slideSpeed < 3f)
        {
            state = State.Normal;
        }
    }

    public void TakeDamage(int damage)
    {
        PlayercurHealth -= damage;
        healthbar.SetHealth(PlayercurHealth);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyBullet" && Time.time >= nextUpdate && state != State.DodgeRollSliding)
        {
            nextUpdate = Time.time + .5f;
            TakeDamage(1);
        }
        else if (col.tag == "Runner" && Time.time >= nextUpdate && state != State.DodgeRollSliding)
        {
            nextUpdate = Time.time + newupdatebul;
            TakeDamage(1);
        }
    }
}
