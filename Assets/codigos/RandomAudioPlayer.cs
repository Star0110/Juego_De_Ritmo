using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource mainAudioSource;
    public AudioSource secondaryAudioSource;

    private bool isPlaying = false; // Para controlar la corrutina

    void Start()
    {
        
        if (mainAudioSource == null || secondaryAudioSource == null)
        {
            Debug.LogError("Asegúrate de asignar los AudioSource correctamente.");
            return;
        }
    }

    void Update()
    {
        // Inicia la reproducción de sonidos al presionar una tecla
        if (Input.GetKeyDown(KeyCode.RightArrow) && !isPlaying)
        {
            isPlaying = true;
            StartCoroutine(PlayRandomAudioUntilMainEnds());
        }
    }

    private System.Collections.IEnumerator PlayRandomAudioUntilMainEnds()
    {
        while (mainAudioSource.isPlaying)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            AudioClip randomClip = audioClips[randomIndex];

            secondaryAudioSource.clip = randomClip;
            secondaryAudioSource.Play();

            yield return new WaitForSeconds(randomClip.length);
        }

        secondaryAudioSource.Stop();
        isPlaying = false; // Permite reiniciar si se desea
        Debug.Log("La canción principal ha terminado. Deteniendo sonidos secundarios.");
    }
}
