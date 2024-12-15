using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class logicaJugador:MonoBehaviour
{
    public int puntaje=0;
    public TextMeshProUGUI texto;
    public int contador=0;
    public bool adentro=false;
    void Start(){
        texto=GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    void Update(){
       
    }
}
