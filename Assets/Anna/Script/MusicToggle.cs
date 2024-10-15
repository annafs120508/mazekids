using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioSource musicSource;  // Referensi ke AudioSource untuk memutar musik
    public Button musicButton;       // Referensi ke UI Button untuk toggle musik
    private bool isMusicOn;          // Status apakah musik menyala atau mati

    void Start()
    {
        // Cek status musik dari PlayerPrefs, default nyala (1 = true)
        isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;

        // Sesuaikan AudioSource dengan status musik
        UpdateMusicState();

        // Tambahkan listener ke tombol untuk toggle musik
        musicButton.onClick.AddListener(ToggleMusic);
    }

    // Fungsi untuk toggle status musik on/off
    void ToggleMusic()
    {
        // Toggle status musik (nyalakan/matikan)
        isMusicOn = !isMusicOn;

        // Simpan status musik ke PlayerPrefs
        PlayerPrefs.SetInt("MusicOn", isMusicOn ? 1 : 0);

        // Perbarui status AudioSource sesuai toggle
        UpdateMusicState();

        // Ubah teks atau gambar pada tombol sesuai status musik
        musicButton.GetComponentInChildren<Text>().text = isMusicOn ? "Music Off" : "Music On";
    }

    // Fungsi untuk memperbarui status musik (play/stop)
    void UpdateMusicState()
    {
        if (isMusicOn)
        {
            musicSource.Play();  // Nyalakan musik
        }
        else
        {
            musicSource.Stop();  // Matikan musik
        }
    }
}
