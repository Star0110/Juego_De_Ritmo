using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
     
        string escenaActual = SceneManager.GetActiveScene().name;

        if (escenaActual == "SampleScene" || escenaActual == "nivel2" || escenaActual=="nivel3" || escenaActual=="nivelConIa") 
        {
            Destroy(gameObject);
        }
        
        
    }
}
