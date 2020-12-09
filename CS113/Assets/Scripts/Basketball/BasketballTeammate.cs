using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballTeammate : MonoBehaviour
{
    public Sprite passable;

    private Transform teammates;
    private Transform blockers;
    private GameManager gm;
    private int pass;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        pass = UnityEngine.Random.Range(0,3);
        //Unity gets angry if I don't add a check for children
        if (transform.childCount > 2)
        {
            teammates = transform.GetChild(0);
            blockers = transform.GetChild(1);
        
            teammates.GetChild(pass).gameObject.GetComponent<SpriteRenderer>().sprite = passable;
            blockers.GetChild(pass).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passCheck(int passed)
    {
        if (passed != pass)
        {
            gm.CurrentMinigameCompleted(false);
        }
        else
        {
            gm.CurrentMinigameCompleted(true);
        }
    }
}
