using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnowboardPlayer : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    private SceneControl sc;
    private float y;
    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sc = GameObject.Find("Transition").GetComponent<SceneControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, y * speed * Time.deltaTime);

    }

    public void OnMove(InputValue value)
    {
        y = value.Get<Vector2>().y;
        if (!sc.gamePaused)
        {
            if (y > 0)
            {
                animator.SetTrigger("Up");
            }
            else if (y < 0)
            {
                animator.SetTrigger("Down");
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }
}
