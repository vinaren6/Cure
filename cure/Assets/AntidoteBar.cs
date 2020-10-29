using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntidoteBar : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[2];

    [SerializeField]
    private HealthAmmo ammo = null;

    [SerializeField]
    private ShootController shootController = null;

    [SerializeField]
    private Type type = Type.Green;

    [SerializeField]
    private Slider slider = null;

    private Image barImage = null;


    private void Start()
    {
        Transform bar = null;

        foreach (Transform child in transform)
        {
            if (child.CompareTag("Bar")) 
            {
                bar = child;
            }
        }
            
        barImage = bar.GetComponent<Image>();
    }


    private void Update()
    {
        slider.value = ammo.GetVaccine((int)type);

        if(shootController.GetSelectedVaccineType() == type)
        {
            barImage.sprite = sprites[1];
        }
        else
        {
            barImage.sprite = sprites[0];
        }
    }
}
