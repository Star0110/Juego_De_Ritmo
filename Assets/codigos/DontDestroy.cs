using UnityEngine;
using UnityEngine.SceneManagement;

public class noDestruirMusc : MonoBehaviour
{
    private static noDestruirMusc instancia;

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

        if (escenaActual == "SampleScene") 
        {
            Destroy(gameObject);
        }
    }
}
