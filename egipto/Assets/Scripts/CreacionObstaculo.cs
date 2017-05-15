using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionObstaculo : MonoBehaviour {
    public GameObject obstaculo;
    public GameObject[] obstaculos;
    public int numeroDeObstaculos;

    GameObject obstaculoActual;

    int numeroSeleccionObstaculo;
    int contadorObstaculo = 0;
    public List<Vector3> posiciones = new List<Vector3>();


    void Start () {
        obstaculo = GameObject.Find("Obstaculos");
        BuscarObstaculos();
		
        
	}

    void BuscarObstaculos()
    {
        obstaculos = GameObject.FindGameObjectsWithTag("Obstaculo");
        for (int i = 0; i < obstaculos.Length; i++)
        {
            obstaculos[i].gameObject.transform.parent = obstaculo.transform;
            obstaculos[i].gameObject.SetActive(false);
            obstaculos[i].gameObject.name = "Obstaculo_" + i;
        }
        for(int i=0; i < numeroDeObstaculos; i++)
        {
        CrearObstaculo();
        }

    }

    void CrearObstaculo()
    {
        contadorObstaculo++;
        numeroSeleccionObstaculo = Random.Range(0, obstaculos.Length-1);
        GameObject nObstaculo = Instantiate(obstaculos[numeroSeleccionObstaculo]);
        nObstaculo.SetActive(true);
        nObstaculo.name = "obstaculo" + contadorObstaculo;
        nObstaculo.transform.parent = gameObject.transform;
        ColocarObstaculo();
    }

    void ColocarObstaculo()
    {
        posiciones.Clear();
        obstaculoActual = GameObject.Find("obstaculo"+contadorObstaculo);
        bool aux = true;
        Vector3 posicionActual;
        do
        {
            posicionActual = new Vector3(Random.Range(-65, -36), (float)0.2, Random.Range((float)-0.5, (float)0.5));
            if (posiciones.Count != 0)
            {
                aux = true;
                foreach (Vector3 pos in posiciones)
                {
                    if (posicionActual.x < pos.x + 2 && posicionActual.x > pos.x - 2)
                    {
                        aux = false;
                        break;
                    }
                }

            }



        } while (!aux);

        obstaculoActual.transform.position = posicionActual;
        posiciones.Add(posicionActual);

    }


}
