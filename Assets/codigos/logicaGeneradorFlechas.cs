using UnityEngine;

public class logicaGeneradorFlechas : MonoBehaviour
{
    public GameObject[] flechas;
    private float tiempoEntreFlechas;
    public float comienzoTiempo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempoEntreFlechas<=0){
            int random=Random.Range(0,flechas.Length);
            Instantiate(flechas[random], transform.position, Quaternion.identity);

            tiempoEntreFlechas=comienzoTiempo;
        }
        else{
            tiempoEntreFlechas-=Time.deltaTime;
        }
    }
}