using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneControl : MonoBehaviour
{
    public Animator transitionAnimation;
    public bool gamePaused;

    private GameManager gm;
    private Scene currentScene;

    void Start()
    {
        gamePaused = false;
        currentScene = SceneManager.GetActiveScene();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.currentDone = false;
    }

    void Update()
    {

    }

    public void SpecificScene(string name)
    {
        StartCoroutine(LoadSpecificScene(name));
    }

    IEnumerator LoadSpecificScene(string name)
    {
        transitionAnimation.SetTrigger("fadeout");
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene(name);
    }

    public void TransitionScene(string name)
    {
        StartCoroutine(LoadTransitionScene(name));
    }

    IEnumerator LoadTransitionScene(string name)
    {
        transitionAnimation.SetTrigger("fadeout");
        gm.gameTransition = name;
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Transition");
    }

    public void setSingle(string name)
    {
        StartCoroutine(LoadSingle(name));
    }

    IEnumerator LoadSingle(string name)
    {
        transitionAnimation.SetTrigger("fadeout");
        gm.singleGame = true;
        gm.gameTransition = name;
        yield return new WaitForSecondsRealtime(1.5f);
        SceneManager.LoadScene("Transition");
    }

    public void StartGame()
    {
        gm.lifesLeft = gm.lifesMax;
        gm.minigamesCompleted = 0;

        string nextMinigame = gm.minigamesList[Random.Range(0, gm.minigamesList.Count)];
        TransitionScene(nextMinigame);
    }

    public void OnPause()
    {
        if (!gamePaused && !(currentScene.name == "MainMenu" || currentScene.name == "GameSelect"))
        {
            gamePaused = true;
            PauseGame();
        }
        else if (!(currentScene.name == "MainMenu" || currentScene.name == "GameSelect"))
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        StartCoroutine(Pause());
    }

    IEnumerator Pause()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
    }

    public void ResumeGame()
    {
        StartCoroutine(Resume());
    }

    IEnumerator Resume()
    {
        yield return new WaitForSecondsRealtime(0f);
        transform.GetChild(1).gameObject.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
