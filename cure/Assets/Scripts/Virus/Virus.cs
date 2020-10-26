using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    int health;


    public Virus(VirusType type, int health)
    {
        this.health = health;
        switch (type)
        {
            case VirusType.Green:
                gameObject.tag = "Green";
                break;
            case VirusType.Orange:
                gameObject.tag = "Orange";
                break;
            case VirusType.Red:
                gameObject.tag = "Red";
                break;
            case VirusType.Blue:
                gameObject.tag = "Blue";
                break;
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            // add some fancy death animation 
            Destroy(gameObject);
        }
    }
}