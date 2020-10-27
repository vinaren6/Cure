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
        }
    }

    private void SpawnVaccines()
    {
        SpawnGreenVaccine();
        SpawnOrangeVaccine();
        SpawnRedVaccine();
        SpawnBlueVaccine();
        spawnTime = spawnInterval + Time.time;
    }

    private void SpawnGreenVaccine()
    {
        int greenToSpawn = maxVaccine - greenVaccines;
        for (int i = 0; i < greenToSpawn; i++)
        {
            float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
            float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
            Vector2 position = new Vector2(x, y);
            Instantiate(vaccinePrefabs[0], position, Quaternion.identity, parents[0]);
            greenVaccines++;
        }
    }

    private void SpawnOrangeVaccine()
    {
        int orangeToSpawn = maxVaccine - orangeVaccines;
        for (int i = 0; i < orangeToSpawn; i++)
        {
            float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
            float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
            Vector2 position = new Vector2(x, y);
            Instantiate(vaccinePrefabs[1], position, Quaternion.identity, parents[1]);
            orangeVaccines++;
        }
    }

    private void SpawnRedVaccine()
    {
        int redToSpawn = maxVaccine - redVaccines;
        for (int i = 0; i < redToSpawn; i++)
        {
            float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
            float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
            Vector2 position = new Vector2(x, y);
            Instantiate(vaccinePrefabs[2], position, Quaternion.identity, parents[2]);
            redVaccines++;
        }
    }

    private void SpawnBlueVaccine()
    {
        int blueToSpawn = maxVaccine - blueVaccines;
        for (int i = 0; i < blueToSpawn; i++)
        {
            float x = Random.Range(0, maxXSpawnPoint * 2 + 1) - maxXSpawnPoint;
            float y = Random.Range(0, maxYSpawnPoint * 2 + 1) - maxYSpawnPoint;
            Vector2 position = new Vector2(x, y);
            Instantiate(vaccinePrefabs[3], position, Quaternion.identity, parents[3]);
            blueVaccines++;
        }
    }


    public void RemoveVaccine(VaccineType vaccineType)
    {

    }
}
