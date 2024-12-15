using UnityEngine;
using UnityEngine.SceneManagement;
public class menuPerder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Repetir(){
      Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MenuPrincipal(){
      SceneManager.LoadScene("menuInicial");
    }
}
