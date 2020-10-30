using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites = new Sprite[2];
    [SerializeField]
    private  Slider slider = null;
    [SerializeField]
    private MoveController moveController = null;

    Image barImage; 


    // Start is called before the first frame update
    void Start()
    {
        slider.value = 2;

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

    // Update is called once per frame
    void Update()
    {
        var dashCooldown = moveController.getDashCoolDown();

        slider.value = dashCooldown;

        if (slider.value == 2)
            barImage.sprite = sprites[1];
        else
            barImage.sprite = sprites[0];


    }
}
