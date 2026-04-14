using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volumeSlider;

    void Start()
    {
        // Cargar volumen guardado (si existe)
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Escuchar cambios del slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;

        // Guardar volumen
        PlayerPrefs.SetFloat("volume", volume);
    }
}