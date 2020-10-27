using System.Collections;
using System.Collections.Generic;
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
        SpawnGreenVirus();
        SpawnOrangeVirus();
        SpawnRedVirus();
        SpawnBlueVirus();
    }

    private void SpawnGreenVirus()
    {
        for (int i = 0; i < greenSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Green, 0, 0);
        }
    }
    private void SpawnOrangeVirus()
    {
        for (int i = 0; i < orangeSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Orange, 1, 1);
        }
    }
    private void SpawnRedVirus()
    {
        for (int i = 0; i < redSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Red, 2, 2);
        }
    }
    private void SpawnBlueVirus()
    {
        for (int i = 0; i < blueSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Blue, 3, 3);
        }
    }


    void SpawnVirus(VirusType virusType, int parentIndex, int virusIndex)
    {
        float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
        float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
        Vector2 position = new Vector2(x, y);
        Instantiate(virusPrefab[virusIndex], position, Quaternion.identity, parents[parentIndex]);
    }
}
