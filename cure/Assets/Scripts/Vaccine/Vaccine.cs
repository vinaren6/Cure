using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccine : MonoBehaviour
{
    VaccineType vaccineType;
    [SerializeField] int vaccineAmount = 3;

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
