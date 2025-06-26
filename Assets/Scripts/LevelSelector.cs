using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel1()
    {
        PlayerPrefs.SetInt("CurrentLevel", 1);
        SceneManager.LoadScene("gameplay");
    }

    public void LoadLevel2()
    {
        PlayerPrefs.SetInt("CurrentLevel", 2);
        SceneManager.LoadScene("gameplay-2");
    }

    public void LoadLevel3()
    {
        PlayerPrefs.SetInt("CurrentLevel", 3);
        SceneManager.LoadScene("gameplay-3");
    }
}

