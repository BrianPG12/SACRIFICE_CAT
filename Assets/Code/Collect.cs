using TMPro;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI potatoCounterText; // UI Counter Text

    [Header("Player Settings")]
    [SerializeField] private string potatoTag = "Potato"; // Tag for potato objects

    private int potatoCount = 0;

    void Start()
    {
        // Initialize UI counter
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if we collided with a potato
        if (collision.CompareTag(potatoTag))
        {
            // Increase counter
            potatoCount++;
            // Update UI
            UpdateUI();
            // Destroy potato object
            Destroy(collision.gameObject);
        }
    }

    private void UpdateUI()
    {
        potatoCounterText.text = "Vegetables: " + potatoCount;
    }
}
