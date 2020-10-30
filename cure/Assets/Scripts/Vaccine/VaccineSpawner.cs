// Code writer: Nicklas 
using System.Collections.Generic;
using System.Linq;
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

    // this number gets the value of the amount of different vaccines that exists.
    int maxVaccineDivider = 0;

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
        maxVaccineDivider = 4;
        virusController = FindObjectOfType<VirusController>();
        float x = background.size.x / 2 - deadZone;
        float y = background.size.y / 2 - deadZone;
        spawnArea = new Vector2(x, y);
    }

    private void FixedUpdate()
    {
        if(spawnTime < Time.time)
        {
            SetMaxVaccineDivider();
            SpawnVaccines();        
            spawnTime = spawnInterval + Time.time;
        }
    }

    private void SetMaxVaccineDivider()
    {
        maxVaccineDivider = 0;
        foreach(var vaccinelist in vaccines)
        {
            if (vaccinelist.Count > 0)
            {
                maxVaccineDivider++;
            }
        }
    }

    private void SpawnVaccines()
    {
        if(virusController.GetNumberOfVirions(0) > 0)
        {
            vaccines[0].RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(vaccines[0].Count, 0,0);
        }  
        else if(vaccines[0].Count > 0)
        {
            DeleteVaccine(vaccines[0]);
        }   
        
        if(virusController.GetNumberOfVirions(1) > 0)
        {
            vaccines[1].RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(vaccines[1].Count, 1,1);
        }  
        else if(vaccines[1].Count > 0)
        {
            DeleteVaccine(vaccines[1]);
        }  
        
        if(virusController.GetNumberOfVirions(2) > 0)
        {
            vaccines[2].RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(vaccines[2].Count, 2,2);
        }  
        else if(vaccines[2].Count > 0)
        {
            DeleteVaccine(vaccines[2]);
        }  
        
        if(virusController.GetNumberOfVirions(3) > 0)
        {
            vaccines[3].RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(vaccines[3].Count, 3,3);
        }  
        else if(vaccines[3].Count > 0)
        {
            DeleteVaccine(vaccines[3]);
        }

    }

    private void CreateVaccine(int spawnedAmount, int prefabIndex, int parentIndex)
    {
        int amountToSpawn = (maxVaccine / maxVaccineDivider) - spawnedAmount;
        for (int i = 0; i < amountToSpawn; i++)
        {
            SpawnVaccine(vaccinePrefabs[prefabIndex], parents[parentIndex]);
        }
    }    
    private void DeleteVaccine(List<Vaccine> deleteList)
    {
        deleteList.RemoveAll(Vaccine => Vaccine == null);
        foreach (var vaccine in deleteList)
        {
            Destroy(vaccine.gameObject);
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
