using TMPro;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI potatoCounterText; 

    [Header("Player Settings")]
    [SerializeField] private string potatoTag = "Potato"; 

    [Header("Audio Settings")]
    [SerializeField] private AudioClip collectSound; 
    [SerializeField] private AudioSource audioSource; 

    private int potatoCount = 0;

    void Start()
    {
        
        UpdateUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag(potatoTag))
        {
          
            potatoCount++;
           
            UpdateUI();

            
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

          
            Destroy(collision.gameObject);
        }
    }

    private void UpdateUI()
    {
        potatoCounterText.text = " " + potatoCount;
    }
}
