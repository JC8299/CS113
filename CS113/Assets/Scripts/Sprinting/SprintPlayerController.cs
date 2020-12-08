using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SprintPlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float moveAccel;     //accel rate
    public float accelLimit;
    public bool bFinished;      //crossed finish line

    private Rigidbody2D rb;
    private Animator animator;
    private bool bMoveKeyPressed;
    private bool bMovement;
    private float timeNow;
    private float timeLastPressed;
    private float horizontalAccel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timeNow = Time.time;
        timeLastPressed = Time.time;
        bMovement = false;
        bMoveKeyPressed = false;
        bFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bFinished)
        {
            if ((Keyboard.current.xKey.isPressed && !bMoveKeyPressed) ||
                (Keyboard.current.cKey.isPressed && bMoveKeyPressed))
            {
                animator.SetBool("Running", true);
                if (bMoveKeyPressed) bMoveKeyPressed = false;
                else bMoveKeyPressed = true;

                bMovement = true;
                timeNow = Time.time;
                horizontalAccel = 1 / (timeNow - timeLastPressed);
                timeLastPressed = timeNow;
            }
            else
            {
                animator.SetBool("Running", false);
                animator.SetTrigger("Fail");
            }
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetTrigger("Fail");
        }
        
    }

    void FixedUpdate()
    {
        if (!bFinished)
        {
            if (rb.velocity.magnitude > maxSpeed) rb.velocity = Vector2.right * maxSpeed;
            else
            {
                if (bMovement)
                {
                    horizontalAccel = horizontalAccel * moveAccel * Time.fixedDeltaTime;
                    if (horizontalAccel > accelLimit) horizontalAccel = accelLimit;
                    rb.AddForce(new Vector2(horizontalAccel, 0), ForceMode2D.Impulse);
                    //Debug.Log(horizontalAccel);
                }
            }
            bMovement = false;
        }
    }

    
}
