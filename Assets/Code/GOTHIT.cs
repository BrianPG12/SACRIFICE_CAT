using UnityEngine;

public class GOTHIT : MonoBehaviour
{
    private GameObject player;

    private DEAD DEAD;
    void Awake()
    {
        player = GameObject.Find("Player");
        DEAD = GameObject.Find("Died").GetComponent<DEAD>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            DEAD.YOUDEAD();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            DEAD.YOUDEAD();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
