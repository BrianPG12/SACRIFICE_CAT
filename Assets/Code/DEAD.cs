using UnityEngine;

public class DEAD : MonoBehaviour
{
    private Csmera Csmera;

    private GameObject player;

    [SerializeField] private GameObject died;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");

        Csmera = GameObject.Find("Main Camera").GetComponent<Csmera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void YOUDEAD()
    {
        Destroy(player);
        died.SetActive(true);
        Csmera.isAlive();
    }
}

