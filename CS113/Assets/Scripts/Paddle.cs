//Used as the goalie for Soccer.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if we are the top or bottom paddle
        if(gameObject.name == "bottomPaddle")
        {
            MovePaddle(gameObject.name);
        }
        else if(gameObject.name == "topPaddle")
        {
            MovePaddle(gameObject.name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            speed = 0;
        }
    }

    public void MovePaddle(string paddleName)
    {
        float moveX = Input.GetAxisRaw(paddleName) * speed * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + moveX, minX, maxX), transform.position.y);
    }
}
