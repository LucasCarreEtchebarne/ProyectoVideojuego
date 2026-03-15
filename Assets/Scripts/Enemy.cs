using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform jugador;
    public float velocidad = 1.5f;

    private bool empezarPersecucion = false;

    void Update()
    {
        if (!empezarPersecucion) return;

        Vector3 nuevaPosicion = transform.position;
        nuevaPosicion.x += velocidad * Time.deltaTime;

        transform.position = nuevaPosicion;
    }

    public void ActivarPersecucion()
    {
        empezarPersecucion = true;
    }
}