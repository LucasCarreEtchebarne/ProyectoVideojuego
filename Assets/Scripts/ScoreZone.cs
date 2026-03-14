using UnityEngine;

// Adjuntar a objetos invisibles tipo trigger que dan puntos al pasar
public class ScoreZone : MonoBehaviour
{
    [Header("Puntos que otorga esta zona")]
    public int puntos = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance?.SumarPuntos(puntos);
            // Opcional: destruir la zona para que no dé puntos dos veces
            // Destroy(gameObject);
        }
    }
}
