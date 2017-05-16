using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour {
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;
    
   


    void Start()
    {

        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
      

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        movimientoTramosScript.StartCoroutine(Turbo2());

    }


    IEnumerator Turbo2()
    {
        
        movimientoTramosScript.velocidad = movimientoTramosScript.velocidad + 10;

        yield return new WaitForSeconds(5);

        movimientoTramosScript.velocidad = movimientoTramosScript.velocidad - 10;

    }

    
}
