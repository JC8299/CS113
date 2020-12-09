using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintComputerPlayer : MonoBehaviour
{
    public float maxSpeed;
    public float moveAccel;
    private Rigidbody2D rb;
    private Animator animator;
    private GameManager gm;
    public bool bFinished;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        bFinished = false;
        maxSpeed = gm.difficulty("Sprinting");
    }

    // Update is called once per frame
    void Update()
    {
        if (!bFinished)
        {
            animator.SetBool("Running", true);
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
                float fixedAccel = moveAccel * Time.fixedDeltaTime;
                rb.AddForce(new Vector2(fixedAccel, 0), ForceMode2D.Impulse);
            }
        }
        
    }


}
