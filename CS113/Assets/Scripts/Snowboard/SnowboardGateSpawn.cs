using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardGateSpawn : MonoBehaviour
{
    public GameObject gate;
    public GameObject scrollBackground;
    public float setSpeed;
    public bool readyToSpawn;
    public float spawnCooldown;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToSpawn)
        {
            if (spawnTimer < 0f)
            {
                spawnTimer = spawnCooldown;
                GameObject g = Instantiate(gate);
                gate.transform.position = transform.GetChild(Random.Range(0, 5)).transform.position;
                g.transform.GetComponent<SnowboardGate>().speed = setSpeed;

                GameObject sb = Instantiate(scrollBackground);
                sb.transform.position = transform.GetChild(5).transform.position;
                sb.transform.GetComponent<SnowboardBackground>().speed = setSpeed;
            }
            spawnTimer -= Time.deltaTime;
        }
    }
}
