using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Configuración")]
    public float tiempoInvulnerable = 1.5f;
    private float timerInvulnerable = 0f;
    private bool esInvulnerable = false;

    void Update()
    {
        if (esInvulnerable)
        {
            timerInvulnerable -= Time.deltaTime;
            if (timerInvulnerable <= 0f)
                esInvulnerable = false;
        }
    }

    public void RecibirDaño()
    {
        if (esInvulnerable) return;

        esInvulnerable = true;
        timerInvulnerable = tiempoInvulnerable;

        GameManager.Instance?.PerderVida();
    }
}