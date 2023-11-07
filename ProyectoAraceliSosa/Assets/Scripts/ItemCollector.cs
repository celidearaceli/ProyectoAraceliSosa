using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Importa el espacio de nombres de Unity para acceder a las clases relacionadas con la interfaz de usuario (UI).
using UnityEngine.UI; 

// Define una clase de script para gestionar la recolección de objetos en Unity.
public class ItemCollector : MonoBehaviour  
{
    // Cuenta la cantidad de objetos recolectados (en este caso, cherries).
    private int cherries = 0;  
    [SerializeField] private Text cherriesText;  
    [SerializeField] private AudioSource collectionSoundEffect;  

    // Método llamado automáticamente cuando un objeto colisiona con este objeto.
    private void OnTriggerEnter2D(Collider2D collision)  
    {
        // Comprueba si el objeto que colisionó tiene la etiqueta "Cherry".
        if (collision.gameObject.CompareTag("Cherry"))  
        {
            collectionSoundEffect.Play();  
            // Destruye el objeto del cherry para eliminarlo del juego.
            Destroy(collision.gameObject);  
            // Incrementa el contador de cerezas recolectadas.
            cherries++;  
            // Actualiza el texto en la interfaz de usuario para mostrar la cantidad actual de los cherries recolectados.
            cherriesText.text = "Cherries: " + cherries;  
        }
    }
}
