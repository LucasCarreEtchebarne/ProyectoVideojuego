using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Configuración")]
    public float speed = 3f;
    public float jumpForce = 8f;

    [Header("Puntaje por avance")]
    public float distanciaPorPunto = 1f; // cada cuántos metros suma 1 punto
    public int puntosPorAvance = 10;

    private Rigidbody2D rb;
    private int colisionesConSuelo = 0;
    private bool isGrounded => colisionesConSuelo > 0;
    private float xMaxAlcanzado;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xMaxAlcanzado = transform.position.x;
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(move) < 0.5f)
            move = 0f;

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Solo suma si avanza a la derecha por primera vez
        if (transform.position.x > xMaxAlcanzado + distanciaPorPunto)
        {
            xMaxAlcanzado = transform.position.x;
            GameManager.Instance?.SumarPuntos(puntosPorAvance);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            colisionesConSuelo++;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            colisionesConSuelo--;
    }
}