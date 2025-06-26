using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject finishPanel;
    public GameObject GameOverPanel;
    public TMP_Text skorText;
    public int poin = 0;

    private void Awake()
    {
        Instance = this;
        finishPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    public void TambahPoin(int jumlah)
    {
        poin += jumlah;
    }

    public void ShowFinishPanel()
{
    finishPanel.SetActive(true);
    skorText.text = "Poin kamu: " + poin;
    Time.timeScale = 0f;

    int levelIndex = PlayerPrefs.GetInt("CurrentLevel", 1); // default ke 1
    string key = "Level" + levelIndex + "_Point";

    PlayerPrefs.SetInt(key, poin);
    PlayerPrefs.Save();
}



    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ShowGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
