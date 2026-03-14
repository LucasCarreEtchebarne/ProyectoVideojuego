using UnityEngine;

// Colocar en un objeto invisible debajo del nivel (trigger 2D muy ancho)
public class FallDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph?.RecibirDaño();

            // Respawnear al jugador en el origen (ajustar posición según nivel)
            other.transform.position = Vector3.zero;
        }
    }
}
