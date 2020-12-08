using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        if(PlayerPrefs.HasKey("Volume"))
        {
            slider.value = PlayerPrefs.GetFloat("Volume");
            mixer.SetFloat("MasterVolume", Mathf.Log10(slider.value) * 20);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("Volume", sliderValue);
    }
}
