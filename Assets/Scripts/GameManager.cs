using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Configuración")]
    public int vidasMaximas = 3;
    public int vidasActuales;
    public int puntaje = 0;

    private bool inicializado = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!inicializado)
        {
            vidasActuales = vidasMaximas;
            inicializado = true;
        }
        StartCoroutine(ActualizarUIDelayed());
    }

    private IEnumerator ActualizarUIDelayed()
    {
        yield return null;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (UIManager.Instance != null)
            UIManager.Instance.ActualizarUI();
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        ActualizarUI();
    }

    public void PerderVida()
    {
        vidasActuales--;
        puntaje = 0;
        Debug.Log("Vidas restantes: " + vidasActuales);
        ActualizarUI();

        if (vidasActuales <= 0)
        {
            Debug.Log("GAME OVER activado");
            GameOver();
        }
        else
        {
            Debug.Log("Reiniciando nivel, vidas: " + vidasActuales);
            ReiniciarNivel();
        }
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(1);
    }

    private void GameOver()
    {
        inicializado = false;
        vidasActuales = vidasMaximas;
        puntaje = 0;
        SceneManager.LoadScene(0);
    }
}