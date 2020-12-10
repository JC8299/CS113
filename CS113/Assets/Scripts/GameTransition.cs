using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameTransition : MonoBehaviour
{
    private GameManager gm;
    public SceneControl sc;

    private bool changingScene;

    // Start is called before the first frame update
    void Start()
    {
        changingScene = false;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        switch(gm.gameTransition)
        {
            case "Basketball":
                transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "Longjump":
                transform.GetChild(1).gameObject.SetActive(true);
                break;
            case "Snowboard":
                transform.GetChild(2).gameObject.SetActive(true);
                break;
            case "Soccer Goalie":
                transform.GetChild(3).gameObject.SetActive(true);
                break;
            case "SpeedShoot":
                transform.GetChild(4).gameObject.SetActive(true);
                break;
            case "Sprinting":
                transform.GetChild(5).gameObject.SetActive(true);
                break;
            default:
                break;
        }

        transform.GetChild(6).GetComponent<TMPro.TextMeshProUGUI>().text = gm.minigamesCompleted.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sc.gamePaused && Keyboard.current.spaceKey.wasPressedThisFrame && !changingScene)
        {
            changingScene = true;
            transition();
        }
    }

    void transition()
    {
        sc.SpecificScene(gm.gameTransition);
    }
}
