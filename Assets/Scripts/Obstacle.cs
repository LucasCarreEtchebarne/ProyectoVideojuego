using UnityEngine;

// Adjuntar este script a cualquier objeto que deba quitar vida al jugador
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            ph?.RecibirDaño();
        }
    }

    // Alternativa con trigger (para obstáculos tipo zona)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph?.RecibirDaño();
        }
    }
}
