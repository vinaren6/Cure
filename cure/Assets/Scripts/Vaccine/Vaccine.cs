using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    [SerializeField] VaccineType vaccineType = VaccineType.Green;
    [SerializeField] int vaccineAmount = 3;

    private void Start()
    {
        switch (vaccineType)
        {
            case VaccineType.Green:
                gameObject.name = "Green Vaccine";
                break;
            case VaccineType.Orange:
                gameObject.name = "Orange Vaccine";
                break;
            case VaccineType.Red:
                gameObject.name = "Red Vaccine";
                break;
            case VaccineType.Blue:
                gameObject.name = "Blue Vaccine";
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // use method for adding vaccine to player.
            GetComponentInParent<VaccineSpawner>().RemoveVaccine(vaccineType);
            Destroy(gameObject);
        }
    }

}
