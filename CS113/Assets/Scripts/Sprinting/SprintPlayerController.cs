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
    public AudioClip step1;
    public AudioClip step2;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
    private bool bMoveKeyPressed;
    private bool bMovement;
    private float timeNow;
    private float timeLastPressed;
    private float horizontalAccel;
    private float stepTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        stepTime = .2f;
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

                if (stepTime < 0)
                {
                    stepTime = .2f;
                    switch (UnityEngine.Random.Range(0,1))
                    {
                        case 0:
                            audioSource.PlayOneShot(step1, .7f);
                            break;
                        case 1:
                            audioSource.PlayOneShot(step2, .7f);
                            break;
                        default:
                            audioSource.PlayOneShot(step1, .7f);
                            break;
                    }
                }
                else
                    stepTime -= Time.deltaTime;
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
