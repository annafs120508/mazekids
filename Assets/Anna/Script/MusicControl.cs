using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public AudioSource musicSource;  // Reference ke AudioSource
    public Button toggleButton;      // Reference ke Button UI
    private bool isPlaying = true;   // Status musik (On atau Off)

    void Start()
    {
        // Menambahkan listener ke button untuk memanggil ToggleMusic saat diklik
        toggleButton.onClick.AddListener(ToggleMusic);
    }

    // Fungsi untuk On/Off musik
    void ToggleMusic()
    {
        if (isPlaying)
        {
            musicSource.Pause();    // Jika musik sedang main, hentikan (Pause)
        }
        else
        {
            musicSource.Play();     // Jika musik mati, nyalakan lagi (Play)
        }
        isPlaying = !isPlaying;     // Ubah status isPlaying
    }
}
