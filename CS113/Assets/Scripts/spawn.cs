using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject test1,test2,test3;
    private Vector2 screenBounds;
    bool spawned = false;
    int spawn_determine = 0;


   
    // Start is called before the first frame update
    void Start()
    {
        spawn_determine = UnityEngine.Random.Range(1, 4);
        SpawnBlocker();
       
    }

    // Update is called once per frame
    

    
    private void SpawnBlocker()
    {
        test1.transform.position = new Vector3(7f, 0, 0);
        test2.transform.position = new Vector3(0, 0, 0);
        test3.transform.position = new Vector3(-7f, 0, 0);
        if (spawned == false)
        {
            if (spawn_determine == 1)
            {
                test1.SetActive(false);
            }
            if (spawn_determine == 2)
            {
                test2.SetActive(false);
            }
            if (spawn_determine == 3)
            {
                test3.SetActive(false);
            }
            spawned = true;
        }
           
    }
}
