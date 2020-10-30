using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthAmmo : MonoBehaviour
{

    [SerializeField] int maxVaccine = 20;
    [Tooltip("these values will be the starting amount of vaccine of each kind in order (green, orange, red, blue")]
    [SerializeField] int[] healthAmmo = {4, 4, 4, 4};

    [Tooltip("The duration in seconds that the player is invincible while dashing")]
    [SerializeField] float dashDuration = 1f;


    bool isInvincible = false;
    public void DecreaseVaccine(Type type, int amount)
    {
        if(isInvincible)
        {
            return;
        }
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
                AddVaccine(1, amount);
                break;
            case Type.Red:
                AddVaccine(2, amount);
                break;
            case Type.Blue:
                AddVaccine(3, amount);
                break;
        }
    }

    private void RemoveVaccine(int index,int amount)
    {
        healthAmmo[index] -= amount;
        if (healthAmmo[index] < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public int GetVaccine(int index)
    {
        return healthAmmo[index];
    }

    public void StartDashEnumerator()
    {
        StartCoroutine(DashInvincibillity());
    }

    IEnumerator DashInvincibillity()
    {
        isInvincible = true;
        yield return new WaitForSeconds(dashDuration);
        isInvincible = false;
    }
}
