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
    private bool bMoveKeyPressed;
    private bool bMovement;
    private float timeNow;
    private float timeLastPressed;
    private float horizontalAccel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                if (bMoveKeyPressed) bMoveKeyPressed = false;
                else bMoveKeyPressed = true;

                bMovement = true;
                timeNow = Time.time;
                horizontalAccel = 1 / (timeNow - timeLastPressed);
                timeLastPressed = timeNow;
            }
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
