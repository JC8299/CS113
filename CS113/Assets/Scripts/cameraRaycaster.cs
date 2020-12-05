using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cameraRaycaster : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    void Start()
    {
        addPhysicsRaycaster();
    }
 
    void addPhysicsRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }
}
