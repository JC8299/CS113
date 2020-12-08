using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnowboardPlayer : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        float y = value.Get<Vector2>().y;
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
        rb.velocity = new Vector2(rb.velocity.x * Time.deltaTime, y * speed * Time.deltaTime);
    }
}
