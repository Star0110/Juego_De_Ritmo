using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlJuego : MonoBehaviour
{
    public GameObject AudioManager;
    public Canvas CanvasJuego;
    public Canvas CanvasGanar;
    public logicaJugador logicaJugador;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Score2;

    public logicaEscena perder;
    public logicaPausa pausa;
    public logicaInstrucciones instrucciones;

    private AudioSource sonidoGeneral;

    void Start()
    {


            if (AudioManager != null)
            {
                sonidoGeneral = AudioManager.GetComponent<AudioSource>();
                if (sonidoGeneral == null)
                    Debug.LogError("No se encontró un AudioSource en el AudioManager.");
            }
            if (instrucciones.ban==true)
        {
            if (CanvasGanar != null)
                CanvasGanar.gameObject.SetActive(false);

            if (CanvasJuego != null)
                CanvasJuego.gameObject.SetActive(true);
        }

    }

    void Update()
    {
        
        if (instrucciones.ban==true){

        bool bandera = perder.bandera;
        bool banPausa = pausa.bandera;
        

        if (sonidoGeneral != null && 
            !sonidoGeneral.isPlaying && 
            !CanvasGanar.gameObject.activeSelf && 
            !bandera && 
            !banPausa 
            )
        {
            Debug.Log("Llamando a FinDelJuego...");
            FinDelJuego();
        }
        }
    }

    private void FinDelJuego()
    {
        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(false);

        if (CanvasGanar != null)
        {
            CanvasGanar.gameObject.SetActive(true);
            Debug.Log("Canvas de Ganar activado.");

            if (logicaJugador != null)
            {
                int puntajeFinal = logicaJugador.puntaje;

                if (Score != null && Score2 != null)
                {
                    Score.text = "Score: " + puntajeFinal;
                    Score2.text = "Score: " + puntajeFinal;
                    Debug.Log($"Puntaje final: {puntajeFinal}");
                }
            }

            AudioSource ganarAudio = CanvasGanar.GetComponentInChildren<AudioSource>();
            if (ganarAudio != null)
            {
                ganarAudio.Play();
                Debug.Log("Audio del CanvasGanar reproducido.");
            }
            else
            {
                Debug.LogWarning("No se encontró un AudioSource en el CanvasGanar.");
            }
        }
        else
        {
            Debug.LogError("CanvasGanar no está asignado.");
        }
    }
}
