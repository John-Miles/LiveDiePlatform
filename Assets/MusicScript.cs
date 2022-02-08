using UnityEngine;
 
public class MusicScript : MonoBehaviour
{
    private static AudioSource _audioSource;
    public bool isPlaying = false;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
        isPlaying = true;

    }
 
    public void PlayMusic()
    {
        if (isPlaying)
        {
            Debug.Log("Audio is already playing");
        }
        
        if(!isPlaying)
        {
            Debug.Log("Playing audio!");
            _audioSource.Play();
            isPlaying = true;
        }

        
    }
 
    public static void StopMusic()
    {
        _audioSource.Stop();
    }
}
