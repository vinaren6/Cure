// Code writer: Nicklas 
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [SerializeField] Type type = Type.Green;
    [SerializeField] int vaccineAmount = 3;

    private void Start()
    {
        switch (type)
        {
            case Type.Green:
                gameObject.name = "Green Vaccine";
                break;
            case Type.Orange:
                gameObject.name = "Orange Vaccine";
                break;
            case Type.Red:
                gameObject.name = "Red Vaccine";
                break;
            case Type.Blue:
                gameObject.name = "Blue Vaccine";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthAmmo>().IncreaseVaccine(type, vaccineAmount);
            GetComponentInParent<VaccineSpawner>().DecreaseVaccineCount(type);
            Destroy(gameObject);
        }
    }
}
