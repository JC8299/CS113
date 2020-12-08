//Used as the goalie for Soccer.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;

    private float moveX;
    // Start is called before the first frame update
    void Start()
    {
        moveX = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //check if we are the top or bottom paddle
        // if(gameObject.name == "bottomPaddle")
        // {
        //     MovePaddle(gameObject.name);
        // }
        // else if(gameObject.name == "topPaddle")
        // {
        //     MovePaddle(gameObject.name);
        // }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x + moveX * speed * Time.deltaTime, minX, maxX), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            speed = 0;
        }
    }

    //uses old input system. below is the rework for the new input system
    // public void MovePaddle(string paddleName)
    // {
    //     float moveX = Input.GetAxisRaw(paddleName) * speed * Time.deltaTime;
    //     transform.position = new Vector2(Mathf.Clamp(transform.position.x + moveX, minX, maxX), transform.position.y);
    // }
    
    public void OnMove(InputValue value)
    {
        moveX = value.Get<Vector2>().x;
    }
}
