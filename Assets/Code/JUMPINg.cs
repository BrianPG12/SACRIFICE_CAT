using UnityEngine;

public class Jumping : MonoBehaviour
{
    [SerializeField] private Transform Floor;
    [SerializeField] private Camera Cam;
    private GameObject player;

    private float MinX;
    private float MaxX;

    private float MinY;
    private float MaxY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = gameObject;

        MaxX = Floor.transform.localScale.x / 2 - 1f;
        MinX = -Floor.transform.localScale.x / 2 + 1f;

        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        MinY = Cam.transform.position.y - Cam.orthographicSize + 1f;
        MaxY = Cam.transform.position.y + Cam.orthographicSize - 1f;

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            if (player.transform.position.x < MaxX)
                player.transform.position = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            if (player.transform.position.x > MinX)
                player.transform.position = new Vector3(player.transform.position.x - 1, player.transform.position.y, player.transform.position.z);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            if (player.transform.position.y < MaxY)
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            if (player.transform.position.y > MinY)
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 1, player.transform.position.z);
    }
}
