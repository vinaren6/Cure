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

    VirusController virusController;

    List<Vaccine> greenVaccines = new List<Vaccine>();
    List<Vaccine> orangeVaccines = new List<Vaccine>();
    List<Vaccine> redVaccines = new List<Vaccine>();
    List<Vaccine> blueVaccines = new List<Vaccine>();

    private void Start()
    {
        virusController = FindObjectOfType<VirusController>();
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
        if(virusController.GetNumberOfVirions(0) > 0)
        {
            greenVaccines.RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(greenVaccines.Count, 0,0);
        }  
        else if(greenVaccines.Count > 0)
        {
            DeleteVaccine(greenVaccines);
        }

        if(virusController.GetNumberOfVirions(1) > 0)
        {
            orangeVaccines.RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(orangeVaccines.Count, 1,1);
        }
        else if (orangeVaccines.Count > 0)
        {
            DeleteVaccine(orangeVaccines);
        }

        if (virusController.GetNumberOfVirions(2) > 0)
        {
            redVaccines.RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(redVaccines.Count, 2,2);
        }
        else if (redVaccines.Count > 0)
        {
            DeleteVaccine(redVaccines);
        }

        if (virusController.GetNumberOfVirions(3) > 0)
        {
            blueVaccines.RemoveAll(Vaccine => Vaccine == null);
            CreateVaccine(blueVaccines.Count, 3,3);
        }
        else if (blueVaccines.Count > 0)
        {
            DeleteVaccine(blueVaccines);
        }
    }

    private void CreateVaccine(int spawnAmount, int prefabIndex, int parentIndex)
    {
        for (int i = 0; i < maxVaccine - spawnAmount; i++)
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
