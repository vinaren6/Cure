using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [Header("Universal spawn parameters")]
    [SerializeField] Virus[] virusPrefab = null;
    [SerializeField] Transform[] parents = null;

    [SerializeField] int maxXSpawnPoint = 10;
    [SerializeField] int maxYSpawnPoint = 4;

    [Header("Green virus spawn parameters")]
    [SerializeField] int greenSpawnAmount = 2;

    [Header("Orange virus spawn parameters")]
    [SerializeField] int orangeSpawnAmount = 2;

    [Header("Red virus spawn parameters")]
    [SerializeField] int redSpawnAmount = 2;

    [Header("Blue virus spawn parameters")]
    [SerializeField] int blueSpawnAmount = 2;


    private void Start()
    {
        for (int i = 0; i < greenSpawnAmount; i++)
        {
            SpawnVirus(virusPrefab[0], parents[0]);
        }
        for (int i = 0; i < orangeSpawnAmount; i++)
        {
            SpawnVirus(virusPrefab[1], parents[1]);
        }
        for (int i = 0; i < redSpawnAmount; i++)
        {
            SpawnVirus(virusPrefab[2], parents[2]);
        }
        for (int i = 0; i < blueSpawnAmount; i++)
        {
            SpawnVirus(virusPrefab[3], parents[3]);
        }
    }

    void SpawnVirus(Virus virus, Transform parent)
    {
        float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
        float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
        Vector2 position = new Vector2(x, y);
        Instantiate(virus, position, Quaternion.identity, parent);
    }
}
