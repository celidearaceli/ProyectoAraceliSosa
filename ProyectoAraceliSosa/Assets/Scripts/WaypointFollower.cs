using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Declaración de una matriz de objetos para almacenar los waypoints.
    [SerializeField] private GameObject[] waypoints;  
    // Índice del waypoint actual que se está siguiendo.
    private int currentWaypointIndex = 0;  
    // Velocidad de movimiento del objeto que sigue los waypoints.
    [SerializeField] private float speed = 1f; 
     

    private void Update()
    {
        // Comprueba si el objeto está lo suficientemente cerca del waypoint actual.
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            // Avanza al siguiente waypoint.
            currentWaypointIndex++;  

            // Si se ha llegado al final de la lista de waypoints, vuelve al primer waypoint.
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // Mueve el objeto hacia el waypoint actual de manera suave y constante.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
