using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {get; private set;}
    public SceneControl sc;

    public int lifesMax;
    public int lifesLeft;

    public float timerMaximum;
    public float timerMinimum;

    public float longjumpSpeedMax;
    public float longjumpSpeedMin;
    public float snowboardSpeedMax;
    public float snowboardSpeedMin;
    public float soccerSpeedMax;
    public float soccerSpeedMin;
    public float sprintingSpeedMax;
    public float sprintingSpeedMin;

    public string gameTransition;
    public bool singleGame;
    public int minigamesCompleted;
    public List<string> minigamesList;
    public bool currentDone;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", .7f);
        }
    }

    void Update()
    {
        if (sc == null)
        {
            sc = GameObject.Find("Transition").GetComponent<SceneControl>();
        }
    }

    //call when minigame is done
    //boolean is for if they pass (true) or fail (false)
    public void CurrentMinigameCompleted(bool success)
    {
        if (!currentDone)
        {
            minigamesCompleted++;
            currentDone = true;

            if (!success)
            {
                lifesLeft--;
                if (lifesLeft <= 0)
                {
                    sc.SpecificScene("Gameover");
                }
            }

            string nextMinigame = minigamesList[Random.Range(0, minigamesList.Count)];
            while(nextMinigame == SceneManager.GetActiveScene().name)
            {
                nextMinigame = minigamesList[Random.Range(0, minigamesList.Count)];
            }

            if (!singleGame)
            {
                sc.TransitionScene(nextMinigame);
            }
            else
            {
                singleGame = false;
                sc.SpecificScene("MainMenu");
            }
        }
    }

    public float difficulty(string name)
    {
        switch(name)
        {
            case "Basketball":
                if (minigamesCompleted == 0)
                    return timerMaximum;
                else if (timerMaximum - Mathf.Log(minigamesCompleted, 3) > timerMinimum)
                    return timerMaximum - Mathf.Log(minigamesCompleted, 3);
                else
                    return timerMinimum;
            case "Longjump":
                if (minigamesCompleted == 0)
                    return longjumpSpeedMin;
                else if (longjumpSpeedMin + Mathf.Log(minigamesCompleted, 3) * 20 > longjumpSpeedMax)
                    return longjumpSpeedMax;
                else
                    return longjumpSpeedMin + Mathf.Log(minigamesCompleted, 3) * 20;
            case "Snowboard":
                if (minigamesCompleted == 0)
                    return snowboardSpeedMin;
                else if (snowboardSpeedMin + Mathf.Log(minigamesCompleted, 3) * 6 > snowboardSpeedMax)
                    return snowboardSpeedMax;
                else
                    return snowboardSpeedMin + Mathf.Log(minigamesCompleted, 3) * 6;
            case "Soccer Goalie":
                if (minigamesCompleted == 0)
                    return soccerSpeedMin;
                else if (soccerSpeedMin + Mathf.Log(minigamesCompleted, 3) * 2 > soccerSpeedMax)
                    return soccerSpeedMax;
                else
                    return soccerSpeedMin + Mathf.Log(minigamesCompleted, 3) * 2;
            case "SpeedShoot":
                if (minigamesCompleted == 0)
                    return timerMaximum;
                else if (timerMaximum - Mathf.Log(minigamesCompleted, 3) > timerMinimum)
                    return timerMaximum - Mathf.Log(minigamesCompleted, 3);
                else
                    return timerMinimum;
            case "Sprinting":
                if (minigamesCompleted == 0)
                    return sprintingSpeedMin;
                else if (sprintingSpeedMin + Mathf.Log(minigamesCompleted, 3) * 2 > sprintingSpeedMax)
                    return sprintingSpeedMax;
                else
                    return sprintingSpeedMin + Mathf.Log(minigamesCompleted, 3) * 2;
            default:
                return 0;
        }
    }
}
