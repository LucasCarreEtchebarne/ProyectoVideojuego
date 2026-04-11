using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [Header("Punto de respawn")]
    public Transform puntoRespawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (puntoRespawn != null)
                other.transform.position = puntoRespawn.position;
            else
                other.transform.position = new Vector3(-6, 0, 0);
        }
    }
}