using UnityEngine;

public class logicaIA : MonoBehaviour
{
    private logicaJugadorIa logicaJugadorIa;

    void Start()
    {
        // Referencia al script de logicaJugadorIa para acceder a la puntuación y turno
        logicaJugadorIa = GameObject.Find("casillaJugador").GetComponent<logicaJugadorIa>();
    }

    void Update()
    {
        // Verifica si es el turno de la IA
        if (!logicaJugadorIa.esTurnoJugador)
        {
            // Llama a la función para procesar las flechas
            ProcesarFlechas("Flecha", KeyCode.DownArrow); // Para flechas hacia abajo
            ProcesarFlechas("Flecha", KeyCode.UpArrow);   // Para flechas hacia arriba
            ProcesarFlechas("Flecha", KeyCode.LeftArrow); // Para flechas hacia la izquierda
            ProcesarFlechas("Flecha", KeyCode.RightArrow);// Para flechas hacia la derecha
        }
    }

    // Función para procesar las flechas y verificar si están en el área de acierto
    void ProcesarFlechas(string tagFlecha, KeyCode teclaSimulada)
    {
        // Encuentra todas las flechas de tipo "Flecha"
        GameObject[] flechas = GameObject.FindGameObjectsWithTag(tagFlecha);

        foreach (GameObject flecha in flechas)
        {
            bool enAreaDeAcierto = false;

            // Verificar el componente específico de cada flecha
            if (flecha.GetComponent<logicaFlechaAbajoNiv4>() != null)
            {
                // Flecha hacia abajo
                var logicaFlecha = flecha.GetComponent<logicaFlechaAbajoNiv4>();
                enAreaDeAcierto = logicaFlecha.estaEnAreaDeAcierto();
            }
            else if (flecha.GetComponent<logicaFlechaArribaIA>() != null)
            {
                // Flecha hacia arriba
                var logicaFlecha = flecha.GetComponent<logicaFlechaArribaIA>();
                enAreaDeAcierto = logicaFlecha.estaEnAreaDeAcierto();
            }
            else if (flecha.GetComponent<logicaFlechaIzquierdaIA>() != null)
            {
                // Flecha hacia la izquierda
                var logicaFlecha = flecha.GetComponent<logicaFlechaIzquierdaIA>();
                enAreaDeAcierto = logicaFlecha.estaEnAreaDeAcierto();
            }
            else if (flecha.GetComponent<logicaFlechaDerechaIA>() != null)
            {
                // Flecha hacia la derecha
                var logicaFlecha = flecha.GetComponent<logicaFlechaDerechaIA>();
                enAreaDeAcierto = logicaFlecha.estaEnAreaDeAcierto();
            }

            // Si la flecha está en el área de acierto, aumenta el puntaje y "presiona" la tecla
            if (enAreaDeAcierto)
            {
                AumentarPuntaje(flecha, teclaSimulada);
                break; // Procesa solo una flecha por actualización
            }
        }
    }

    // Simula la acción de "presionar" la tecla para aumentar la puntuación
    void AumentarPuntaje(GameObject flecha, KeyCode tecla)
    {
        // Aumenta la puntuación del jugador
        logicaJugadorIa.puntaje++;
        logicaJugadorIa.texto.text = "Score: " + logicaJugadorIa.puntaje.ToString();

        // Destruye la flecha después de simular que fue "presionada"
        Destroy(flecha);
    }
}

