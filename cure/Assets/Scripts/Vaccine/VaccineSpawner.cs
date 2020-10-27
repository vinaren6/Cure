using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VaccineSpawner : MonoBehaviour
{
    [SerializeField] int maxXSpawnPoint = 10;
    [SerializeField] int maxYSpawnPoint = 4;
    [SerializeField] Vaccine[] vaccinePrefabs = null;
    [SerializeField] Transform[] parents = null;
    [SerializeField] int maxVaccine = 10;

    [SerializeField] float spawnInterval = 20f;

    float spawnTime = 0f;

    int greenVaccines = 0;
    int orangeVaccines = 0;
    int redVaccines = 0;
    int blueVaccines = 0;

    private void Start()
    {
        SpawnVaccines();
    }

    private void Update()
    {
        if(spawnTime < Time.time)
        {
            SpawnVaccines();        
            spawnTime = spawnInterval + Time.time;
        }
    }

    private void SpawnVaccines()
    {
        for (int i = 0; i < maxVaccine - greenVaccines; i++)
        {
            SpawnVaccine(vaccinePrefabs[0], parents[0]);
            greenVaccines++;
        }
        for (int i = 0; i < maxVaccine - orangeVaccines; i++)
        {
            SpawnVaccine(vaccinePrefabs[1], parents[1]);
            orangeVaccines++;
        }
        for (int i = 0; i < maxVaccine - redVaccines; i++)
        {
            SpawnVaccine(vaccinePrefabs[2], parents[2]);
            redVaccines++;
        }
        for (int i = 0; i < maxVaccine - blueVaccines; i++)
        {
            SpawnVaccine(vaccinePrefabs[3], parents[3]);
            blueVaccines++;
        }
    }

    private void SpawnVaccine(Vaccine vaccine, Transform parent)
    {
        float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
        float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
        Vector2 position = new Vector2(x, y);
        Instantiate(vaccine, position, Quaternion.identity, parent);
    }

    public void RemoveVaccine(VaccineType vaccineType)
    {
        switch(vaccineType)
        {
            case VaccineType.Green:
                greenVaccines--;
                break;
            case VaccineType.Orange:
                orangeVaccines--;
                break;
            case VaccineType.Red:
                redVaccines--;
                break;
            case VaccineType.Blue:
                blueVaccines--;
                break;
        }
    }
}
