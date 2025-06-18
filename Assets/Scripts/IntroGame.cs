using UnityEngine;

public class IntroGame : MonoBehaviour
{
    public GameObject introPanel;

    void Start()
    {
        // Saat scene dimulai, tampilkan panel intro
        if (introPanel != null)
            introPanel.SetActive(true);

        // Pause gameplay sementara jika ada sistem logic aktif (opsional)
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        // Sembunyikan panel intro dan mulai game
        if (introPanel != null)
            introPanel.SetActive(false);

        Time.timeScale = 1;
    }
}
