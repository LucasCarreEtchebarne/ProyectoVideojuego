using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInvulnerable = 1.5f; // Segundos de invulnerabilidad tras recibir daño
    private bool esInvulnerable = false;

    // Llamado desde Obstacle.cs o desde FallDetector.cs
    public void RecibirDaño()
    {
        if (esInvulnerable) return;

        GameManager.Instance?.PerderVida();
        StartCoroutine(CooldownInvulnerabilidad());
    }

    private System.Collections.IEnumerator CooldownInvulnerabilidad()
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(tiempoInvulnerable);
        esInvulnerable = false;
    }
}
