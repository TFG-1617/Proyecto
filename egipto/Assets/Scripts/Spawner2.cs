using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour {

    public GameObject[] powerUp;
    public Vector3 valoresSpawn;
    public float esperaSpawn;
    public float masEsperaSpawn;
    public float menosEsperaSpawn;
    public int esperaInicio;
    public GameObject tramosInfinitos;
    public MovimientoTramos movimientoTramosScript;

    int ranObstaculo;


    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }


    void Update()
    {
        esperaSpawn = Random.Range(menosEsperaSpawn, masEsperaSpawn);
    }

    IEnumerator SpawnPowerUp()
    {
        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
        yield return new WaitForSeconds(esperaInicio);

        while (movimientoTramosScript.finJuego == false)
        {
            ranObstaculo = Random.Range(0, 3);

            Vector3 posicionSpawn = new Vector3(-45, 0.5f, Random.Range(-0.7f, 0.7f));

            Instantiate(powerUp[ranObstaculo], posicionSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(esperaSpawn);
        }
    }
}
