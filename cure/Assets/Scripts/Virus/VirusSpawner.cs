// Code writer: Nicklas 
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [Header("Universal spawn parameters")]
    [SerializeField] Virus[] prefabs = null;
    [SerializeField] Transform[] parents = null;

    [SerializeField] SpriteRenderer background = null;
    [SerializeField] float deadZone = 2f;
    Vector2 spawnArea = new Vector2();

    [Header("Virus spawn amount")]
    [SerializeField] int green = 2;
    [SerializeField] int orange = 2;
    [SerializeField] int red = 2;
    [SerializeField] int blue = 2;


    private void Start()
    {
        float x = background.size.x / 2 - deadZone;
        float y = background.size.y / 2 - deadZone;
        spawnArea = new Vector2(x, y);

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
        float x = Random.Range(0, spawnArea.x * 2 + 1) - spawnArea.x;
        float y = Random.Range(0, spawnArea.y * 2 + 1) - spawnArea.y;
        Vector2 position = new Vector2(x, y);
        Instantiate(virus, position, Quaternion.identity, parent).SetMoveArea(spawnArea);
    }
}
