using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 7f;
    

    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 movement;
    Vector2 mousePos;
    Vector3 slideDir;

    private float slideSpeed;
    public float slideSpeedSlowdown = .95f;

    public Camera cam;

    private State state;
    private enum State
    {
        Normal,
        DodgeRollSliding
    }

    void Start()
    {
        state = State.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        // not a good place to do physics because of framerate change

        //input
        switch (state) {
        case State.Normal:
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", mousePos.x);
            animator.SetFloat("Vertical", mousePos.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            if (Input.GetButtonDown("Fire2"))
            {
                Roll();
            }
            break;
        case State.DodgeRollSliding:
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
        state = State.DodgeRollSliding;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        slideDir = new Vector2(movement.x, movement.y).normalized;
        slideSpeed = 9f;

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
}
