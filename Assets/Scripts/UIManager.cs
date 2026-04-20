using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Referencias UI")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoVidas;

    private void Awake()
    {
        // Solo inicializaba la instancia
        Instance = this;
    }

    private void Start()
    {
        // Llamaba a la actualización al arrancar
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        if (GameManager.Instance == null) return;

        // Buscaba las variables directamente del GameManager
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntaje: " + GameManager.Instance.puntaje;

        if (textoVidas != null)
            textoVidas.text = "Vidas: " + GameManager.Instance.vidasActuales;
    }
}