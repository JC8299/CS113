using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teammate2 : MonoBehaviour
{
    private GameObject blocker;
    // Start is called before the first frame update
    void Start()
    {
        blocker = GameObject.Find("blocker2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void blocked()
    {
       if ( blocker.activeSelf )
       {
           Debug.Log(blocker.transform.name);
       }
    }
}
