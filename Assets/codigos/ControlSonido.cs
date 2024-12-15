using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class ControlSonido : MonoBehaviour
{
    public AudioSource audioSource;  // Referencia al AudioSource

    void Start()
    {
        audioSource=GameObject.Find("sonidoGeneral").GetComponent<AudioSource>();
    }

    public void DetenerSonido()
    {
        // Detiene la música cuando se llame a esta función (por ejemplo, al perder)
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}


