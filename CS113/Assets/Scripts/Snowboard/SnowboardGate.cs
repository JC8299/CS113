using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardGate : MonoBehaviour
{
    public static int gates;
    public bool passed;
    public float speed;

    private Rigidbody2D rb;
    private GameManager gm;
    void Awake()
    {
        passed = false;
        rb = transform.GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                gates++;
                if (gates >= 5)
                {
                    gates = 0;
                    gm.CurrentMinigameCompleted(true);
                }
                Destroy(gameObject);
            }
            else
            {
                if (gates < 5)
                {
                    gates = 0;
                    gm.CurrentMinigameCompleted(false);
                }
                Destroy(gameObject);
            }
        }
    }
}
