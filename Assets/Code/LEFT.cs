using UnityEngine;

public class Left : MonoBehaviour
{
    private float MinX;
    [SerializeField] private GameObject floor;

    private void OnEnable()
    {
        floor = GameObject.Find("Floor");

        MinX = -floor.GetComponent<SpriteRenderer>().bounds.size.x / 2 - 1;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime * 5);

        if (gameObject.transform.position.x < MinX)
            Destroy(gameObject);
    }
}
