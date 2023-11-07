using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    // Referencia al componente Rigidbody2D del jugador.
    Rigidbody2D rb;
    // Referencia al componente BoxCollider2D del jugador.
    private BoxCollider2D coll;  
    // Referencia al componente Animator del jugador.
    private Animator anim;  

    // Máscara de capa que determina qué se considera suelo.
    [SerializeField] private LayerMask jumpableGround;  
    // Referencia al componente SpriteRenderer del jugador.
    private SpriteRenderer sprite;  

    // Dirección horizontal del jugador.
    private float dirX = 0f;  

    // Velocidad de movimiento horizontal del jugador.
    [SerializeField] private float moveSpeed = 7f;  
    // Fuerza de salto del jugador.
    [SerializeField] private float jumpForce = 14f;  

    // Enumeración que representa los estados de movimiento del jugador.
    private enum MovementState {idle, running, jumping, falling}  

    [SerializeField] private AudioSource jumpSoundEffect;

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador.
        rb =  GetComponent<Rigidbody2D>();  
        // Obtiene el componente BoxCollider2D del jugador.
        coll = GetComponent<BoxCollider2D>();  
        // Obtiene el componente SpriteRenderer del jugador.
        sprite = GetComponent<SpriteRenderer>();  
        // Obtiene el componente Animator del jugador.
        anim = GetComponent<Animator>();  
    }

    void Update()
    { 
        // Lee la entrada del teclado o control para obtener la dirección horizontal.
        dirX = Input.GetAxisRaw("Horizontal"); 
        // Actualiza la velocidad del jugador en el eje X.
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);  

        // Comprueba si se presionó el botón de salto y si el jugador está en el suelo.
        if (Input.GetButtonDown("Jump") && IsGrounded())  
        {
            jumpSoundEffect.Play();  
            // Aplica una fuerza vertical para que el jugador salte.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);  
        }
         // Actualiza el estado de la animación del jugador.
        UpdateAnimationState();  
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            // El jugador se está moviendo hacia la derecha.
            state = MovementState.running;  
            // Voltea el sprite del jugador en la dirección correcta.
            sprite.flipX = false;  
        }
        else if (dirX < 0f)
        {
            // El jugador se está moviendo hacia la izquierda.
            state = MovementState.running;  
            // Voltea el sprite del jugador en la dirección correcta.
            sprite.flipX = true;  
        }
        else
        {
            state = MovementState.idle; 
        }

        if (rb.velocity.y > 0.1f)
        {
            // El jugador está saltando.
            state = MovementState.jumping;  
        }
        else if (rb.velocity.y < -0.1f)
        {
            // El jugador está cayendo.
            state = MovementState.falling;  
        }
        // Establece el estado de la animación en función del estado de movimiento.
        anim.SetInteger("state", (int)state);  
    }

    // Inicio del método para comprobar si el jugador está en el suelo.
    private bool IsGrounded()
    {
        // Realiza una detección de colisión en la parte inferior del jugador para verificar si está en el suelo.
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}

