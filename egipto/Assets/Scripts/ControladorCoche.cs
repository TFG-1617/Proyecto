using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    private float anguloDeGiro = 10F;
    public float speed = 6.0F;
    public float gravity = 20.0F;
    public float speedTurn = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject cocheGO;
    public GameObject pause;
 
    public GameObject listaVehiculos;
    public SeleccionVehiculo seleccionVehiculosScript;
    public float giroEnY;

    void Start()
    {
        cocheGO = GameObject.FindGameObjectWithTag("Coche");
        pause = GameObject.Find("Pause");
        pause.SetActive(false);
    }


    void Update()
    {
        
        if(cocheGO != null) { 
        CharacterController controller = GetComponent<CharacterController>();

            
            moveDirection = new Vector3(0, 0, Input.acceleration.x * speedTurn);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            giroEnY = Input.acceleration.x * anguloDeGiro;

            if(cocheGO.name=="taxi" )
                cocheGO.transform.rotation = Quaternion.Euler(-90, giroEnY -90  ,0 );

            if(cocheGO.name== "hearse" || cocheGO.name == "firefighter")
                cocheGO.transform.rotation = Quaternion.Euler(-90, giroEnY +180 , 0);

            if (cocheGO.name == "Coche")
                cocheGO.transform.rotation = Quaternion.Euler(-90, giroEnY +90, 0);

            controller.Move(moveDirection * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Change();
            }
        }
    }

    void Change()
    {
        if (Time.timeScale == 1)
            Pause();

        else if (Time.timeScale == 0)
            Continue();
    }

    void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }

    void Continue()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
}
