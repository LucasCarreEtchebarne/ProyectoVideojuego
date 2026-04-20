using UnityEngine;

public class MetaNivel : MonoBehaviour
{
    [Header("Configuración")]
    public GameObject panelVictoria;

    // ¡ESTA ES LA VERSIÓN 2D!
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug para confirmar en consola
        Debug.Log("Algo tocó la meta 2D: " + other.name);

        if (other.CompareTag("Player"))
        {
            if (panelVictoria != null)
            {
                panelVictoria.SetActive(true);
                Debug.Log("¡Panel Victoria activado!");
            }
        }
    }
}