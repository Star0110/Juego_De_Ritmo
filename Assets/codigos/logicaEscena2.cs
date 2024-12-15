using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class logicaEscena2 : MonoBehaviour
{
    public GameObject AudioManager;
    public bool bandera;
    public Canvas CanvasJuego;
    public Canvas CanvasPerder;
    public logicaJugadorIa logicaJugador;  
    public TextMeshProUGUI ScorePerder; 
    public TextMeshProUGUI ScorePerder2;
    private AudioSource sonidoGeneral;
    public logicaInstrucciones instrucciones;
   
    void Start()
    {

        bandera=false;
        if (AudioManager != null)
        {
            sonidoGeneral = AudioManager.GetComponent<AudioSource>();
            if (sonidoGeneral == null)
                Debug.LogError("No se encontró un AudioSource en el AudioManager.");
        }
        else
        {
            Debug.LogError("AudioManager no asignado en el Inspector.");
        }
        if(instrucciones.ban){
        if (CanvasPerder != null)
            CanvasPerder.gameObject.SetActive(false);

        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bandera=true;
        if (collision.gameObject.tag == "Flecha")
        {
            FinDelJuego();
        }
    }
    void FinDelJuego()
{
    if (CanvasJuego != null)
        CanvasJuego.gameObject.SetActive(false);

    if (CanvasPerder != null)
    {
        CanvasPerder.gameObject.SetActive(true);

        if (logicaJugador != null)
        {
            int puntajeFinal = logicaJugador.puntaje;

            if (ScorePerder != null && ScorePerder2 != null)
            {
                ScorePerder.text = "Score: " + puntajeFinal.ToString();
                ScorePerder2.text = "Score: " + puntajeFinal.ToString();
            }
        }

        if (sonidoGeneral != null && sonidoGeneral.isPlaying)
            sonidoGeneral.Stop();

        // Reproducir audio del CanvasPerder
        AudioSource perderAudio = CanvasPerder.GetComponentInChildren<AudioSource>();
        if (perderAudio != null)
        {
            perderAudio.mute = false;
            perderAudio.volume = 1.0f; // Configurar el volumen
            perderAudio.Play();
            Debug.Log("Audio de perder reproducido.");
        }
        else
        {
            Debug.LogError("No se encontró un AudioSource en el CanvasPerder.");
        }
}

}
}