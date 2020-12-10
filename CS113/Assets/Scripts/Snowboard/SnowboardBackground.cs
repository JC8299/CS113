using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardBackground : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(-speed, 0);
        transform.position -= new Vector3(0, 0, 0.01f);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.transform.name == "GateDespawn")
        {
            Destroy(gameObject);
        }
    }
}
