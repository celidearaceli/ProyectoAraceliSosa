using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
// Importa el espacio de nombres para trabajar con escenas en Unity.
using UnityEngine.SceneManagement;  

// Define una clase de script para gestionar la vida del jugador en Unity.
public class PlayerLife : MonoBehaviour  
{
    // Declaración de una variable para el componente Rigidbody2D del jugador.
    Rigidbody2D rb;  
    // Declaración de una matriz de objetos para representar los corazones (vidas) del jugador.
    public GameObject[] hearts;  
    private int life;  
    // Declaración de una variable para el componente Animator del jugador.
    private Animator anim;  
    // Declaración de una variable para almacenar la posición inicial del jugador.
    private Vector3 initialPosition;  
    [SerializeField] private AudioSource deathSoundEffect;  

    private void Start()  
    {
        // ASIGNACIÓN DE COMPONENTES A VARIABLES
        rb = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();
        // Inicializa la variable "life" con la cantidad de corazones en la matriz.
        life = hearts.Length;  
        // Almacena la posición inicial del jugador.
        initialPosition = transform.position;  
    }

    // Método llamado cuando el jugador colisiona con otro objeto.
    private void OnCollisionEnter2D(Collision2D collision)  
    {
        // Comprueba si el objeto con el que colisionó tiene la etiqueta "Trap" (trampa).
        if (collision.gameObject.CompareTag("Trap"))  
        {
            Die();  
        }
    }

    // Método para manejar la muerte del jugador.
    private void Die()  
    {
        deathSoundEffect.Play();  
        // Activa una animación de muerte.
        anim.SetTrigger("death");  
        // Reduce la cantidad de vidas del jugador.
        life--;  

        // Si el jugador tiene al menos una vida restante.
        if (life >= 1)  
        {
            // Devuelve al jugador a su posición inicial.
            transform.position = initialPosition;  
        }
        else  
        {
            SceneManager.LoadScene("Over");  
        }
    }

    private void Update()  
    {
        // Si el jugador no tiene vidas restantes.
        if (life < 1) 
        {
            // Destruye el primer corazón en la interfaz de usuario para indicar la pérdida de todas las vidas.
            Destroy(hearts[0].gameObject);  
        }
        // Si el jugador tiene una vida restante.
        else if (life < 2)  
        {
            // Destruye el segundo corazón en la interfaz de usuario para indicar que queda una vida.
            Destroy(hearts[1].gameObject);  
        }
        // Si el jugador tiene dos vidas restantes.
        else if (life < 3)  
        {
            // Destruye el tercer corazón en la interfaz de usuario para indicar que quedan dos vidas.
            Destroy(hearts[2].gameObject);  
        }
    }
}
