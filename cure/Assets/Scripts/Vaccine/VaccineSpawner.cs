using UnityEngine;

public class VaccineSpawner : MonoBehaviour
{
    [Header("Vaccine spawn parameters")]
    [SerializeField] Vaccine[] vaccinePrefabs = null;
    [SerializeField] Transform[] parents = null;

    [Tooltip("Set this to the distance that you want the vaccine to " +
        "be able to spawn from the center point on the x and y axis respectively " +
        "(setting a value of 50 gives a range between -50 - 50)")]
    [SerializeField] Vector2 maxSpawnRange = new Vector2(10,4);
    
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
        float x = Random.Range(0, maxSpawnRange.x * 2 + 1) - maxSpawnRange.x;
        float y = Random.Range(0, maxSpawnRange.y * 2 + 1) - maxSpawnRange.y;
        Vector2 position = new Vector2(x, y);
        Instantiate(vaccine, position, Quaternion.identity, parent);
    }

    public void DecreaseVaccineCount(Type type)
    {
        switch(type)
        {
            case Type.Green:
                greenVaccines--;
                break;
            case Type.Orange:
                orangeVaccines--;
                break;
            case Type.Red:
                redVaccines--;
                break;
            case Type.Blue:
                blueVaccines--;
                break;
        }
    }
}
