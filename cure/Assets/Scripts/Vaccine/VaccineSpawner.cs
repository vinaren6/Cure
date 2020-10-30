// Code writer: Nicklas 
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Xml;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class VaccineSpawner : MonoBehaviour
{
    [Header("Vaccine spawn parameters")]
    [SerializeField] Vaccine[] vaccinePrefabs = null;
    [SerializeField] Transform[] parents = null;  
    [Tooltip("The time in seconds between spawning new vaccine")]
    [SerializeField] float spawnInterval = 10f;
    [Tooltip("This sets the maximum amount of vaccine allowed to exist on the map")]
    [SerializeField] int maxVaccine = 40;

    [SerializeField] SpriteRenderer background = null;
    [SerializeField] float deadZone = 2f;
    Vector2 spawnArea = new Vector2();

    float spawnTime = 0f;

    int vaccineToSpawn = 10;

    VirusController virusController;

    List<Vaccine>[] vaccines = new List<Vaccine>[]
    {
        new List<Vaccine>(),
        new List<Vaccine>(),
        new List<Vaccine>(),
        new List<Vaccine>()
    };


    private void Start()
    {
        virusController = FindObjectOfType<VirusController>();
        SetSpawnArea();
    }

    private void SetSpawnArea()
    {
        float x = background.size.x / 2 - deadZone;
        float y = background.size.y / 2 - deadZone;
        spawnArea = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        if(spawnTime < Time.time)
        {
            SetVaccineTospawnAmount();
            SpawnVaccines();
            spawnTime = spawnInterval + Time.time;
        }
    }

    private void SetVaccineTospawnAmount()
    {
        int index = 0;
        int divider = 0;
        foreach(var vaccinelist in vaccines)
        {
            if (virusController.GetNumberOfVirions(index) > 0)
            {
                divider++;
            }
            index++;
        }
        vaccineToSpawn = Mathf.RoundToInt(maxVaccine / divider);
    }

    private void SpawnVaccines()
    {
        int index = 0;
        foreach (var vaccineList in vaccines)
        {
            if (virusController.GetNumberOfVirions(index) > 0)
            {
                vaccines[index].RemoveAll(Vaccine => Vaccine == null);
                CreateVaccine(vaccines[index].Count, index, index);
            }
            else if (vaccines[index].Count > 0)
            {
                DeleteVaccine(vaccines[index]);
            }
            index++;
        }
    }

    private void CreateVaccine(int spawnedAmount, int prefabIndex, int parentIndex)
    {
        for (int i = 0; i < vaccineToSpawn - spawnedAmount; i++)
        {
            float x = Random.Range(0, spawnArea.x * 2 + 1) - spawnArea.x;
            float y = Random.Range(0, spawnArea.y * 2 + 1) - spawnArea.y;
            Vector2 position = new Vector2(x, y);
            Instantiate(vaccinePrefabs[prefabIndex], position, Quaternion.identity, parents[parentIndex]);
        }
    }

    private void DeleteVaccine(List<Vaccine> deleteList)
    {
        deleteList.RemoveAll(Vaccine => Vaccine == null);
        foreach (var vaccine in deleteList)
        {
            Destroy(vaccine.gameObject);
        }
        deleteList.Clear();
    }

    public void AddToVaccineList(Vaccine vaccine, Type type)
    {
        switch(type)
        {
            case Type.Green:
                vaccines[0].Add(vaccine);
                break;
            case Type.Orange:
                vaccines[1].Add(vaccine);
                break;
            case Type.Red:
                vaccines[2].Add(vaccine);
                break;
            case Type.Blue:
                vaccines[3].Add(vaccine);
                break;

        }
    }
}
