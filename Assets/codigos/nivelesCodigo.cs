using UnityEngine;
using UnityEngine.SceneManagement;

public class nivelesCodigo : MonoBehaviour
{
    public void Nivel1(){
     Time.timeScale = 1;
         SceneManager.LoadScene("SampleScene");
    }
    public void Nivel2(){
     Time.timeScale = 1;
         SceneManager.LoadScene("nivel2");

    }
    public void Nivel3(){
     Time.timeScale = 1;
         SceneManager.LoadScene("nivel3");

    }
    public void Turnos(){
     Time.timeScale = 1;
         SceneManager.LoadScene("nivelConIa");

    }
    public void Home(){
     Time.timeScale = 1;
        SceneManager.LoadScene("menuInicial");
    }
}


