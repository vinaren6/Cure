using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAmmo : MonoBehaviour
{


    public int[] healtAmmo = {4, 4, 4, 4};
    public void takeDamage(HealthType type, int amount)
    {
        healtAmmo[(int) type] -= amount;
        
    }
    public void GetHealth(HealthType type, int amount)
    {
        healtAmmo[(int)type] -= amount;

    }

}
