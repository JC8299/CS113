using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Animator transitionAnimation;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SpecificScene(string name)
    {
        StartCoroutine(LoadSpecificScene(name));
    }

    IEnumerator LoadSpecificScene(string name)
    {
        transitionAnimation.SetTrigger("fadeout");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }

    public void TransitionScene(string name)
    {
        StartCoroutine(LoadSpecificScene(name));
    }

    IEnumerator LoadTransitionScene(string name)
    {
        transitionAnimation.SetTrigger("fadeout");
        gm.gameTransition = name;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("GameTransition");
    }
    public void StartGame()
    {
        gm.lifesLeft = gm.lifesMax;
        gm.minigamesCompleted = 0;

        string nextMinigame = gm.minigamesList[Random.Range(0, gm.minigamesList.Count)];
        TransitionScene(nextMinigame);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
