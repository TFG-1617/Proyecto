using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovimientoTramos : MonoBehaviour {
    public GameObject todosLosTramos;
    public GameObject[] conjuntoTramos;

    public float velocidad =10;
    public bool inicioJuego;
    public bool finJuego;

    int contadorTramo = 0;
    int numeroSeleccionTramo;

    public GameObject tramoAnterior;
    public GameObject tramoActual;

    public float tamañoTramo;

    public bool fueraDeCamara;

    /* Score */
    public Text scoreText;
    public GameObject scoreGO;
    public int score;
    public float realScore;
   



    // Use this for initialization
    void Start () {
        InicioJuego();
        StartScore();
    }

    void InicioJuego()
    {
        todosLosTramos = GameObject.Find("TodosLosTramos");
        
        BuscarTramos();

        inicioJuego = true;
        finJuego = false;
    }

    void VelocidadCarretera()
    {
     
    }

    void BuscarTramos()
    {
        conjuntoTramos = GameObject.FindGameObjectsWithTag("Tramo");
        for(int i= 0; i < conjuntoTramos.Length; i++)
        {
            conjuntoTramos[i].gameObject.transform.parent = todosLosTramos.transform;
            conjuntoTramos[i].gameObject.SetActive(false);
            conjuntoTramos[i].gameObject.name = "Tramo_" + i;
        }
        CrearTramo();
    }

    void CrearTramo()
    {
        contadorTramo ++;
        numeroSeleccionTramo = Random.Range(0, conjuntoTramos.Length);
        GameObject tramo = Instantiate(conjuntoTramos[numeroSeleccionTramo]);
        tramo.SetActive(true);
        tramo.name = "Tramo" + contadorTramo;
        tramo.transform.parent = gameObject.transform;
        ColocarTramo();
    }

    void ColocarTramo()
    {
        tramoAnterior = GameObject.Find("Tramo" + (contadorTramo - 1));
        tramoActual = GameObject.Find("Tramo" + contadorTramo);
        MedirTramo();
        tramoActual.transform.position = new Vector3(tramoAnterior.transform.position.x - tamañoTramo, tramoAnterior.transform.position.y, tramoAnterior.transform.position.z);
        fueraDeCamara = false;
    }

    void MedirTramo()
    {
        for (int i = 0; i < tramoAnterior.transform.childCount; i++)
        {
            if (tramoAnterior.transform.GetChild(i).gameObject.GetComponent<Tramo>() != null) { 
            float tamañoTramoAux = tramoAnterior.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().bounds.size.x;
            tamañoTramo = tamañoTramo + tamañoTramoAux;
            }
        }
    }
	

    void DestruirTramo()
    {
        Destroy(tramoAnterior);
        tamañoTramo = 0;
        tramoAnterior = null;
        CrearTramo();
    }
	// Update is called once per frame
	void Update () {
        if (inicioJuego == true && finJuego == false) { 
            
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        if (tramoAnterior.transform.position.x + tamañoTramo > tamañoTramo*2 && fueraDeCamara == false)
        {
            fueraDeCamara = true;
            DestruirTramo();
        }
        /* Update score */
        if (inicioJuego == true && finJuego == false)
        {
            AddScore(velocidad * Time.deltaTime);
            UpdateScore();
        }
    }
    /* Score */
    private void StartScore()
    {
        score = 0;
        realScore = 0;
        scoreGO = GameObject.Find("Text");
        scoreText = scoreGO.GetComponent<Text>();
        UpdateScore();
    }

    public void AddScore(float newScoreValue)
    {
        realScore += newScoreValue;
        score = (int)realScore;
        UpdateScore();
        saveLastScore();
        if (score != 0 && score % 500 == 0)
        {
            velocidad += 0.5f;
        }
       
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void saveLastScore()
    {
        PlayerPrefs.SetInt("LastScore", score);
        /* Hace falta el save? */
    }


}
