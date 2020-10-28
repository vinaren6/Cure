using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class HealthAmmo : MonoBehaviour
{

    [SerializeField] int maxVaccine = 20;
    public int[] healthAmmo = {4, 4, 4, 4};

    public void DecreaseVaccine(Type type, int amount)
    {
        switch(type)
        {
            case Type.Green:
                RemoveVaccine(0, amount);
                break;
            case Type.Orange:
                RemoveVaccine(1, amount);
                break;
            case Type.Red:
                RemoveVaccine(2, amount);
                break;
            case Type.Blue:
                RemoveVaccine(3, amount);
                break;
        }     
    }

    public void IncreaseVaccine(Type type, int amount)
    {
        switch (type)
        {
            case Type.Green:
                AddVaccine(0, amount);
                break;
            case Type.Orange:
                AddVaccine(0, amount);
                break;
            case Type.Red:
                AddVaccine(0, amount);
                break;
            case Type.Blue:
                AddVaccine(0, amount);
                break;
        }
    }

    private void RemoveVaccine(int index,int amount)
    {
        healthAmmo[index] -= amount;
        if (healthAmmo[index] <= 0)
        {
            // game over here.
        }
    }

    private void AddVaccine(int index, int amount)
    {
        healthAmmo[index] += amount;
        if (healthAmmo[index] >= maxVaccine)
        {
            healthAmmo[index] = maxVaccine;
        }
    }
}
