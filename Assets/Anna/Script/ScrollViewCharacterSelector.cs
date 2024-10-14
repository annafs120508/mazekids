using UnityEngine;
using UnityEngine.UI;

public class ScrollViewCharacterSelector : MonoBehaviour
{
    public ScrollRect scrollRect; // Scroll View yang digunakan
    public RectTransform content; // Konten di dalam Scroll View
    public RectTransform viewport; // Viewport Scroll View
    public float scaleMultiplier = 1.5f; // Skala maksimum di tengah
    public float lerpSpeed = 10f; // Kecepatan peralihan skala
    public float maxDistance = 300f; // Jarak maksimum untuk ukuran minimal

    void Update()
    {
        // Mendapatkan pusat viewport (posisi dalam dunia)
        Vector3 viewportCenter = viewport.position;

        // Looping setiap item di dalam content
        foreach (RectTransform item in content)
        {
            // Mendapatkan posisi item dalam dunia
            Vector3 itemPosition = item.position;

            // Hitung jarak antara item dan pusat viewport
            float distance = Mathf.Abs(viewportCenter.x - itemPosition.x);

            // Menghitung skala berdasarkan jarak
            float scale = Mathf.Lerp(scaleMultiplier, 1f, distance / maxDistance);

            // Terapkan skala dengan smoothing
            item.localScale = Vector3.Lerp(item.localScale, new Vector3(scale, scale, 1), lerpSpeed * Time.deltaTime);
        }
    }
}
