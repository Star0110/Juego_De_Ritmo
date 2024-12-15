using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class logicaJugadorIa : MonoBehaviour
{
    public int puntaje = 0;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI mensajeTurno; // Texto que muestra de quién es el turno
    public bool esTurnoJugador = true; // Bandera para alternar turnos
    public float duracionTurno = 5f; // Duración de cada turno (en segundos)
    private float tiempoRestanteTurno;

    void Start()
    {
        texto = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        mensajeTurno = GameObject.Find("MensajeTurno").GetComponent<TextMeshProUGUI>();
        tiempoRestanteTurno = duracionTurno;
        ActualizarMensajeTurno();
    }

    void Update()
    {
        tiempoRestanteTurno -= Time.deltaTime;

        if (tiempoRestanteTurno <= 0)
        {
            CambiarTurno();
            tiempoRestanteTurno = duracionTurno;
            ActualizarMensajeTurno();
        }
    }

    void CambiarTurno()
    {
        esTurnoJugador = !esTurnoJugador; // Alternar entre el turno del jugador y de la IA
    }

    void ActualizarMensajeTurno()
    {
        if (esTurnoJugador)
        {
            mensajeTurno.text = "¡Es tu turno!";
        }
        else
        {
            mensajeTurno.text = "Turno de la IA...";
        }
    }
}
