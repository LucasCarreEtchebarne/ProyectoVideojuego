using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Referencias")]
    public Transform jugador;

    [Header("Configuración")]
    public float velocidadSeguimiento = 5f;
    public Vector3 offset = new(2,1,-10);
    // X positivo → la cámara va un poco adelante del jugador
    // Y positivo → la cámara va un poco arriba
    // Z debe ser -10 siempre en juegos 2D

    [Header("Seguimiento por eje")]
    public bool seguirX = true;
    public bool seguirY = false; // En false, la cámara no sube/baja con el jugador

    private void LateUpdate()
    {
       
        // LateUpdate se ejecuta después del Update del jugador,
        // evitando que la cámara "tiemble"

        Vector3 posObjetivo = transform.position;

        if (seguirX)
            posObjetivo.x = jugador.position.x + offset.x;

        if (seguirY)
            posObjetivo.y = jugador.position.y + offset.y;

        posObjetivo.z = offset.z; // Siempre mantener Z fijo

        // Interpolación suave hacia la posición objetivo
        transform.position = Vector3.Lerp(
            transform.position,
            posObjetivo,
            velocidadSeguimiento * Time.deltaTime
        );
    }
}
