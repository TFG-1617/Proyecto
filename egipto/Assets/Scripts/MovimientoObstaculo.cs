using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour {
    public float velocidad;
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;
    

    void Start () {
        
        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
        InicioJuego();
    }

    void InicioJuego()
    {
        VelocidadCarretera(); 
    }

    void VelocidadCarretera()
    {
        velocidad = movimientoTramosScript.velocidad;
    }


    void Update () {
        if (movimientoTramosScript.inicioJuego == true && movimientoTramosScript.finJuego == false)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
           
        }
            
        }

    }

