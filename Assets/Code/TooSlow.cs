using UnityEngine;

public class TooSlow : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private Camera Cam;

    private DEAD dead;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dead = GameObject.Find("Died").GetComponent<DEAD>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;

        if (player.transform.position.y < Cam.transform.position.y - Cam.orthographicSize)
            dead.YOUDEAD();
    }
}
