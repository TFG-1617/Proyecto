using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calavera : MonoBehaviour {
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
        movimientoTramosScript.AddScore(-100);


    }
}
