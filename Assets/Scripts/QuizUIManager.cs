using UnityEngine;
using UnityEngine.UI;

public class QuizUIManager : MonoBehaviour
{
    public static QuizUIManager Instance;

    public GameObject quizPanel;
    public Text questionText;
    public Button[] answerButtons;
    public Text FeedbackAnswer;
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
    questionText.gameObject.SetActive(false); // sembunyikan soal

    if (index == correctAnswerIndex)
    {
        FeedbackAnswer.text = "Jawaban Benar!";
        FeedbackAnswer.color = Color.green;
        SoundManager.Instance.PlayCorrectSound(); 
        Debug.Log("Jawaban Benar!");
        GameManager.Instance.TambahPoin(2);
    }
    else
    {
        FeedbackAnswer.text = "Jawaban Salah!";
        FeedbackAnswer.color = Color.red;
        SoundManager.Instance.PlayWrongSound(); 
        Debug.Log("Jawaban Salah!");
    }

    FeedbackAnswer.gameObject.SetActive(true);

    Invoke(nameof(ResetUI), 1f); // tampilkan ulang soal dan tutup quiz setelah 2 detik
    FindObjectOfType<QuestionProgres>().TambahJawaban();

}

void ResetUI()
{
    questionText.gameObject.SetActive(true);
    FeedbackAnswer.gameObject.SetActive(false);
    quizPanel.SetActive(false);
}


void HideQuizPanel()
{
    quizPanel.SetActive(false);
    FeedbackAnswer.text = ""; // reset
}

}
