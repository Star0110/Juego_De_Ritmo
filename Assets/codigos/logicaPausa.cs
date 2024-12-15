using UnityEngine;
using UnityEngine.SceneManagement;

public class logicaPausa : MonoBehaviour
{
    public Canvas CanvasJuego;
    public Canvas CanvasPausa;
    public Canvas CanvasGanar;
    public Canvas CanvasPerder;
    public logicaGeneradorFlechas generadorFlechas;
    public logicaGeneradorFlechas generadorFlechas2;
    public GameObject AudioManager;
    private AudioSource sonidoGeneral;
    private bool enPausa = false;
    public bool bandera = false;
    public logicaInstrucciones instrucciones;
    public logicaEscena perder;

    void Start()
    {
        if (AudioManager != null)
        {
            sonidoGeneral = AudioManager.GetComponent<AudioSource>();
            if (sonidoGeneral == null)
            {
                Debug.LogError("No se encontró un AudioSource en el AudioManager.");
            }
        }
        else
        {
            Debug.LogError("AudioManager no asignado en el Inspector.");
        }
    }

    void Update()
    {
        // Verifica si el juego no ha terminado
        if (!perder.bandera && 
            (CanvasGanar == null || !CanvasGanar.gameObject.activeSelf) && 
            (CanvasPerder == null || !CanvasPerder.gameObject.activeSelf))
        {
            // Detecta la tecla P para pausar/reanudar
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (enPausa)
                {
                    ReanudarJuego();
                }
                else
                {
                    PausarJuego();
                }
            }
        }
    }

    void PausarJuego()
    {
        enPausa = true;
        bandera = true;

        Time.timeScale = 0;

        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(false);

        if (CanvasPausa != null)
            CanvasPausa.gameObject.SetActive(true);

        if (generadorFlechas != null)
            generadorFlechas.enabled = false;
        if (generadorFlechas2 != null)
            generadorFlechas2.enabled = false;

        if (sonidoGeneral != null && sonidoGeneral.isPlaying)
        {
            sonidoGeneral.Pause();
        }
    }

    void ReanudarJuego()
    {
        enPausa = false;

        Time.timeScale = 1;

        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(true);

        if (CanvasPausa != null)
            CanvasPausa.gameObject.SetActive(false);

        if (generadorFlechas != null)
            generadorFlechas.enabled = true;
        if (generadorFlechas2 != null)
            generadorFlechas2.enabled = true;

        if (sonidoGeneral != null)
        {
            sonidoGeneral.UnPause();
        }
    }
}
