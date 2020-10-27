using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VaccineSpawner : MonoBehaviour
{
    [Tooltip("This will determine the minimum spawn point and thus requiers a negative number")]
    [SerializeField] Vector2 minSpawnpoint = new Vector2();
    [SerializeField] Vector2 maxSpawnPoint = new Vector2();
    [SerializeField] Vaccine[] vaccinePrefabs = null;
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
        spawnTime = spawnInterval + Time.time;
    }

    public void RemoveVaccine(VaccineType vaccineType)
    {

    }
}
