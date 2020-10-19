using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LongjumpPlayer : MonoBehaviour
{
    public float speed;
    public bool inJumpZone;
    private bool moving;
    private Vector2 forward = new Vector2(1,0);
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        inJumpZone = false;
        //temporary CHANGE AFTER
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && inJumpZone)
        {
            speed = 0;
            Debug.Log("space");
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame && !inJumpZone)
        {
            speed = 100;
            Debug.Log("death");
        }
    }

    void FixedUpdate()
    {

        if (moving)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (inJumpZone)
        {
            speed = 0;
            Debug.Log("Success");
        }
        else 
        {
            speed = 100;
            Debug.Log("Fail");
        }
    }
}
