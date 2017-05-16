using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoche : MonoBehaviour
{
    public float anguloDeGiro;
    public float speed = 6.0F;
    public float gravity = 20.0F;
    public float speedTurn = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
    public GameObject cocheGO;
 
    public GameObject listaVehiculos;
    public SeleccionVehiculo seleccionVehiculosScript;
    public float giroEnY;

    void Start()
    {
        cocheGO = GameObject.FindGameObjectWithTag("Coche");
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
    }
    }
}
