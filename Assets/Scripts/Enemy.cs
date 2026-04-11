using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 2f;
    public Transform jugador;

    private bool persiguiendo = false;

    void Start()
    {
        if (jugador == null)
        {
            GameObject obj = GameObject.FindWithTag("Player");
            if (obj != null)
                jugador = obj.transform;
        }
    }

    void Update()
    {
        if (jugador == null) return;

        // Espera hasta que el jugador se mueva
        if (!persiguiendo)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
                persiguiendo = true;
            else
                return;
        }

        Vector3 nuevaPosicion = transform.position;
        nuevaPosicion.x = Mathf.MoveTowards(
            transform.position.x,
            jugador.position.x,
            velocidad * Time.deltaTime
        );
        transform.position = nuevaPosicion;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth health = collision.GetComponent<PlayerHealth>();
            if (health != null)
                health.RecibirDaño();
        }
    }
}