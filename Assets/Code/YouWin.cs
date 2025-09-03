using UnityEngine;

public class YouWin : MonoBehaviour
{
    private GameObject floor;
    private GameObject player;
    [SerializeField] private GameObject WIN;

    [SerializeField] private float MaxY;
    private void Start()
    {
        floor = GameObject.Find("Floor");

        MaxY = floor.transform.position.y + floor.transform.localScale.y / 2 ;

        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player == null)
            return;

        if (player.transform.position.y > MaxY)
        { 
            WIN.SetActive(true);
            Destroy(player);
        }
    }
}
