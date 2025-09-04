using System.Collections;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform Floor;
    [SerializeField] private Camera Cam;
    [SerializeField] private AudioClip moveSound; 
    private AudioSource audioSource;
    private GameObject player;

    private float MinX;
    private float MaxX;
    private float MinY;
    private float MaxY;

    [SerializeField] private Animation anime;

    void Start()
    {
        anime.GetComponent<Animation>();

        player = gameObject;
        audioSource = GetComponent<AudioSource>();

        MaxX = Floor.transform.localScale.x / 2 - 1f;
        MinX = -Floor.transform.localScale.x / 2 + 1f;

        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;
    }

    void Update()
    {
        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            if (player.transform.position.x < MaxX)
                MovePlayer(new Vector2(1, 0));

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (player.transform.position.x > MinX)
                MovePlayer(new Vector2(-1, 0));

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            if (player.transform.position.y < MaxY)
                MovePlayer(new Vector2(0, 1));

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            if (player.transform.position.y > MinY)
                MovePlayer(new Vector2(0, -1));
    }

    [SerializeField, Range(0,10)] private float Distance = 1f;
    private void MovePlayer(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Distance);

        if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
            return;
        else
        {
            player.transform.position += (Vector3)direction;

            anime.Stop();

            anime.Play();

            // Play movement sound
            if (moveSound != null && audioSource != null)
                audioSource.PlayOneShot(moveSound);
        }
    }
}
