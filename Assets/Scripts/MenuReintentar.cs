using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuReintentar : MonoBehaviour
{
    public void Reintentar()
    {
        SceneManager.LoadScene(1);
    }
}