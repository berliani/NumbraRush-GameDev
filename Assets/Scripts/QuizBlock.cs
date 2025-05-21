using UnityEngine;

public class QuizBlock : MonoBehaviour
{
    private bool triggered = false;

    public string question = "3 + 2 = ?";
    public string[] choices = { "4", "5", "6" };
    public int correctIndex = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (triggered) return;
        if (collision.collider.CompareTag("Player") && collision.contacts[0].normal.y > 0.5f)
        {
            triggered = true;
            QuizUIManager.Instance.ShowQuestion(question, choices, correctIndex);
        }
    }
}
