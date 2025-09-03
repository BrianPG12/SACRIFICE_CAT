using UnityEngine;

public class MovementCar : MonoBehaviour
{
    private float MaxX;
    [SerializeField] private GameObject floor;

    private void OnEnable()
    {
        floor = GameObject.Find("Floor");

        MaxX = floor.GetComponent<SpriteRenderer>().bounds.size.x / 2 + 1;
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * 5);

        if (gameObject.transform.position.x > MaxX)
            Destroy(gameObject);
    }
}
