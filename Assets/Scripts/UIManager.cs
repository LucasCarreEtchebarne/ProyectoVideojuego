using UnityEngine;
using TMPro; // Requiere TextMeshPro (incluido en Unity)

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Referencias UI")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoVidas;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Actualiza los textos en pantalla con los valores del GameManager
    public void ActualizarUI()
    {
        if (GameManager.Instance == null) return;

        textoPuntaje.text = "Puntaje: " + GameManager.Instance.puntaje;
        textoVidas.text   = "Vidas: "   + GameManager.Instance.vidasActuales;
    }
}

