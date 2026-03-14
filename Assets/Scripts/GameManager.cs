using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración")]
    public int vidasMaximas = 3;
    public int vidasActuales;
    public int puntaje = 0;

    private void Awake()
    {
        // Singleton: solo existe una instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        vidasActuales = vidasMaximas;
        UIManager.Instance?.ActualizarUI();
    }

    // Suma puntos y actualiza UI
    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        UIManager.Instance?.ActualizarUI();
    }

    // Resta una vida. Si llegan a 0, termina el juego
    public void PerderVida()
    {
        vidasActuales--;
        UIManager.Instance?.ActualizarUI();

        if (vidasActuales <= 0)
            GameOver();
    }

    private void GameOver()
    {
        Debug.Log("GAME OVER");
        // Recargar la escena actual (puedes cambiar esto por una pantalla de derrota)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
