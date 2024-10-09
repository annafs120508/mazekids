using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    // Method untuk menyalakan dan mematikan musik
    public void ToggleMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();  // Menghentikan musik sepenuhnya
        }
        else
        {
            musicSource.Play();  // Memulai musik dari awal
        }
    }
}
