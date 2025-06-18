using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Debug.Log("Load Level: " + levelName);
        SceneManager.LoadScene(levelName);
    }
}
