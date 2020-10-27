using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [Header("Universal spawn parameters")]
    [SerializeField] Virus virusPrefab = null;
    [Tooltip("This will determine the minimum spawn location and thus needs to be a negative number")]
    [SerializeField] Vector2 minSpawn = new Vector2();
    [Tooltip("This will determine the maximum spawn location")]
    [SerializeField] Vector2 maxSpawn = new Vector2();


    [Header("Green virus spawn parameters")]
    [SerializeField] int greenSpawnAmount = 2;
    [SerializeField] Transform greenParent = null;

    [Header("Orange virus spawn parameters")]
    [SerializeField] int orangeSpawnAmount = 2;
    [SerializeField] Transform orangeParent = null;

    [Header("Red virus spawn parameters")]
    [SerializeField] int redSpawnAmount = 2;
    [SerializeField] Transform redParent = null;

    [Header("Blue virus spawn parameters")]
    [SerializeField] int blueSpawnAmount = 2;
    [SerializeField] Transform blueParent = null;


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
            SpawnVirus(VirusType.Green, greenParent);
        }
    }
    private void SpawnOrangeVirus()
    {
        for (int i = 0; i < orangeSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Orange, orangeParent);
        }
    }
    private void SpawnRedVirus()
    {
        for (int i = 0; i < redSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Red, redParent);
        }
    }
    private void SpawnBlueVirus()
    {
        for (int i = 0; i < blueSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Blue, blueParent);
        }
    }


    void SpawnVirus(VirusType virusType, Transform parent)
    {
        float x = Random.Range(minSpawn.x, maxSpawn.x);
        float y = Random.Range(minSpawn.y, maxSpawn.y);
        Vector2 position = new Vector2(x, y);
        Virus spawnedVirus = Instantiate(virusPrefab, position, Quaternion.identity, parent);
        spawnedVirus.ActivateVirus(virusType, 3);
    }
}
