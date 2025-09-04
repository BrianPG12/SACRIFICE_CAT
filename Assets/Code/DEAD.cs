using UnityEngine;
using UnityEngine.UIElements;

public class DEAD : MonoBehaviour
{
    private Csmera Csmera;
    private GameObject player;
    private Transform spawnging;
    [SerializeField] private GameObject deadcat;

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

        spawnging = player.transform;
        Destroy(player);
        Instantiate(deadcat, spawnging.position, Quaternion.identity);
        died.SetActive(true);
        Csmera.isAlive();
    }
}
