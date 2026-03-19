using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Referencias")]
    public Transform jugador;

    [Header("Configuración")]
    public float velocidadSeguimiento = 5f;
    public Vector3 offset = new Vector3(0, 0, -10);

    [Header("Seguimiento por eje")]
    public bool seguirX = true;
    public bool seguirY = false;

    private void Start()
    {
        if (jugador == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
                jugador = obj.transform;
        }

        if (jugador != null)
        {
            Vector3 posInicial = jugador.position + offset;
            posInicial.z = offset.z;
            transform.position = posInicial;
        }
    }

    private void LateUpdate()
    {
        if (jugador == null) return;

        Vector3 posObjetivo = transform.position;

        if (seguirX)
            posObjetivo.x = jugador.position.x + offset.x;
        if (seguirY)
            posObjetivo.y = jugador.position.y + offset.y;

        posObjetivo.z = offset.z;

        transform.position = Vector3.Lerp(
            transform.position,
            posObjetivo,
            velocidadSeguimiento * Time.deltaTime
        );
    }
}
