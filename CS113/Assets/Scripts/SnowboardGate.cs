using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardGate : MonoBehaviour
{
    public bool passed;
    public float speed;

    private Rigidbody2D rb;
    void Awake()
    {
        passed = false;
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.transform.name == "Player")
        {
            passed = true;
        }
        else if (collide.transform.name == "GateDespawn")
        {
            if (passed)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Failed gate");
                Destroy(gameObject);
            }
        }
    }
}
