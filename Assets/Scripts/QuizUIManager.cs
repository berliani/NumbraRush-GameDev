using UnityEngine;
using UnityEngine.UI;

public class QuizUIManager : MonoBehaviour
{
    public static QuizUIManager Instance;

    public GameObject quizPanel;
    public Text questionText;
    public Button[] answerButtons;

    private int correctAnswerIndex;

    void Awake()
    {
        Instance = this;
        quizPanel.SetActive(false);
    }

    public void ShowQuestion(string question, string[] choices, int correctIndex)
    {
        quizPanel.SetActive(true);
        questionText.text = question;
        correctAnswerIndex = correctIndex;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            int index = i;
            answerButtons[i].GetComponentInChildren<Text>().text = choices[i];
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => AnswerSelected(index));
        }

        Debug.Log("Menampilkan pertanyaan: " + question);
        Debug.Log("Jumlah tombol: " + answerButtons.Length);
    }

    void AnswerSelected(int index)
    {
        Debug.Log("Tombol ke-" + index + " dipilih");

        if (index == correctAnswerIndex)
            Debug.Log("Jawaban Benar!");
        else
            Debug.Log("Jawaban Salah!");

        quizPanel.SetActive(false);
    }
}
