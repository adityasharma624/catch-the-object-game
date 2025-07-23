using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public GameObject speedPowerUpPrefab;

    public float spawnInterval = 1.5f;
    public float xRange = 8f;
    [Range(0f, 1f)]
    public float powerUpChance = 0.2f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        float xPos = Random.Range(-xRange, xRange);
        Vector3 spawnPos = new Vector3(xPos, transform.position.y, 0);

        float random = Random.value;

        if (random < powerUpChance)
        {
            Instantiate(speedPowerUpPrefab, spawnPos, Quaternion.identity);

        }
        else
        {
            Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
        }
    }
}
