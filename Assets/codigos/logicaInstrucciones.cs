using UnityEngine;

public class logicaInstrucciones : MonoBehaviour
{
    public Canvas CanvasJuego;
    public Canvas CanvasInstrucciones;
    public GameObject AudioManager;

    private AudioSource sonidoGeneral;

    // Propiedad pública para que otros scripts puedan leer el estado de 'ban'.
    public bool ban=false;

    void Start()
    {
        ban = false;

        if (CanvasInstrucciones != null)
            CanvasInstrucciones.gameObject.SetActive(true);

        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(false);

        if (AudioManager != null)
        {
            sonidoGeneral = AudioManager.GetComponent<AudioSource>();
            if (sonidoGeneral == null)
                Debug.LogError("No se encontró un AudioSource en el AudioManager.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter presionado, iniciando juego...");
            ban = true;
            PonerJuego();
        }
    }

    private void PonerJuego()
    {
        if (CanvasInstrucciones != null)
            CanvasInstrucciones.gameObject.SetActive(false);
            
        if (sonidoGeneral != null)
        {
            sonidoGeneral.Play();
            Debug.Log("Audio del juego iniciado.");
        }
        else
        {
            Debug.LogWarning("No hay AudioSource configurado para iniciar.");
        }

        if (CanvasJuego != null)
            CanvasJuego.gameObject.SetActive(true);

        

        Debug.Log("Juego iniciado.");
    }
}
