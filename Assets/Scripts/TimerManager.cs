using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 90f; // 1 menit 30 detik
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    private bool timerIsRunning = true;

    void Start()
    {
        UpdateTimerDisplay();
        gameOverPanel.SetActive(false); // sembunyikan panel game over di awal
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay();
                TriggerGameOver();
            }
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TriggerGameOver()
{
    Debug.Log("Waktu Habis!");
    gameOverPanel.SetActive(true);

    // Panggil kekalahan karena waktu habis dari PlayerDeadHandler
    PlayerDeadHandler playerDeadHandler = FindObjectOfType<PlayerDeadHandler>();
    if (playerDeadHandler != null)
    {
        playerDeadHandler.HandleTimeOutDeath();
    }
}
}
