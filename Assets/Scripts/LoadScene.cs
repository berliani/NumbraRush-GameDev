using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject AboutPanel;

    // Ganti scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Keluar game
    public void ExitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit(); // hanya bekerja saat di build
    }

    // Tampilkan About
    public void ShowAbout()
    {
        AboutPanel.SetActive(true);
    }

    // Tutup About
    public void HideAbout()
    {
        AboutPanel.SetActive(false);
    }
}
