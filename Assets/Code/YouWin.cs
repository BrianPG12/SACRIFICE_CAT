using UnityEngine;

public class YouWin : MonoBehaviour
{
    private GameObject floor;
    private GameObject player;

    [Header("UI")]
    [SerializeField] private GameObject WIN;

    [Header("Audio")]
    [SerializeField] private AudioClip winSound;
    private AudioSource audioSource;

    [SerializeField] private float MaxY;

    private Transform spawnging;
    [SerializeField] private GameObject Wincat;

    private void Start()
    {
        floor = GameObject.Find("Floor");
        MaxY = floor.transform.position.y + floor.transform.localScale.y / 2;
        player = GameObject.Find("Player");

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (player == null)
            return;

        if (player.transform.position.y > MaxY)
        {
            spawnging = player.transform;
            if (winSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(winSound);
            }

            WIN.SetActive(true);
            Destroy(player);
            Instantiate(Wincat, new Vector3(spawnging.position.x, spawnging.position.y - 4, spawnging.position.z), Quaternion.identity);
        }
    }
}
