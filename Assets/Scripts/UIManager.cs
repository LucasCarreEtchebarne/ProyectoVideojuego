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
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        Debug.Log("UIManager Start - Vidas: " + GameManager.Instance?.vidasActuales);
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        if (GameManager.Instance == null) return;

        if (textoPuntaje != null)
            textoPuntaje.text = "Puntaje: " + GameManager.Instance.puntaje;

        if (textoVidas != null)
            textoVidas.text = "Vidas: " + GameManager.Instance.vidasActuales;
    }
}

