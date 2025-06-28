using UnityEngine;
using UnityEngine.UI;

public class LevelUnlockManager : MonoBehaviour
{
    public Button[] levelButtons; // Assign di Inspector
    public GameObject lockWarningPanel; // Panel notifikasi

   void Start()
{
    lockWarningPanel.SetActive(false);

    for (int i = 0; i < levelButtons.Length; i++)
    {
        int levelIndex = i + 1;
        int prevLevel = levelIndex - 1;
        bool isUnlocked = true;

        if (levelIndex > 1)
        {
            int prevScore = PlayerPrefs.GetInt("Level" + prevLevel + "_Point", 0);
            if (prevScore <= 0)
                isUnlocked = false;
        }

        int capturedLevel = levelIndex; // buat salinan lokal

        if (isUnlocked)
        {
            levelButtons[i].onClick.AddListener(() => LoadLevel(capturedLevel));
        }
        else
        {
            levelButtons[i].onClick.AddListener(() => ShowLockWarning());
        }
    }
}



   void LoadLevel(int level)
{
    PlayerPrefs.SetInt("CurrentLevel", level);
    string sceneName = "gameplay-" + level;
    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
}


    void ShowLockWarning()
    {
        lockWarningPanel.SetActive(true);
        Invoke(nameof(HideLockWarning), 2f); // otomatis sembunyi 2 detik
    }

    void HideLockWarning()
    {
        lockWarningPanel.SetActive(false);
    }
}
