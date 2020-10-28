using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VaccineSpawner : MonoBehaviour
{
    [Header("Vaccine spawn parameters")]
    [SerializeField] Vaccine[] vaccinePrefabs = null;
    [SerializeField] Transform[] parents = null;

    [Tooltip("Set this to the distance that you want the vaccine to " +
        "be able to spawn from the center point on the x and y axis respectively " +
        "(setting a value of 50 gives a range between -50 - 50)")]
    [SerializeField] Vector2 maxSpawnPoint = new Vector2(10,4);
    
    [Tooltip("The time in seconds between spawning new vaccine")]
    [SerializeField] float spawnInterval = 10f;
    [Tooltip("This sets the maximum amount of each type of vaccine allowed to exist on the map")]
    [SerializeField] int maxVaccine = 10;


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
        float x = Random.Range(0, maxSpawnPoint.x * 2 + 1) - maxSpawnPoint.x;
        float y = Random.Range(0, maxSpawnPoint.y * 2 + 1) - maxSpawnPoint.y;
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
