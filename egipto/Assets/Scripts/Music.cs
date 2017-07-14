using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour {
    
    public static Music musicAux;




    void Awake()
    {
        if(musicAux == null) {
            musicAux = this;
            DontDestroyOnLoad(gameObject);
        }else if(musicAux != this){
            Destroy(gameObject);
        }
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
