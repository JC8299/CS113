using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.GetComponent<TMPro.TextMeshProUGUI>().text = gm.minigamesCompleted.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
