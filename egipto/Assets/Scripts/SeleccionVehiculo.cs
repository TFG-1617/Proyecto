using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionVehiculo : MonoBehaviour {

    private GameObject[] listaCoches;
    private GameObject candado;
    public int indice;
    public int puntuacion;
    

	private void Start () {

        indice = PlayerPrefs.GetInt("CocheSeleccionado");
        puntuacion = PlayerPrefs.GetInt("TotalScore");
        listaCoches = new GameObject[transform.childCount];

        candado = GameObject.Find("Bloqueado");
        candado.SetActive(false);

        for (int i = 0; i < transform.childCount; i++)
            listaCoches[i] = transform.GetChild(i).gameObject;

        foreach (GameObject go in listaCoches)
            go.SetActive(false);

        if (listaCoches[indice])
            listaCoches[indice].SetActive(true);

	}
	
	public void Izquierda()
    {
        listaCoches[indice].SetActive(false);

        indice--;
        if (indice < 0)
            indice = 0;

        listaCoches[indice].SetActive(true);
        if (puntuacion > 20000 && indice == 2)
        {
            candado.SetActive(false);
        }
        else if (puntuacion > 10000 && indice == 1)
        {
            candado.SetActive(false);
        }
        else if (puntuacion >= 0 && indice == 0)
        {
            candado.SetActive(false);
        }
    }

    public void Derecha()
    {
        listaCoches[indice].SetActive(false);
       

        indice++;
        if (indice == listaCoches.Length)
            indice = listaCoches.Length-1;

        listaCoches[indice].SetActive(true);


        if (puntuacion < 10000 && (indice == 1 || indice == 2 || indice == 3))
        {
            candado.SetActive(true);
        }
        else if (puntuacion < 20000 && (indice == 2 || indice == 3))
        {
            candado.SetActive(true);
        }
        else if (puntuacion < 30000 && indice == 3)
        {
            candado.SetActive(true);
        }

    }

    public void Seleccionar()
    {
        if(candado.activeInHierarchy == false) { 
        PlayerPrefs.SetInt("CocheSeleccionado", indice);
        SceneManager.LoadScene("level 2");
        }
    }

}
