using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public Transform topLeftBound;
    public Transform bottomRightBound;

    public float minSpawnTimeLength;
    public float maxSpawnTimeLength;
    float spawnTimer;

    public GameObject[] trashPrefabs;

    void Start()
    {
        spawnTimer = Random.Range(minSpawnTimeLength, maxSpawnTimeLength);
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            spawnTimer = Random.Range(minSpawnTimeLength, maxSpawnTimeLength);
            float diceRoll = Random.Range(1, 101);
            if (diceRoll >= 1 && diceRoll < 75)
                Instantiate(trashPrefabs[0], new Vector2(Random.Range(topLeftBound.position.x, bottomRightBound.position.x), Random.Range(bottomRightBound.position.y, topLeftBound.position.y)), Quaternion.identity);
            else if (diceRoll >= 75 && diceRoll < 98)
                Instantiate(trashPrefabs[1], new Vector2(Random.Range(topLeftBound.position.x, bottomRightBound.position.x), Random.Range(bottomRightBound.position.y, topLeftBound.position.y)), Quaternion.identity);
            else
                Instantiate(trashPrefabs[2], new Vector2(Random.Range(topLeftBound.position.x, bottomRightBound.position.x), Random.Range(bottomRightBound.position.y, topLeftBound.position.y)), Quaternion.identity);
        }
    }
}