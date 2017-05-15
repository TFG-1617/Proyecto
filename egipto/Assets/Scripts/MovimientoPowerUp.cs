using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPowerUp : MonoBehaviour {

    public float velocidad;
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;
    public Vector3 rotacion = new Vector3(0, 270, 0);

    void Start()
    {

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


    void Update()
    {
        if (movimientoTramosScript.inicioJuego == true && movimientoTramosScript.finJuego == false)
        {
          
            transform.position += Vector3.right * velocidad * Time.deltaTime;
            transform.Rotate(rotacion * Time.deltaTime);
        }

    }

}
