using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelReintentar : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; // por si pausaste el juego

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}
