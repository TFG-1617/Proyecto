using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MusicMenu : MonoBehaviour {

    public AudioSource mainMusic;
    public GameObject music;
    public Slider audioSlider;
    
    void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");
        mainMusic = music.GetComponent<AudioSource>();
    }

    void OnEnable() {
        audioSlider.onValueChanged.AddListener(delegate { OnMusicVolumenChange(); });
	}
	
	void OnMusicVolumenChange()
    {
        mainMusic.volume =  audioSlider.value;
    }
}
