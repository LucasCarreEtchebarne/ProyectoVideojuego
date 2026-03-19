using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [Header("Punto de respawn")]
    public Transform puntoRespawn; // Asignar en el Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            ph?.RecibirDaño();

            // Respawnear en el punto definido o en posición segura
            if (puntoRespawn != null)
                other.transform.position = puntoRespawn.position;
            else
                other.transform.position = new Vector3(-6, 0, 0); // Posición segura por defecto
        }
    }
}