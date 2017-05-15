using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstaculo : MonoBehaviour {
    public GameObject cocheGO;
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;

    void Start()
    {
            cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
            tramosInfinitos = GameObject.Find("TramoInfinito");
            movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
  
    }

	void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coche>()!= null && movimientoTramosScript.finJuego == false)
        {
            Destroy(cocheGO);
            movimientoTramosScript.finJuego = true;
            SceneManager.LoadScene(4);
        }

       
    }
}
