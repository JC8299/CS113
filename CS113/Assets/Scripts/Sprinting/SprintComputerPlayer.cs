using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintComputerPlayer : MonoBehaviour
{
    public float maxSpeed;
    public float moveAccel;
    public AudioClip step1;
    public AudioClip step2;
    private Rigidbody2D rb;
    private Animator animator;
    private GameManager gm;
    private AudioSource audioSource;
    private float stepTime;
    public bool bFinished;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        bFinished = false;
        maxSpeed = gm.difficulty("Sprinting");
        stepTime = .2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bFinished)
        {
            animator.SetBool("Running", true);
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
