using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintComputerPlayer : MonoBehaviour
{
    public float maxSpeed;
    public float moveAccel;
    private Rigidbody2D rb;
    public bool bFinished;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bFinished = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!bFinished)
        {
            if (rb.velocity.magnitude > maxSpeed) rb.velocity = Vector2.right * maxSpeed;
            else
            {
                float fixedAccel = moveAccel * Time.fixedDeltaTime;
                rb.AddForce(new Vector2(fixedAccel, 0), ForceMode2D.Impulse);
            }
        }
        
    }


}
