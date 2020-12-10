using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance {get; private set;}
    private AudioSource _audioSource;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
            _audioSource.ignoreListenerPause = true;
            _audioSource.Play();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
