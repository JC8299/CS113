using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowboardGateSpawn : MonoBehaviour
{
    public GameObject gate;
    public GameObject scrollBackground;
    public float setSpeed;
    public bool readyToSpawn;
    public int spawnAmount;
    public float spawnCooldown;

    private float spawnTimer;
    private float backgroundCooldown;
    private float backgroundTimer;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        backgroundCooldown = spawnCooldown/2;
        setSpeed = gm.difficulty("Snowboard");
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToSpawn)
        {
            if (backgroundTimer < 0f)
            {
                backgroundTimer = backgroundCooldown;
                GameObject sb = Instantiate(scrollBackground);
                sb.transform.position = transform.GetChild(5).transform.position;
                sb.transform.GetComponent<SnowboardBackground>().speed = setSpeed;
            }
            if (spawnTimer < 0f && spawnAmount > 0)
            {
                spawnTimer = spawnCooldown;
                spawnAmount--;
                GameObject g = Instantiate(gate);
                gate.transform.position = transform.GetChild(Random.Range(0, 5)).transform.position;
                g.transform.GetComponent<SnowboardGate>().speed = setSpeed;
            }
            spawnTimer -= Time.deltaTime;
            backgroundTimer -= Time.deltaTime;
        }
    }
}
