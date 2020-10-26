using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] Virus virusPrefab = null;

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
        SpawnFirstVirus();
    }

    private void SpawnFirstVirus()
    {
        SpawnGreenViruses();
        SpawnOrangeViruses();
        SpawnRedViruses();
        SpawnBlueViruses();
    }

    private void SpawnGreenViruses()
    {
        for (int i = 0; i < greenSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Green, greenParent);
        }
    }

    private void SpawnOrangeViruses()
    {
        for (int i = 0; i < orangeSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Orange, orangeParent);
        }
    }

    private void SpawnRedViruses()
    {
        for (int i = 0; i < redSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Red, redParent);
        }
    }

    private void SpawnBlueViruses()
    {
        for (int i = 0; i < blueSpawnAmount; i++)
        {
            SpawnVirus(VirusType.Blue, blueParent);
        }
    }

    void SpawnVirus(VirusType virusType, Transform parent)
    {
        Vector2 position = new Vector2(0, 0); // make this have another value later.
        Virus spawnedVirus = Instantiate(virusPrefab, position, Quaternion.identity, parent);
        spawnedVirus.ActivateVirus(virusType, 3);
    }
}
