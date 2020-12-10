//Used as the soccer ball in soccer game.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public AudioClip kickNoise1;
    public AudioClip kickNoise2;
    private GameManager gm;
    private AudioSource audioSource;
    Vector2 direction; //(x, y)

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        //direction = Vector2.one.normalized; //(1,1)
        //direction.x = UnityEngine.Random.Range(-1, 1);

        StartCoroutine(ShootBall());

    }

    IEnumerator ShootBall()
    {
        yield return new WaitForSeconds(1f);
        AudioClip kickNoise;
        switch (UnityEngine.Random.Range(0,2))
        {
            case 0:
                kickNoise = kickNoise1;
                break;
            case 2:
                kickNoise = kickNoise2;
                break;
            default:
                kickNoise = kickNoise1;
                break;
        }
        audioSource.PlayOneShot(kickNoise, 0.7f);
        direction.x = UnityEngine.Random.value * 2 - 1;
        direction.y = -1;
    }

    private void FixedUpdate() 
    // Called a fixed amount of times
    {
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("VerticalWall"))
        {
            direction.x = -direction.x;
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Task Failed");
            gm.CurrentMinigameCompleted(false);
            speed = 0;
        }

        else if (collision.gameObject.CompareTag("Paddle") || collision.gameObject.CompareTag("HorizontalWall"))
        {
            Debug.Log("Task Success!");
            gm.CurrentMinigameCompleted(true);
            speed = 0;
        }
    }
}
