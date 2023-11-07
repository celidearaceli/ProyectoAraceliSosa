using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
// Importa el espacio de nombres para trabajar con escenas en Unity.
using UnityEngine.SceneManagement;  

public class Finish : MonoBehaviour  
{
    private AudioSource finishSound;  
    // Declaración de una variable para rastrear si el nivel ha sido completado.
    private bool levelCompleted = false;  

    private void Start()
    {
         // Asigna el componente AudioSource del objeto actual a la variable "finishSound".
        finishSound = GetComponent<AudioSource>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el jugador ha colisionado con el objeto "Finish" y si el nivel no se ha completado.
        if (collision.gameObject.name == "Player" && !levelCompleted)  
        {
            finishSound.Play();  
            // Marca el nivel como completado.
            levelCompleted = true;  
            // Llama a la función "CompleteLevel" después de 2 segundos.
            Invoke("CompleteLevel", 2f);  
        }
    }

    private void CompleteLevel()
    {
        // Carga la siguiente escena en la secuencia, incrementando el índice de la escena actual.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }
}
