using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [Header("Universal spawn parameters")]
    [SerializeField] Virus[] prefabs = null;
    [SerializeField] Transform[] parents = null;

    [SerializeField] Vector2 maxSpawnRange = new Vector2(10, 4);

    [Header("Virus spawn amount")]
    [SerializeField] int green = 2;
    [SerializeField] int orange = 2;
    [SerializeField] int red = 2;
    [SerializeField] int blue = 2;


    private void Start()
    {
        for (int i = 0; i < green; i++)
        {
            SpawnVirus(prefabs[0], parents[0]);
        }
        for (int i = 0; i < orange; i++)
        {
            SpawnVirus(prefabs[1], parents[1]);
        }
        for (int i = 0; i < red; i++)
        {
            SpawnVirus(prefabs[2], parents[2]);
        }
        for (int i = 0; i < blue; i++)
        {
            SpawnVirus(prefabs[3], parents[3]);
        }
    }

    void SpawnVirus(Virus virus, Transform parent)
    {
        float x = Random.Range(0, maxSpawnRange.x * 2 + 1) - maxSpawnRange.x;
        float y = Random.Range(0, maxSpawnRange.y * 2 + 1) - maxSpawnRange.y;
        Vector2 position = new Vector2(x, y);
        Instantiate(virus, position, Quaternion.identity, parent);
    }
}
