using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintFinishLine : MonoBehaviour
{
    private bool done;
    private GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        done = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ComputerPlayer")
        {
            if (!done)
            {
                gm.CurrentMinigameCompleted(false);
            }
            Debug.Log("Trigger touched.");
            Debug.Log(col.gameObject.name);
            col.gameObject.GetComponent<SprintComputerPlayer>().bFinished = true;
        }
        else if (col.gameObject.name == "Player")
        {
            if (!done)
            {
                gm.CurrentMinigameCompleted(true);
            }
            Debug.Log("Trigger touched.");
            Debug.Log(col.gameObject.name);
            col.gameObject.GetComponent<SprintPlayerController>().bFinished = true;
        }
    }
}
