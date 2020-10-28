using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntidoteBar : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[2];

    [SerializeField]
    private HealthAmmo ammo;

    [SerializeField]
    private ShootController shootController;

    [SerializeField]
    private Type type;

    [SerializeField]
    private Slider slider;

    private Image barImage;


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
