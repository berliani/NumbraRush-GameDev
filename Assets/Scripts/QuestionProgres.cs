using UnityEngine;
using TMPro;

public class QuestionProgres : MonoBehaviour
{
    public TMP_Text progressText;
    public int totalSoal = 5;

    private int soalTerjawab = 0;

    void Start()
    {
        UpdateText();
    }

    public void TambahJawaban()
    {
        soalTerjawab++;
        UpdateText();
    }

    void UpdateText()
    {
        progressText.text = soalTerjawab + "/" + totalSoal;
    }
}
