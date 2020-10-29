// Code writer: Nicklas 
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;

public class VaccineSpawner : MonoBehaviour
{
    [Header("Vaccine spawn parameters")]
    [SerializeField] Vaccine[] vaccinePrefabs = null;
    [SerializeField] Transform[] parents = null;  
    [Tooltip("The time in seconds between spawning new vaccine")]
    [SerializeField] float spawnInterval = 10f;
    [Tooltip("This sets the maximum amount of each type of vaccine allowed to exist on the map")]
    [SerializeField] int maxVaccine = 10;

    [SerializeField] SpriteRenderer background = null;
    [SerializeField] float deadZone = 2f;
    Vector2 spawnArea = new Vector2();

    float spawnTime = 0f;

    List<Vaccine> greenVaccines = new List<Vaccine>();
    List<Vaccine> orangeVaccines = new List<Vaccine>();
    List<Vaccine> redVaccines = new List<Vaccine>();
    List<Vaccine> blueVaccines = new List<Vaccine>();

    private void Start()
    {
        float x = background.size.x / 2 - deadZone;
        float y = background.size.y / 2 - deadZone;
        spawnArea = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        if(spawnTime < Time.time)
        {
            SpawnVaccines();        
            spawnTime = spawnInterval + Time.time;
        }
    }

    private void SpawnVaccines()
    {
        greenVaccines.RemoveAll(Vaccine => Vaccine == null);
        orangeVaccines.RemoveAll(Vaccine => Vaccine == null);
        redVaccines.RemoveAll(Vaccine => Vaccine == null);
        blueVaccines.RemoveAll(Vaccine => Vaccine == null);

        Debug.Log(greenVaccines.Count);


        for (int i = 0; i < maxVaccine - greenVaccines.Count; i++)
        {
            SpawnVaccine(vaccinePrefabs[0], parents[0]);
        }
        for (int i = 0; i < maxVaccine - orangeVaccines.Count; i++)
        {
            SpawnVaccine(vaccinePrefabs[1], parents[1]);
        }
        for (int i = 0; i < maxVaccine - redVaccines.Count; i++)
        {
            SpawnVaccine(vaccinePrefabs[2], parents[2]);
        }
        for (int i = 0; i < maxVaccine - blueVaccines.Count; i++)
        {
            SpawnVaccine(vaccinePrefabs[3], parents[3]);
        }
    }

    private void SpawnVaccine(Vaccine vaccine, Transform parent)
    {
        float x = Random.Range(0, spawnArea.x * 2 + 1) - spawnArea.x;
        float y = Random.Range(0, spawnArea.y * 2 + 1) - spawnArea.y;
        Vector2 position = new Vector2(x, y);
        Instantiate(vaccine, position, Quaternion.identity, parent);
    }

    public void AddToVaccineList(Vaccine vaccine, Type type)
    {
        switch(type)
        {
            case Type.Green:
                greenVaccines.Add(vaccine);
                break;
            case Type.Orange:
                orangeVaccines.Add(vaccine);
                break;
            case Type.Red:
                redVaccines.Add(vaccine);
                break;
            case Type.Blue:
                blueVaccines.Add(vaccine);
                break;

        }
    }
}
