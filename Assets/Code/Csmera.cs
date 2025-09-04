using Unity.VisualScripting;
using UnityEngine;

public class Csmera : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private float speed = .01f;

    private GameObject player; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        isAlive();
    }

    public bool isAlive() 
    {
        if (player != null)
            return false;
        else
            return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isAlive())
            cam.transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, cam.transform.position.z);
    }
}
