using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;

    public void AbrirMenu()
    {
        Debug.Log("Menu abierto");
        menuPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinuarJuego()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void IrMenuInicio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuInicio");
    }
}
