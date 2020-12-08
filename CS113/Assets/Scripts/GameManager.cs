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

    public string gameTransition;
    public int minigamesCompleted;
    public List<string> minigamesList;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            lifesLeft = lifesMax;
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
        if (!success)
        {
            lifesLeft--;
        }
        minigamesCompleted++;

        string nextMinigame = minigamesList[Random.Range(0, minigamesList.Count)];
        while(nextMinigame == SceneManager.GetActiveScene().name)
        {
            nextMinigame = minigamesList[Random.Range(0, minigamesList.Count)];
        }
        sc.SpecificScene(nextMinigame);
    }
}
