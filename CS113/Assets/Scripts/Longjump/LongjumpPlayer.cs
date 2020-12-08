using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LongjumpPlayer : MonoBehaviour
{
    public float speed;
    public bool inJumpZone;
    public bool pastJumpZone;

    private Vector2 forward = new Vector2(1,0);

    private Rigidbody2D rb;
    private Animator animator;
    private bool win;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        inJumpZone = false;
        pastJumpZone = false;
        win = false;
        animator.SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        //track lose condition
        if (pastJumpZone)
        {
            speed = 0;
            animator.SetBool("Running", false);
            animator.SetTrigger("Fail");
            //trigger lose condition
            if (!win)
            {

            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void OnJump()
    {
        if (inJumpZone)
        {
            win = true;
            speed = 20;
            animator.SetBool("Running", false);
            animator.SetTrigger("Jump");
            rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            StartCoroutine(StopSpeed());
            //trigger win condition
        }
        else 
        {
            win = false;
            speed = 20;
            animator.SetBool("Running", false);
            animator.SetTrigger("Jump");
            rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            StartCoroutine(StopSpeed());
            //trigger lose condition
        }
    }

    IEnumerator StopSpeed()
    {
        yield return new WaitForSeconds(1f);
        speed = 0f;
    }
}
