using UnityEngine;

public class CarHorn : MonoBehaviour
{
    [SerializeField] private AudioClip hornSound;
    private AudioSource audioSource;
    private bool hasHonked = false;

    void Start()
    {
        // Get AudioSource from parent
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasHonked && collision.CompareTag("Player"))
        {
            audioSource.PlayOneShot(hornSound);
            hasHonked = true; // prevents spam
        }
    }
}
