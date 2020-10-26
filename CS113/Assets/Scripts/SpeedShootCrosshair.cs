using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeedShootCrosshair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = mainCam.ScreenToWorldPoint(Mouse.current.position);
        transform.position = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
    }

//     public void OnLook(InputValue value)
//     {
//         Vector2 location = value.Get<Vector2>();
//         transform.position = location;
//     }
}
