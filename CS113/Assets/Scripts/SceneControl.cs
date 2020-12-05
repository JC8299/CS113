using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public Animator transitionAnimation;

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

    public void QuitGame()
    {
        Application.Quit();
    }
}
