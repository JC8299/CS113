using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedShootTargetSpawn : MonoBehaviour
{
    public GameObject target;
    public bool readyToSpawn;
    public float spawnTimer;
    public int numberToSpawn;
    public bool doneSpawning = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (!doneSpawning)
        {
            doneSpawning = true;
            System.Random rand = new System.Random();
            List<int> nums = new List<int>() {0,1,2,3,4,5};

            for (int i = 0; i < 6-numberToSpawn; i++)
            {
                int index = rand.Next(6-i);
                nums.RemoveAt(index);
            }
            foreach (int x in nums)
            {
                Debug.Log(x);
            }
            for (int i = 0; i < numberToSpawn; i++)
            {
                GameObject t = Instantiate(target, transform.GetChild(nums[i]).transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
