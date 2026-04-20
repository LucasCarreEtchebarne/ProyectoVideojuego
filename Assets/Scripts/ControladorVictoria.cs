using UnityEngine;
using TMPro;

public class ControladorVictoria : MonoBehaviour
{
    [Header("Referencias de Texto Internas")]
    public TextMeshProUGUI textoPuntajeFinal;
    public TextMeshProUGUI textoVidasFinal;

    // Este método se ejecuta AUTOMÁTICAMENTE cada vez que el panel se activa
    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            // Le pedimos los datos directamente al GameManager
            textoPuntajeFinal.text = "Puntaje Final: " + GameManager.Instance.puntaje;
            textoVidasFinal.text = "Vidas Restantes: " + GameManager.Instance.vidasActuales;
        }

        // Pausamos el juego y liberamos el mouse
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Función para el botón de Reiniciar (opcional)
    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        // Aquí podrías llamar a GameManager.Instance.ReiniciarNivel() o cargar la escena
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}