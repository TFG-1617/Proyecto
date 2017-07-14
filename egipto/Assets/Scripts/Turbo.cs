using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbo : MonoBehaviour {
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;
    public AudioClip sound = null;
    public Transform position = null;



    void Start()
    {

        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
        position = transform;

    }

    void OnTriggerEnter(Collider other)
    {
        if (sound)
        {
            AudioSource.PlayClipAtPoint(sound, position.position);
        }
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
