using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuGanar : MonoBehaviour
{
    public void SigNivel(){
      Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }
    public void MenuPrincipal(){
      SceneManager.LoadScene("menuInicial");
    }
}
