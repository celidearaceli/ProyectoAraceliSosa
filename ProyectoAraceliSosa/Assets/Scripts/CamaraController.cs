using System.Collections;  
using System.Collections.Generic;  
using UnityEngine; 

// Define una clase de script para controlar la cámara en Unity.
public class CamaraController : MonoBehaviour  
{
   // Declaración de una variable que almacena la referencia al objeto Transform del jugador.
   [SerializeField] private Transform player;  

   private void Update()  
    {
        // Actualiza la posición de la cámara para que siga al jugador en el eje X e Y, manteniendo su posición en el eje Z inalterada.
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
