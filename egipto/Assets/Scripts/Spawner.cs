using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] obstaculos;
    public Vector3 valoresSpawn;
    public float esperaSpawn;
    public float masEsperaSpawn;
    public float menosEsperaSpawn;
    public int esperaInicio;
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;

    int ranObstaculo;
    
    
    void Start () {
        StartCoroutine(Spawn());
	}
	
	
	void Update () {
        esperaSpawn = Random.Range(menosEsperaSpawn, masEsperaSpawn);
    }

    IEnumerator Spawn()
    {
        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
        yield return new WaitForSeconds(esperaInicio);

        while (movimientoTramosScript.finJuego==false)
        {
            ranObstaculo = Random.Range(0, 4);

            Vector3 posicionSpawn = new Vector3(-45, 0.1f, Random.Range(-0.7f, 0.7f));

            Instantiate(obstaculos[ranObstaculo], posicionSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(esperaSpawn);
        }
    }
}
