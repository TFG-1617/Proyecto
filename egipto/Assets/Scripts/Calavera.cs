using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calavera : MonoBehaviour {
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
        movimientoTramosScript.AddScore(-100);


    }
}
