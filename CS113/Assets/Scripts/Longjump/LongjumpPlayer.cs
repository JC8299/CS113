using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LongjumpPlayer : MonoBehaviour
{
    public float speed;
    public bool inJumpZone;
    public bool pastJumpZone;
    public AudioClip step1;
    public AudioClip step2;

    private Vector2 forward = new Vector2(1,0);

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;
    private GameManager gm;
    private bool win;
    private bool secondaryCheck;
    private bool jumping;
    private float stepTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        inJumpZone = false;
        pastJumpZone = false;
        win = false;
        secondaryCheck = true;
        jumping = false;
        stepTime = .2f;
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
        if (stepTime < 0 && jumping == false)
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

    public void OnJump()
    {
        jumping = true;
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
        audioSource.Play();
        gm.CurrentMinigameCompleted(success);
    }
}
