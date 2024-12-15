using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void Jugar(){
        SceneManager.LoadScene("menuNiveles");

    }
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
    
}
