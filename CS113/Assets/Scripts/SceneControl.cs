﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneControl : MonoBehaviour
{
    public Animator transitionAnimation;
    public bool gamePaused;
    public bool noPause;

    private GameManager gm;
    private Scene currentScene;

    void Start()
    {
        ResumeGame();
        currentScene = SceneManager.GetActiveScene();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.currentDone = false;
        noPause = false;
    }

    void Update()
    {

    }

    public void MinigameResult(bool success)
    {
        noPause = true;
        StartCoroutine(DisplayMinigameResult(success));
    }

    IEnumerator DisplayMinigameResult(bool success)
    {
        transitionAnimation.SetBool("success", success);
        transitionAnimation.SetTrigger("done");
        yield return 0;
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
        if (!gamePaused && !(currentScene.name == "MainMenu" || currentScene.name == "GameSelect") && !noPause)
        {
            gamePaused = true;
            PauseGame();
        }
        else if (gamePaused && !(currentScene.name == "MainMenu" || currentScene.name == "GameSelect"))
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
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
        AudioListener.pause = false;
        gamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
