using UnityEngine;
using UnityEngine.UI;

public class BarraDeProceso : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource
    public Slider progressBar;      // Referencia al Slider

    void Start()
    {
        if (audioSource != null && progressBar != null)
        {
            // Configurar el rango de la barra de progreso
            progressBar.minValue = 0;
            progressBar.maxValue = audioSource.clip.length; // Duración total de la canción
            progressBar.value = 0; // Inicializa la barra
        }
    }

    void Update()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            // Actualiza el Slider basado en el tiempo actual del audio
            progressBar.value = audioSource.time;
        }
    }
}

