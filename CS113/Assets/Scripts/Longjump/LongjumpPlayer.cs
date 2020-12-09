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
    private GameManager gm;
    private bool win;
    private bool secondaryCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        inJumpZone = false;
        pastJumpZone = false;
        win = false;
        secondaryCheck = true;
        speed = gm.difficulty("Longjump");
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
            if (!win && secondaryCheck)
            {
                secondaryCheck = !secondaryCheck;
                gm.CurrentMinigameCompleted(false);
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
            StartCoroutine(StopSpeed(true));
        }
        else 
        {
            win = false;
            speed = 20;
            animator.SetBool("Running", false);
            animator.SetTrigger("Jump");
            rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
            StartCoroutine(StopSpeed(false));
        }
    }

    IEnumerator StopSpeed(bool success)
    {
        yield return new WaitForSeconds(1f);
        speed = 0f;
        gm.CurrentMinigameCompleted(success);
    }
}
