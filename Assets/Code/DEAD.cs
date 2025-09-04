using UnityEngine;

public class DEAD : MonoBehaviour
{
    private Csmera Csmera;
    private GameObject player;

    [Header("UI")]
    [SerializeField] private GameObject died;

    [Header("Audio")]
    [SerializeField] private AudioClip deathSound; 
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.Find("Player");
        Csmera = GameObject.Find("Main Camera").GetComponent<Csmera>();
        audioSource = GetComponent<AudioSource>();
    }

    public void YOUDEAD()
    {
        // Play death sound
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        Destroy(player);
        died.SetActive(true);
        Csmera.isAlive();
    }
}
