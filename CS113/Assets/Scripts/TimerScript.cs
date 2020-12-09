using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public bool timerRun;

    private GameManager gm;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentTime = gm.difficulty(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRun)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                DisplayTime(currentTime);
            }
            else
            {
                Debug.Log("No more time");
                currentTime = 0f;
                timerRun = false;
                gm.CurrentMinigameCompleted(false);
                DisplayTime(currentTime);
            }
        }
    }

    void DisplayTime(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);
        float milliseconds = (time % 1) * 100;

        transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
    }
}
