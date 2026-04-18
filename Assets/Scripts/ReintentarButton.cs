using UnityEngine;
using UnityEngine.SceneManagement;

public class ReintentarButton : MonoBehaviour
{
    public void Reintentar()
    {
        SceneManager.LoadScene(1);
    }
}