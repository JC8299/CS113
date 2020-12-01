using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintFinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "ComputerPlayer")
        {
            Debug.Log("Trigger touched.");
            Debug.Log(col.gameObject.name);
            col.gameObject.GetComponent<SprintComputerPlayer>().bFinished = true;
        }
        else if (col.gameObject.name == "Player")
        {
            Debug.Log("Trigger touched.");
            Debug.Log(col.gameObject.name);
            col.gameObject.GetComponent<SprintPlayerController>().bFinished = true;
        }
    }
}
