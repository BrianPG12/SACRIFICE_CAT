using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject car;

    [SerializeField, Range(0, 5)] private float SpawnTime;
    [SerializeField, Range(.1f,10f)] private float TimeBetweenSpawns = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        InvokeRepeating(nameof(CarSpawn), SpawnTime, TimeBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CarSpawn()
    {
        TimeBetweenSpawns = Random.Range(.5f, 10f);
        Vector2 position = transform.position;
        Vector2Int.RoundToInt(position);
        Instantiate(car, position, Quaternion.identity);
    }
}
