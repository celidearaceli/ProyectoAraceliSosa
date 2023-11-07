using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Cuando el jugador colisiona con la plataforma, establece la plataforma como el padre del jugador.
            collision.gameObject.transform.SetParent(transform);
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Cuando el jugador deja de colisionar con la plataforma, elimina la relación padre-hijo.
        collision.gameObject.transform.SetParent(null);
    }
}
