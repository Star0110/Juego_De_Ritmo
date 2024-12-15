using UnityEngine;



public class logicaFlechaAbajoNiv4 : MonoBehaviour
{
    public float velocidad;
    public int contador=0;
    public bool adentro=false;
 
    void Update()
    {
        transform.position+=transform.up*-velocidad*Time.deltaTime;
        if (contador==2){
            adentro=true;
        }else{
             
            adentro=false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if(adentro){
                GameObject.Find("casillaJugador").GetComponent<logicaJugadorIa>().puntaje++;
                GameObject.Find("casillaJugador").GetComponent<logicaJugadorIa>().texto.text="Score: "+
                    GameObject.Find("casillaJugador").GetComponent<logicaJugadorIa>().puntaje.ToString();
                Destroy(gameObject);
            }
        }
    
    }
    public bool estaEnAreaDeAcierto()
    {
        return adentro; // Retorna true si la flecha está en el área de acierto
    }
    public void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag=="Player"){
            contador++;
        }
    }
    public void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag=="Player"){
            contador--;
            
        }
    }
}
