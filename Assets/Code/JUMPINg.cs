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

    [SerializeField] private Animator anime;

    private string jumpstate;

    void Start()
    {
        anime.GetComponent<Animator>();

        player = gameObject;
        audioSource = GetComponent<AudioSource>();

        MaxX = Floor.transform.localScale.x / 2 - 1f;
        MinX = -Floor.transform.localScale.x / 2 + 1f;

        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;

        anime.SetBool("Jump", false);
        anime.SetBool("Backwards", false);
        anime.SetBool("Left", false);
        anime.SetBool("Right", false);
    }

    private bool jumping = false;
    [SerializeField, Range(0, 10)] private float jumpDistance = 1f;
    void Update()
    {
        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && !jumping))
            if (player.transform.position.x < MaxX)
            {
                jumpstate = "Right";
                MovePlayer(new Vector2(jumpDistance, 0));
            } 

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && !jumping)
            if (player.transform.position.x > MinX)
            {
                jumpstate = "Left";
                MovePlayer(new Vector2(-jumpDistance, 0));
            }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && !jumping)
            if (player.transform.position.y < MaxY)
            { 
                jumpstate = "Jump";
                MovePlayer(new Vector2(0, jumpDistance));
            }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && !jumping)
            if (player.transform.position.y > MinY)
            {
                jumpstate = "Backwards";
                MovePlayer(new Vector2(0, -jumpDistance));
            }
    }

    [SerializeField, Range(0, 10)] private float Distance = 1f;
    private void MovePlayer(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Distance);

        if (hit.collider != null && hit.collider.CompareTag("Obstacle"))
            return;
        else
        {
            anime.SetBool(jumpstate, true);
            jumping = true;

            StartCoroutine(StopJumping(direction));

            
            // Play movement sound
            if (moveSound != null && audioSource != null)
                audioSource.PlayOneShot(moveSound);

        }
    }

    IEnumerator StopJumping(Vector2 direction)
    {
        yield return new WaitForSeconds(.5f);

        player.transform.position += (Vector3)direction; 
        anime.SetBool(jumpstate, false);
        jumping = false;
    }
}
