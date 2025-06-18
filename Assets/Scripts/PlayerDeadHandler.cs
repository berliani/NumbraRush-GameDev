using UnityEngine;

public class PlayerDeadHandler : MonoBehaviour
{
   private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.CompareTag("Water"))
        {
            isDead = true;
            Debug.Log("Player jatuh ke air!");
            GameManager.Instance.ShowGameOverPanel();
        }
    }
}
