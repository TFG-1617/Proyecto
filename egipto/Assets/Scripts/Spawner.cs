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
    public int moreSpawn;
    public int count;

    int ranObstaculo;
    
    
    void Start () {
        StartCoroutine(Spawn());
        moreSpawn = 5;
        count = 0;
	}
	
	
	void Update () {

}

    IEnumerator Spawn()
    {
        tramosInfinitos = GameObject.Find("TramoInfinito");
        movimientoTramosScript = tramosInfinitos.GetComponent<MovimientoTramos>();
        yield return new WaitForSeconds(esperaInicio);

        while (movimientoTramosScript.finJuego==false)
        {

            esperaSpawn = moreSpawn;

            ranObstaculo = Random.Range(0, 4);

            Vector3 posicionSpawn = new Vector3(-45, 0.1f, Random.Range(-0.7f, 0.7f));

            Instantiate(obstaculos[ranObstaculo], posicionSpawn + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            count++;

            switch (count)
            {
                case 5:
                    moreSpawn = 3;
                    break;
                case 10:
                    moreSpawn = 2;
                    break;
                case 15:
                    moreSpawn = 1;
                    break;
            }
            

            yield return new WaitForSeconds(esperaSpawn);
        }
    }
}
