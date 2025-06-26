using UnityEngine;
using TMPro;

public class LevelPointsDisplay : MonoBehaviour
{
    [System.Serializable]
    public class LevelInfo
    {
        public string levelKey;           // Contoh: "Level1_Point"
        public TMP_Text poinText;         // Arahkan ke Text poin di tombol
    }

    public LevelInfo[] levels;

    void Start()
    {
        foreach (LevelInfo level in levels)
        {
            int poin = PlayerPrefs.GetInt(level.levelKey, -1); // -1 artinya belum pernah main

            if (poin >= 0)
                level.poinText.text = "Poin: " + poin;
            else
                level.poinText.text = "Belum dimainkan";
        }
    }
}
