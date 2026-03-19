
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInvulnerable = 1.5f;
    private bool esInvulnerable = false;
    private static bool dañoEnProceso = false; // ← Bloqueo global

    private void OnEnable()
    {
        dañoEnProceso = false; // Reset al reiniciar el nivel
    }

    public void RecibirDaño()
    {
        if (esInvulnerable) return;
        if (dañoEnProceso) return; // ← Evita múltiples llamadas

        dañoEnProceso = true;
        esInvulnerable = true;

        GameManager.Instance?.PerderVida();
    }
}
