using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
    public void Repetir(){
       Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MenuPrincipal(){
      SceneManager.LoadScene("menuInicial");
    }
}
